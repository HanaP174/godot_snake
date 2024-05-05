using Godot;
using System;

public partial class Spawner : Node2D
{
	[Export]
	private Bounds bounds;

	private Random _random;
	private PackedScene _treatScene;
	
	public override void _Ready()
	{
		_treatScene = ResourceLoader.Load<PackedScene>("res://playground/Treat.tscn");
		_random = new Random();
	}

	public void SpawnTreat()
	{
		Vector2 treatPosition = Vector2.Zero;
		treatPosition.X = _random.Next((int) bounds.XMin + 60, (int) bounds.XMax - 60);
		treatPosition.Y = _random.Next((int) bounds.YMin + 60, (int) bounds.YMax - 60);
		Area2D treat = _treatScene.Instantiate() as Area2D;
		treat.Position = treatPosition;
		GetParent().AddChild(treat);
	}
}
