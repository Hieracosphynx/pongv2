using Godot;
using Nakama;

public class Server
{
    private Node GameClient;

    public Server(Node GameClient)
    {
        this.GameClient = GameClient;
    }

    public async void NewClient()
    {
        var httpAdapter = new GodotHttpAdapter();

        GameClient.AddChild(httpAdapter);

        const string scheme = "http";
        const string host = "127.0.0.1";
        const int port = 7350;
        const string serverKey = "defaultkey";

        // Pass in the 'http_adapter' as the last argument.
        var client = new Client(scheme, host, port, serverKey, httpAdapter);

        client.Logger = new GodotLogger("Nakama", GodotLogger.LogLevel.DEBUG);

        ISession session;
        try {
            session = await client.AuthenticateDeviceAsync(OS.GetUniqueId(), "TestUser", true); 
        }
        catch(ApiResponseException e) {
            GD.PrintErr(e.ToString());
            return;
        }

        var websocketAdapter = new GodotWebSocketAdapter();
        GameClient.AddChild(websocketAdapter);

        var socket = Socket.From(client, websocketAdapter);
    }

}
