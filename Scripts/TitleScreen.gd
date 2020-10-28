extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.

func _on_Button_pressed(_scene_to_load):
	return get_tree().change_scene("res://Scenes/Gameplay.tscn")
