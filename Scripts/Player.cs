using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Signal]
    public delegate void HealthChangedEventHandler(int currentVal);
    [Export]
    public int MaxHealth {get;set;} = 1000;
    public int CurrentHealth;
    [Export]
    public int DecayValue {get;set;} = 1;
    [Export]
    public int Speed {get;set;} = 400;
    [Export]
    public double DecaySeconds {get;set;} = 2.0;
    private double DecayCooldown;
    bool isSucking = false;
    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
        DecayCooldown = DecaySeconds;
    }
    public override void _PhysicsProcess(double delta)
    {
        DecayCooldown-=delta;
        if(DecayCooldown<=0.0)
        {
            ChangeHealth(-DecayValue);
            DecayCooldown = DecaySeconds;
        }
        var direction = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        Velocity = direction * Speed;
        MoveAndSlide();
    }
    public void ChangeHealth(int val)
    {
        CurrentHealth += val;
        EmitSignal(SignalName.HealthChanged,CurrentHealth);
        if(CurrentHealth<=0)
        {
            Die();
        }
    }
    public void Die()
    {
        this.Free();
    }
}
