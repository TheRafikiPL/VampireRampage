using Godot;
using System;
using GodotPlugins;

public partial class Human : CharacterBody2D
{
    [Export]
    public int Health {get;set;} = 20;
    [Export]
    public int RoamingSpeed {get;set;} = 200;
    [Export]
    public int RunningSpeed {get;set;} = 300;
    private CharacterBody2D Player;
    Random r = new Random();
    [Export]
    public EntityState State {get;set;} = EntityState.ROAMING;
    Vector2 RoamingDirection;
    [Export]
    public double RoamingSeconds {get;set;} = 10.0;
    double RoamingCooldown;

    public override void _Ready()
    {
        RoamingDirection = new Vector2((r.NextSingle()*2)-1,(r.NextSingle()*2)-1);
        RoamingCooldown = RoamingSeconds;
    }
    public override void _PhysicsProcess(double delta)
    {
        switch(State)
        {
            case EntityState.ROAMING:
                RoamingCooldown-=delta;
                if(RoamingCooldown<0.0)
                {
                    RoamingDirection = new Vector2((r.NextSingle()*2)-1,(r.NextSingle()*2)-1);
                    RoamingCooldown = RoamingSeconds;
                }
                Velocity = RoamingDirection.Normalized() * RoamingSpeed;
                break;
            case EntityState.RUNNING:
                //direction = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
                //Velocity = direction * RunningSpeed;
                break;
            case EntityState.DYING:
                Velocity = Vector2.Zero;
                break;
        }
        
        
        MoveAndSlide();
    }
}
