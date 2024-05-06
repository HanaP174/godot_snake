using System;
using Godot;

public partial class Head : SnakePart
{
	[Signal]
	public delegate void TreatEatenEventHandler();

	[Signal]
	public delegate void CollisionEventHandler();

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	public void OnBodyEntered(Node2D body)
	{
		EmitSignal(SignalName.Collision);
	}

	public void OnAreaEntered(Area2D area)
	{
		if (area.HasMethod("Eaten"))
		{
			area.Call("Eaten");
			EmitSignal(SignalName.TreatEaten);
		}
		if (area.HasMethod("HitBody"))
		{
			EmitSignal(SignalName.Collision);
		}
	}
}
