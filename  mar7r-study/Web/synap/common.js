var commonUtil = {};

commonUtil.getRadian = function(degree) {
	return Math.round(degree / 180 * Math.PI);
};
commonUtil.getSin = function(degree) {
	return Math.round(Math.sin(commonUtil.getRadian(degree)));
};
commonUtil.getCos = function(degree) {
	return Math.round(Math.cos(commonUtil.getRadian(degree)));
};