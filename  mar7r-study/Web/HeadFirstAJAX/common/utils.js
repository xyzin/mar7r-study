function createRequest() {
  try {
    request = new XMLHttpRequest();
  } catch (tryMS) {
    try {
      request = new ActiveXObject("Msxml2.XMLHTTP");
    } catch (otherMS) {
      try {
        request = new ActiveXObject("Microsoft.XMLHTTP");
      } catch (failed) {
        request = null;
      }
    }
  }	
  return request;
}

function addEventHandler(obj, eventName, handler) {
	if (document.addEventListener)
	{
		obj.addEventListener(eventName, handler, false);
	} else if (document.attachEvent) {
		obj.attachEvent('on'+eventName, handler);
	}
}

function getActivatedObject(e) {
	var obj;
	
	if (!e)
		obj = window.event.srcElement;
	else if (e.srcElement)
		obj = e.srcElement;
	else
		obj = e.target;
		
	return obj;
}

Array.prototype.indexof = function(obj) {
	var result = -1;
	for (var i=0; i<this.length; i++)
	{
		if (this[i] == obj)
		{
			result = i;
			break;
		}
	}
	return result;
};

Array.prototype.contains = function(obj) {
	return (this.indexof(obj) > 0);
}

Array.prototype.append = function(obj, nodup) {
	if (!(nodup && this.contains(obj)))
	{
		this[this.length] = obj;
	}
};

Array.prototype.remove = function(obj) {
	if (this.contains(obj))
	{
		for (var i=this.indexof(obj); i<this.length-1; i++)
		{
			this[i] = this[i+1];
		}
		this[this.length] = null;
	}
};


var jsEvent = new Array();
jsEvent.EventRouter = function(element, eventType) {
	this.listeners = new Array();
	this.element = element;
	element.eventRouter = this;
	element[eventType] = jsEvent.EventRouter.callback;
}

jsEvent.EventRouter.prototype.addListener = function(listener) {
	this.listeners.append(listener, true);
}

jsEvent.EventRouter.prototype.removeListener = function(listener) {
	this.listeners.remove(listener);
}

jsEvent.EventRouter.prototype.notify = function(event) {
	var listeners = this.listeners;
	for (var i=0; i<listeners.length; i++)
	{
		var listener = listeners[i];
		listener.call(this, event)
	}
}

jsEvent.EventRouter.callback = function(event) {
	var e = event || window.event;
	var router = this.eventRouter;
	router.notify(event);
}
