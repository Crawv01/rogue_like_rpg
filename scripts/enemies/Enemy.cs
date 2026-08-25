using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
    
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