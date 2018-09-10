var changeDelay = 1.0;
var changeSpeed = 3.0;

private var goalColor : Color;

function Start () {
	while (true) {
		goalColor = Color(Random.value, Random.value, Random.value, 1.0);
		yield WaitForSeconds(changeDelay);
	}
}

function Update () {
	GetComponent.<Renderer>().material.color = Colorx.Slerp(GetComponent.<Renderer>().material.color, goalColor, changeSpeed * Time.deltaTime);
}
