using System;
using Godot;

public partial class Head : SnakePart
{
	public bool WallCollision = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnBodyEntered(Node2D body)
	{

		WallCollision = true;
	}
}