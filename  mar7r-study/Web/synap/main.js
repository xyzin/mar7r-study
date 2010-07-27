var div_background;
var input_degree;
var input_velocity;
var target;
var CLOSED_ENOUGH = 10;

window.onload = function() {
	init();
	createTarget();
	createButton();
};

function init() {
	div_background = document.getElementById("div_background");
	input_degree = document.getElementById("degree");
	input_velocity = document.getElementById("velocity");		
}

function createTarget() {
	target = new Target();
	var div_target = document.createElement("div");
	div_target.appendChild(document.createTextNode("#"));
	div_target.style.top = target.getTop() + 'px';
	div_target.style.left = target.getLeft() + 'px';
	div_background.appendChild(div_target);
}

function createButton() {
	var button = document.createElement("button");
	button.appendChild(document.createTextNode("launch"));
	button.onclick = Shoot;
	div_background.appendChild(button);	
}

function Shoot() {
	var bullet = new Bullet(input_degree.value, input_velocity.value);

	var div_bullet;
	
	while(bullet.useful())
	{
		div_bullet = document.createElement("div");
		div_bullet.appendChild(document.createTextNode("*"));

		if(bullet.isVisible())
		{
			div_bullet.style.top = bullet.getTop() + 'px';
			div_bullet.style.left = bullet.getLeft() + 'px';
		}
		bullet.doNext();
		div_background.appendChild(div_bullet);
		if (checkCollision(bullet))
			break;
	}
};

function checkCollision(bullet) {
	if( Math.abs(bullet.getLeft() - target.getLeft()) < CLOSED_ENOUGH &&
			Math.abs(bullet.getTop() - target.getTop()) < CLOSED_ENOUGH )
	{
		alert("ИэСп");
		return true;
	}
	return false;
};