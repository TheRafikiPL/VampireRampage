extends ShapeDraw2D

enum BloodType{
	UNSET,
	RED,
	GREEN,
	BLUE
}
@export var blood_type: BloodType = BloodType.UNSET

func _ready():
	if blood_type == BloodType.UNSET:
		blood_type = (randi()%3)+1 as BloodType
	match blood_type:
		BloodType.RED:
			color = Color(1.0,0.0,0.0)
		BloodType.GREEN:
			color = Color(0.0,1.0,0.0)
		BloodType.BLUE:
			color = Color(0.0,0.0,1.0)
	super()
	pass
