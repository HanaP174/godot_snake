using System;
using Godot;

public partial class Head : SnakePart
{
	[Signal]
	public delegate void TreatEatenEventHandler();

	public bool WallCollision = false;

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	public void OnBodyEntered(Node2D body)
	{
		WallCollision = true;
	}

	public void OnAreaEntered(Area2D area)
	{
		if (area.HasMethod("Eaten"))
		{
			EmitSignal(SignalName.TreatEaten);
			area.Call("Eaten");
		}
	}
}
