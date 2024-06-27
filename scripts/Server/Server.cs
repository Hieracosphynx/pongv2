using System;
using System.Collections.Generic;
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

    public void CreateSession()
    {
        var websocketAdapter = new GodotWebSocketAdapter();
        GameClient.AddChild(websocketAdapter);

        GameSocket = Socket.From(ClientInstance, websocketAdapter);
    }

    public async Task ConnectSocket()
    {
       try {
        await GameSocket.ConnectAsync(GameSession);
        GD.Print(GameSocket);
       }    
       catch(ApiResponseException e) {
        GD.PrintErr(e.ToString());
        return;
       }
    }

    public async Task AuthenticateDevice()
    { 
        try {
            var device = new Dictionary<string, string>(){
                {"Id", Guid.NewGuid().ToString()},
                {"OS", OS.GetName()},
                {"Model",OS.GetModelName()},
                {"UserId", Guid.NewGuid().ToString()}
            };

            GameSession = await ClientInstance.AuthenticateDeviceAsync(device["Id"], null, true, device);
            await ClientInstance.LinkCustomAsync(GameSession, device["Id"]);
            GD.Print(GameSession);
	    }
       catch(ApiResponseException e) {
        GD.PrintErr(e.ToString());
        return;
       }
    }
}
