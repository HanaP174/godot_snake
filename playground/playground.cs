using System;
using Godot;

public partial class playground : Node2D
{
	private int _score;
	private bool _gameOver;
	private double _speed = 2000.0;
	private double _lastMoveTime = 1000.0;
	private const double TimeBetweenMovements = 1000.0;
	private const float GridSize = 22;
	
	private Vector2 _movement = Vector2.Right;
	private Head _head;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartGame();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		HandleMovement();
		_lastMoveTime += delta * TimeBetweenMovements;
		if (_lastMoveTime >= TimeBetweenMovements)
		{
			UpdateSnake();
			_lastMoveTime = 0;
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		_lastMoveTime += delta * _speed;
		if (_lastMoveTime >= TimeBetweenMovements)
		{
			UpdateSnake();
			_lastMoveTime = 0;
		}
	}

	private void StartGame()
	{
		Init();
		// GameLoop();
		// GameOver();
	}

	private void Init()
	{
		_score = 5;
		_gameOver = false;
		_head = GetNode<Head>("./Head");
		// _random = new Random();
		// _snake = new Snake(new Pixel(Width / 2, Height / 2, ConsoleColor.Red), new List<Pixel>());
		// _treat = new Pixel(_random.Next(0, Width), _random.Next(0, Height),
		// 	ConsoleColor.Cyan);
	}


	private void HandleMovement()
	{
		if (Input.IsActionPressed("ui_down"))
		{
			_movement = Vector2.Down;
		}
		if (Input.IsActionPressed("ui_up"))
		{
			_movement = Vector2.Up;
		}
		if (Input.IsActionPressed("ui_right"))
		{
			_movement = Vector2.Right;
		}
		if (Input.IsActionPressed("ui_left"))
		{
			_movement = Vector2.Left;
		}
	}

	private void UpdateSnake()
	{
		_head.Move(_movement * GridSize);
		_gameOver = _head.WallCollision;
	}
}