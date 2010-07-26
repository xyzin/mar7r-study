function Target() {
	this.left = Math.round(Math.random() * 300 + 300);
	this.top = 390;
};
Target.prototype.getLeft = function() {
	return this.left;
};
Target.prototype.getTop = function() {
	return this.top;
};