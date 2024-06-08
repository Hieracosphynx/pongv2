using System.Threading.Tasks;
using Godot;
using Nakama;

public class Server
{
    private Client ClientInstance { get; set; }
    private ISocket GameSocket { get; set; }
    private ISession GameSession { get; set; }
    private readonly Node GameClient;

    public Server(Node GameClient)
    {
        this.GameClient = GameClient;
    }

    public void CreateClient()
    {
        var httpAdapter = new GodotHttpAdapter();

        GameClient.AddChild(httpAdapter);

        const string scheme = "http";
        const string host = "127.0.0.1";
        const int port = 7350;
        const string serverKey = "defaultkey";

        // Pass in the 'http_adapter' as the last argument.
        ClientInstance = new Client(scheme, host, port, serverKey, httpAdapter)
        {
            Logger = new GodotLogger("Nakama", GodotLogger.LogLevel.DEBUG),
            Timeout = 10
        };
    }

    public async Task CreateSession()
    {
        try {
            GameSession = await ClientInstance.AuthenticateDeviceAsync(OS.GetUniqueId(), "TestUser", true); 
        }
        catch(ApiResponseException e) {
            GD.PrintErr(e.ToString());
            return;
        }

        var websocketAdapter = new GodotWebSocketAdapter();
        GameClient.AddChild(websocketAdapter);

        GameSocket = Socket.From(ClientInstance, websocketAdapter);
    }

    public async Task ConnectSocket()
    {
       try {
        await GameSocket.ConnectAsync(GameSession);
       }    
       catch(ApiResponseException e) {
        GD.PrintErr(e.ToString());
        return;
       }
    }
}
