using Godot;
using System;

public class Monster : KinematicBody2D {
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private float moveSpeed = 600f;
    private float gravity = 20f;
    private Vector2 movement;
    public bool moveLeft;
    public bool isGhost;
    private float min_X = -5900f, max_X = 6650f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        if (this.Name == "Ghost") isGhost = true;
        if (moveLeft) {
            moveSpeed *= -1f;
            GetNode<AnimatedSprite>("Animation").FlipH = true;
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta) {
        if (!isGhost) 
            movement.y += gravity;
        
        movement.x = moveSpeed;
        movement = MoveAndSlide(movement);

        if (Position.x > max_X || Position.x < min_X) {
            QueueFree();
        }
    }
}
