using Godot;
using System;

public partial class InteractionManager : Node2D
{
    public InteractionManager instance {get;set;} = null;
    [Export]
    public Player player {get;set;}
    public override void _Ready()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
