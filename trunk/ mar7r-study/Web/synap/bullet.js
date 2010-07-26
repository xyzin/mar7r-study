var Bullet = {
	degree : 0,
	velocity : 0,
	secondForMoving8px : 0,
	currentHorizontalVelocity : 0,
	init : function(degree, velocity) {
		this.degree = degree;
		this.velocity = velocity;
		this.secondForMoving8px = 0.8 / Bullet.getHorizontalVelocity();
		this.currentHorizontalVelocity = Bullet.getNewHorizontalDistance();
	},
	getVerticalVelocity : function() {
		return this.velocity * commonUtil.getSin(this.degree);
	},
	getHorizontalVelocity : function() {
		return this.velocity * commonUtil.getCos(this.degree);
	},
	getNewVerticalDistance : function() {
		return Bullet.getVerticalVelocity() * this.secondForMoving8px * 10;
	},
	getNewHorizontalDistance : function() {
		return Bullet.getHorizontalVelocity() * this.secondForMoving8px * 10;
	},
	getRevisedVerticalDistance: function() {
		var ret = this.currentHorizontalVelocity - 9.8 * this.secondForMoving8px;
		this.currentHorizontalVelocity = ret;
		return Math.round(ret);
	}
};