using Godot;
using Nakama;
using System;

public partial class Game : Node
{
    private Server GameServer;
    private Area2D SpawnableObstacleArea;

    public override void _Ready()
    {
        CreateConnection();
    }

    private async void CreateConnection()
    {
        GameServer = new Server(this);
        GameServer.CreateClient();
        GameServer.CreateSession();
        await GameServer.AuthenticateDevice();
        await GameServer.ConnectSocket();
    }
}
