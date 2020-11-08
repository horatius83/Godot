using Godot;
using System;

public class Main : Node
{
    [Export]
    public PackedScene Mob;

    private int _score;


    private Random _random = new Random();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        NewGame();        
    }

    public void GameOver()
    {
        GetNode<Timer>("MobTimer").Stop();
        GetNode<Timer>("ScoreTimer").Stop();
    }

    public void NewGame()
    {
        _score = 0;

        var player = GetNode<Player>("Player");
        var startPosition = GetNode<Position2D>("StartPosition");
        player.Start(startPosition.Position);

        GetNode<Timer>("StartTimer").Start();
    }

    public void OnStartTimerTimeout()
    {
        GetNode<Timer>("MobTimer").Start();
        GetNode<Timer>("ScoreTimer").Start();
    }

    public void OnScoreTimerTimeout()
    {
        _score++;
    }

    public void OnMobTimerTimeout()
    {
        var mobSpanLocation = GetNode<PathFollow2D>("MobPath/MobSpanLocation");
        mobSpanLocation.Offset = _random.Next();

        var mobInstance = (RigidBody2D)Mob.Instance();
        AddChild(mobInstance);

        float direction = mobSpanLocation.Rotation + Mathf.Pi / 2;

        mobInstance.Position = mobSpanLocation.Position;

        direction += RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
        mobInstance.Rotation = direction;

        mobInstance.LinearVelocity = new Vector2(RandRange(150f, 250f), 0).Rotated(direction);
    }

    private float RandRange(float min, float max)
    {
        return (float)_random.NextDouble() * (max - min) + min;
    }
}
