using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
    public override void _Process(double delta)
    {
		//Temporary: manual damage test until a real attack system exists
        if (Input.IsActionJustPressed("ui_cancel"))
		{
			TakeDamage(10);
		}
    }

	public const int MaxHealth = 30;
	public int Health { get; private set; }

    public override void _Ready()
    {
        Health = MaxHealth;
    }
	public void TakeDamage(int amount)
	{
		Health -= amount;

		if (Health <= 0)
		{
			Die();
		}
	}
	private void Die()
	{
		QueueFree();
	}

}