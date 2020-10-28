extends Control


var simultaneous_scene = preload("res://Scenes/Gameplay.tscn").instance()


func _on_Button_pressed():
	get_tree().get_root().add_child(simultaneous_scene)
