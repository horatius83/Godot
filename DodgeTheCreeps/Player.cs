using Godot;
using System;

public class Player : Area2D
{
	[Export]
	public int Speed {get; set;} = 400;

	private Vector2 _screenSize;

	public override void _Ready() {
		_screenSize = GetViewPort().size;
	}

	public override void _Process(float delta) {
		var velocity = new Vector2();
		var deltaX

		var deltaX = Input.IsActionPressed("ui_right") 
			? 1 
			: Input.IsActionPressed("ui_left")
				? -1
				: 0;
		var deltaY = Input.IsActionPressed("ui_down")
			? 1
			: Input.IsActionPressed("ui_up")
				? -1
				: 0;
		

	}
}
