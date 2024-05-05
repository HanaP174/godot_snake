using Godot;

public partial class Bounds : Node2D
{
	private Marker2D _topLeft;

	private Marker2D _bottomRight;

	public float XMin;

	public float YMin;
	public float XMax;
	public float YMax;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_topLeft = GetNode<Marker2D>("./TopLeft");
		_bottomRight = GetNode<Marker2D>("./BottomRight");
		XMin = _topLeft.Position.X;
		YMin = _topLeft.Position.Y;
		XMax = _bottomRight.Position.X;
		YMax = _bottomRight.Position.Y;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}