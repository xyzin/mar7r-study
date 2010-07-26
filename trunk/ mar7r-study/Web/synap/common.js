var commonUtil = {};

commonUtil.getRadian = function(degree) {
	return degree / 180 * Math.PI;
};
commonUtil.getSin = function(degree) {
	return Math.sin(commonUtil.getRadian(degree));
};
commonUtil.getCos = function(degree) {
	return Math.cos(commonUtil.getRadian(degree));
};
commonUtil.Round = function(value) {
	return Math.round(value * 100) / 100;
};