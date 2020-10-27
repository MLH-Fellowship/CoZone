using Godot;
using System;

public class GamePlay : Node {
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    [Export]
    private PackedScene greenZombie, redZombie, ghost;
    private Vector2 spawn_Left = new Vector2(-5000f, 535);
    private Vector2 spawn_Right = new Vector2(6090f, 535);
    private Timer restart;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        // _on_Monster_Spawn();
        restart = GetNode<Timer>("Restart");
    }

    void _on_Monster_Spawn() {
        int randEnemy = new Random().Next(0, 3);

        Monster newMonster = null;
        switch(randEnemy) {
            case 0:
                newMonster = greenZombie.Instance() as Monster;
                break;
            case 1:
                newMonster = redZombie.Instance() as Monster;
                break;
            case 2:
                newMonster = ghost.Instance() as Monster;
                break;
        }

        Vector2 temp;
        if (new Random().Next(0, 2) > 0) {
            temp = spawn_Right;
            newMonster.moveLeft = true;
        } else {
            temp = spawn_Left;
        }

        newMonster.SetPosition(temp);
        AddChild(newMonster);
    }

    public void PlayerDied() {
        restart.Start();
    }

    void _on_player_Died() {
        GetTree().ReloadCurrentScene();
    }
}
