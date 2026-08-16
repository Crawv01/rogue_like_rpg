using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public enum FacingDirection
	{
		Down,
		Up,
		Left,
		Right,
	}
	public const float Speed = 300.0f;
	public FacingDirection Facing { get; private set; } = FacingDirection.Down;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;


		
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;

			if (Mathf.Abs(direction.X) > Mathf.Abs(direction.Y))
			{
				Facing = direction.X > 0 ? FacingDirection.Right : FacingDirection.Left;
			}
			else
			{
				Facing = direction.Y > 0 ? FacingDirection.Down : FacingDirection.Up;
			}
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
