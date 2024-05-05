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
	private GameOverScreen _gameOverScreen;
	private Spawner _spawner;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Init();
		_spawner.SpawnTreat();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CheckGameOver();

		HandleMovement();
		_lastMoveTime += delta * _speed;
		if (_lastMoveTime >= TimeBetweenMovements)
		{
			UpdateSnake();
			_lastMoveTime = 0;
		}
	}

	private void Init()
	{
		_score = 5;
		_gameOver = false;
		_head = GetNode<Head>("./Head");
		_gameOverScreen = GetNode<GameOverScreen>("./GameOverScreen");
		_spawner = GetNode<Spawner>("./Spawner");
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

	private void CheckGameOver()
	{
		if (_gameOver) _gameOverScreen.Visible = true;
	}
}