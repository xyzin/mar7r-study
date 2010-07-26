var backGround;
var degree;
var velocity;
var target;
var CLOSED_ENOUGH = 10;

window.onload = function() {
	backGround = document.createElement("div");
	backGround.style.height = '400px';
	backGround.style.width = '600px';
	backGround.style.border = 'thin solid #FF0000';
	backGround.style.position = 'absolute';
	
	target = new Target();
	var target_div = document.createElement("div");
	target_div.appendChild(document.createTextNode("#"));
	target_div.style.top = target.getTop() + 'px';
	target_div.style.left = target.getLeft() + 'px';
	target_div.style.position = 'absolute';
	
	backGround.appendChild(target_div);
	
	degree = document.createElement("input");
	degree.style.width = '30px';
	velocity = document.createElement("input");
	velocity.style.width = '30px';
	var button = document.createElement("button");
	button.appendChild(document.createTextNode("launch"));
	button.onclick = Shoot;
	
	backGround.appendChild(document.createTextNode("angle (1 ~ 89) : "));
	backGround.appendChild(degree);
	backGround.appendChild(document.createTextNode("velocity (1 ~ 99) : "));
	backGround.appendChild(velocity);
	backGround.appendChild(button);
	var body = document.getElementsByTagName("body")[0];
	body.appendChild(backGround);
};

function Shoot() {
	var bullet = new Bullet(degree.value, velocity.value);

	var bullet_div;
	
	while(bullet.useful())
	{
		bullet_div = document.createElement("div");
		bullet_div.appendChild(document.createTextNode("*"));
		bullet_div.style.position = 'absolute';

		if(bullet.isVisible())
		{
			bullet_div.style.top = bullet.getTop() + 'px';
			bullet_div.style.left = bullet.getLeft() + 'px';
		}
		bullet.doNext();
		backGround.appendChild(bullet_div);
		checkCollision(bullet);
	}
};

function checkCollision(bullet) {
	if( Math.abs(bullet.getLeft() - target.getLeft()) < CLOSED_ENOUGH &&
			Math.abs(bullet.getTop() - target.getTop()) < CLOSED_ENOUGH )
	{
		alert("ИэСп");		
	}
};