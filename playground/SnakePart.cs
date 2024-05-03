using Godot;
using System;

public partial class SnakePart : Area2D
{
	private Vector2 lastPosition;

	public void Move(Vector2 newPosition)
	{
		Position += newPosition;
		lastPosition = Position;
	}
}
