using Godot;
using System;

public class CameraFollow : Node2D {
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private Node2D playerTarget;
    public bool playerDied;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        playerTarget = GetParent().GetNode<Node2D>("Player");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta) {
        if (playerDied) return;

        Position = playerTarget.GetPosition();
    }
}
