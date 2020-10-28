using Godot;
using System;

public class Player : KinematicBody2D {
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private Vector2 movement = Vector2.Zero;
    private float move_Speed = 400f;
    private float gravity = 20f;
    private float jump_Force = -900f;
    private Vector2 up_Dir = Vector2.Up;
    private AnimatedSprite animation; 

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        animation = (AnimatedSprite)GetNode("Animation");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta) {
        PlayerMovement();
    }

    void PlayerMovement() {
        movement.y += gravity;
        if (Input.IsActionPressed("move_right")) {
            movement.x = move_Speed;
                    animation.Play("Walk");

            AnimateMovement(true, true);
        } else if (Input.IsActionPressed("move_left")) {
            movement.x = -move_Speed;
                    animation.Play("Walk");

            AnimateMovement(true, false);
        } else {
            movement.x = 0f;
            AnimateMovement(false, true);
        }

        if (IsOnFloor()) {
            if (Input.IsActionPressed("jump")) {
                movement.y = jump_Force;
            }
        }
        movement = MoveAndSlide(movement, up_Dir);
    }

    void AnimateMovement(bool moving, bool moveRight) {
        animation.Play("Walk");

        if (moving) {
            animation.Play("Walk");
            if (moveRight) {
                animation.FlipH = false;
            } else {
                animation.FlipH = true;
            }
        } else {
            // animation.Play("Idle");
        }
    }

    void _on_Body_entered(PhysicsBody2D body) {
        if (body.IsInGroup("Enemy")) {
            GetParent().GetNode<CameraFollow>("Main Cam").playerDied = true;
            GetParent<GamePlay>().PlayerDied();
            QueueFree();
        }
    }
}
