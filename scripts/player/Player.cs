using Godot;
using System;


public partial class Player : CharacterBody2D
{

	public int Health { get; private set; }
	public int MaxHealth { get; private set; } = 100;
	public enum FacingDirection
	{
		Down,
		Up,
		Left,
		Right,
	}
	private bool _isDead = false;
	public const float Speed = 300.0f;
	public FacingDirection Facing { get; private set; } = FacingDirection.Down;

	public Vector2 AimDirection { get; private set; } = Vector2.Down;

	private Sprite2D _sprite;

	public override void _Ready()
	{
		_sprite = GetNode<Sprite2D>("Sprite2D");
		Health = MaxHealth;
	}

	public override void _PhysicsProcess(double delta)
	{
		//Temperary manuel damage test
		if (Input.IsActionJustPressed("ui_cancel"))
		{
			TakeDamage(10);
		}

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

			UpdateSpriteColor();
			AimDirection = direction.Normalized();
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void TakeDamage(int amount)
	{
		if (_isDead)
		{
			return;
		}
		Health -= amount;
		
		if (Health <= 0)
		{
			Health = 0;
			_isDead = true;
			Die();
		}

	}

	private void Die()
	{
		GD.Print("You Died");
	}
	// TEMPORARY: color-codes facing direction until real sprite art exists.
		private void UpdateSpriteColor()
	{
		_sprite.Modulate = Facing switch
		{
			FacingDirection.Up => Colors.Blue,
			FacingDirection.Down => Colors.Green,
			FacingDirection.Left => Colors.Yellow,
			FacingDirection.Right => Colors.Red,
			_ => Colors.White
		};
	}
}
