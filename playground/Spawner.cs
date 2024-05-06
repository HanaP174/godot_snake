using Godot;
using System;

public partial class Spawner : Node2D
{
	[Export]
	private Bounds _bounds;

	[Signal]
	public delegate void BodyAddedEventHandler(Body body); 

	private Random _random;
	private PackedScene _treatScene;
	private PackedScene _snakeBodyScene;
	
	public override void _Ready()
	{
		_treatScene = ResourceLoader.Load<PackedScene>("res://playground/Treat.tscn");
		_snakeBodyScene = ResourceLoader.Load<PackedScene>("res://playground/Body.tscn");
		_random = new Random();
	}

	public void SpawnTreat()
	{
		Vector2 treatPosition = Vector2.Zero;
		treatPosition.X = _random.Next(Mathf.FloorToInt(_bounds.XMin + 32), Mathf.FloorToInt(_bounds.XMax - 32));
		treatPosition.Y = _random.Next(Mathf.FloorToInt(_bounds.YMin + 32), Mathf.FloorToInt(_bounds.YMax - 32));

		treatPosition.X = Mathf.FloorToInt(treatPosition.X / 32) * 32;
		treatPosition.Y = Mathf.FloorToInt(treatPosition.Y / 32) * 32;
		if (_treatScene.Instantiate() is Area2D treat)
		{
			treat.Position = treatPosition;
			GetParent().AddChild(treat);
		}
	}

	public void SpawnSnakeBody(Vector2 position)
	{
		if (_snakeBodyScene.Instantiate() is Area2D bodyPart)
		{
			bodyPart.Position = position;
			GetParent().AddChild(bodyPart);
			EmitSignal(SignalName.BodyAdded, bodyPart);
		}	
	}
}
