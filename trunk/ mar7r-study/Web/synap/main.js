var backGround;
var degree;
var velocity;

window.onload = function() {
	backGround = document.createElement("div");
	backGround.style.height = '400px';
	backGround.style.width = '600px';
	backGround.style.border = 'thin solid #FF0000';
	backGround.style.position = 'absolute';
	
	Target.init();
	var target = document.createElement("div");
	target.appendChild(document.createTextNode("#"));
	target.style.top = '390px';
	target.style.left = Target.getPosition() + 'px';
	target.style.position = 'absolute';
	
	backGround.appendChild(target);
	
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
	Bullet.init(degree.value, velocity.value);
	var bullet_Top = 390;
	var bullet_Left = 0;
	var bullet;
	
	while(bullet_Top <= 390 && bullet_Left <= 590)
	{
		bullet = document.createElement("div");
		bullet.appendChild(document.createTextNode("*"));
		bullet_Top -= Bullet.getRevisedVerticalDistance();
		bullet_Left += 8;
		bullet.style.top = bullet_Top + 'px';
		bullet.style.left = bullet_Left + 'px';
		bullet.style.position = 'absolute';
		
		backGround.appendChild(bullet);
	}
}