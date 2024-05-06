using System.Collections.Generic;
using Godot;
using Godot.Collections;
using Array = System.Array;

public partial class playground : Node2D
{
	private int _score;
	private double _speed = 3000.0;
	private double _lastMoveTime = 1000.0;
	private const double TimeBetweenMovements = 1000.0;
	private const float GridSize = 32;
	
	private Vector2 _movement = Vector2.Right;
	private Head _head;
	private GameOverScreen _gameOverScreen;
	private Spawner _spawner;
	private Array<SnakePart> _snakeBody = new Array<SnakePart>();
	
	public override void _Ready()
	{
		Init();
		_spawner.SpawnTreat();
	}

	public override void _Process(double delta)
	{
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
		_head = GetNode<Head>("./Head");
		_gameOverScreen = GetNode<GameOverScreen>("./GameOverScreen");
		_spawner = GetNode<Spawner>("./Spawner");
		
		_head.TreatEaten += TreatEaten;
		_spawner.BodyAdded += AddSnakeBody;
		_head.Collision += CheckGameOver;
		
		_snakeBody.Add(_head);
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
		_head.Move(_head.Position + _movement * GridSize);
		for (int i = 1; i < _snakeBody.Count; i++)
		{
			Vector2 previousPosition = _snakeBody[i - 1].LastPosition;
			_snakeBody[i].Move(previousPosition);
		}
	}

	private void CheckGameOver()
	{
		_gameOverScreen.Visible = true;
	}

	private void TreatEaten()
	{
		_spawner.CallDeferred("SpawnTreat");
		_score++;
		_spawner.CallDeferred("SpawnSnakeBody", _snakeBody[^1].LastPosition);
	}

	private void AddSnakeBody(Body snakePart)
	{
		_snakeBody.Add(snakePart);
	}
}