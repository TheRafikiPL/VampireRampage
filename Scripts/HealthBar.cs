using Godot;
using System;
using System.Diagnostics;

public partial class HealthBar : ProgressBar
{
    [Export]
    public Player player {get;set;}
    public override void _Ready()
    {
        MaxValue = player.MaxHealth;
        Value = player.MaxHealth;
        Step = 1;
        base._Ready();
    }
    public override void _Process(double delta)
    {
        Value = player.CurrentHealth;
        base._Process(delta);
    }
    
}
