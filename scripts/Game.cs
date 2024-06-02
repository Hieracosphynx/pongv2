using Godot;
using Nakama;
using System;

public partial class Game : Node
{
    private Server GameServer;
    private Area2D SpawnableObstacleArea;

    public override void _Ready()
    {
        GameServer = new Server(this);
        GameServer.NewClient();
    }
}
