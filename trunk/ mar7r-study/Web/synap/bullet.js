function Bullet(degree, velocity) {
	this.left = 0;
	this.top = 390;
	this.degree = degree;
	this.velocity = velocity;
	this.secondForMoving8px = 0.8 / this.getHorizontalVelocity();
	this.currentVerticalUnit = this.getVerticalDistanceForPixelUnit();
};
Bullet.prototype.getHorizontalVelocity = function() {
	return commonUtil.Round(this.velocity * commonUtil.getCos(this.degree));
};
Bullet.prototype.getVerticalVelocity = function() {
	return commonUtil.Round(this.velocity * commonUtil.getSin(this.degree));
};
Bullet.prototype.getVerticalDistanceForPixelUnit = function() {
	return commonUtil.Round(this.getVerticalVelocity() * this.secondForMoving8px * 10);
};
Bullet.prototype.getHorizontalDistanceForPixelUnit = function() {
	return commonUtil.Round(this.getHorizontalVelocity() * this.secondForMoving8px* 10);
};
Bullet.prototype.getRevisedVerticalUnit = function() {
	return this.currentVerticalUnit - 9.8 * this.secondForMoving8px;
};
Bullet.prototype.setNewVerticalUnit = function(distance) {
	this.currentVerticalUnit = distance;
};
Bullet.prototype.getTop = function() {
	return this.top;
};
Bullet.prototype.getLeft = function() {
	return this.left;
};
Bullet.prototype.doNext = function() {
	this.left += 8;
	var distance = this.getRevisedVerticalUnit();
	this.setNewVerticalUnit(distance);
	this.top -= Math.round(distance);	
};
Bullet.prototype.useful = function() {
	return this.left + 8 < 600 &&
		this.top - Math.round(this.getRevisedVerticalUnit()) < 400;
};
Bullet.prototype.isVisible = function() {
	return this.top > 8;
};