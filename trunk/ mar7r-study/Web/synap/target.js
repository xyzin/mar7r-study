var Target = {
	position : 0,
	init : function() {
		this.position = Math.round(Math.random() * 300 + 300);
	},
	getPosition : function() {
		return this.position;
	}
};