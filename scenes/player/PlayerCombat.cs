using Godot;
using System;

public partial class PlayerCombat : Area2D
{


	public float AttackRange = 80f;
	public float AttackDuration = 0.15f;
	public float AttackCooldown = 0.4f;

	private Player _player;

	private float _cooldownTimer = 0f;

	public override void _Ready()
	{
		_player = GetParent<Player>();
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is Enemy enemy)
		{
			enemy.TakeDamage(10);
		}
	}

	public override void _Process(double delta)
	{
		if (_cooldownTimer > 0)
		{
			_cooldownTimer -= (float)delta;
		}

		if (Input.IsActionJustPressed("basic_attack") && _cooldownTimer <= 0)
		{
			PerformAttack();
		}
	}

	private async void PerformAttack()
	{
		_cooldownTimer = AttackCooldown;
		Position = _player.AimDirection * AttackRange;
		Monitoring = true;

		await ToSignal(GetTree().CreateTimer(AttackDuration), SceneTreeTimer.SignalName.Timeout);

		Monitoring = false;
	}

}