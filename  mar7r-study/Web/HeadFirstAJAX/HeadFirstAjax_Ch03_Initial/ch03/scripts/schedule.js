window.onload = initPage;
var welcomePaneShowing = true;


function initPage() {
	var tabs = document.getElementById('schedulePane').getElementsByTagName('A');
	for (var i=0; i<tabs.length; i++)
	{
		var currentTab = tabs[i];
		addEventHandler(currentTab, 'mouseover', showHint);
		addEventHandler(currentTab, 'mouseout', hideHint);
		addEventHandler(currentTab, 'click', showTab);
	}
	
	var buttons = document.getElementById('navigation').getElementsByTagName('A');
	for (var i=0; i<buttons.length; i++)
	{
		var currentBtn = buttons[i];
		addEventHandler(currentBtn, 'mouseover', buttonOver);
		addEventHandler(currentBtn, 'mouseout', buttonOut);
	}
}

function showHint(e) {
	if (!welcomePaneShowing)
		return;
		
	var activeObj = getActivatedObject(e);
		
	switch (activeObj.title) {
	case "beginners":
		var hintText = "Just getting started? Come join us!";
		break;
	case "intermediate":
		var hintText = "Take your flexibility to the next level!";
		break;	
	case "advanced":
		var hintText = "Perfectly join your body and mind with these intensive workouts.";
		break;	
	default:
		var hintText = "Click a tab to display the course schedule for the class";
	}
	
	var contentPane = document.getElementById('content');
	contentPane.innerHTML = '<h3>' + hintText + '</h3>';
}

function hideHint(e) {
//	alert('in hideHint()');
	if (welcomePaneShowing)
	{
		var contentPane = document.getElementById('content');
		contentPane.innerHTML = '<h3>Click a tab to display the course schedule for the class</h3>'
	}
}

function showTab(e) {
	var activeObj = getActivatedObject(e);
	
	var selectedTab = activeObj.title;
	setWelcomePaneShowing(selectedTab);
	
	var tabs = document.getElementById('tabs').getElementsByTagName('A');
	for (var i=0; i<tabs.length; i++)
	{
		var currentTab = tabs[i];
		if (currentTab.title == selectedTab)
		{
			currentTab.className = 'active';
		} else {
			currentTab.className = 'inactive';
		}
	}
	
	var request = createRequest();
	if (request == null)
	{
		alert("Unable to create request");
		return;
	}
	
	request.onreadystatechange = showSchedule;
	request.open("GET", selectedTab + ".html", true);
	request.send(null);
}

function setWelcomePaneShowing(tabTitle) {
	if (tabTitle == 'welcome')
		welcomePaneShowing = true;
	else
		welcomePaneShowing = false;	
}

function showSchedule() {
	if (request.readyState == 4)
		if (request.status == 200)
			document.getElementById('content').innerHTML = request.responseText;
}

function buttonOver(e) {
	var activeObj = getActivatedObject(e);
	activeObj.className = 'active';
}

function buttonOut(e) {
	var activeObj = getActivatedObject(e);
	activeObj.className = '';
}