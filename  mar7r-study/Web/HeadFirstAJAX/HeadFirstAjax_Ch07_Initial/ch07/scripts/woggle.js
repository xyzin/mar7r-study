window.onload = initPage;

var lettersTable = new Array(
'a','a','a','a','a','a','a','a',
'b',
'c','c','c',
'd','d','d',
'e','e','e','e','e','e','e','e','e','e','e','e',
'f','f',
'g','g',
'h','h','h','h','h','h',
'i','i','i','i','i','i','i',
'j',
'k',
'l','l','l','l',
'm','m',
'n','n','n','n','n','n',
'o','o','o','o','o','o','o','o',
'p','p',
'q','q','q','q','q','q',
'r','r','r','r','r','r',
's','s','s','s','s','s','s','s',
't','t','t',
'u','u',
'v','v',
'w',
'x',
'y','y',
'z'
);

var inputLetters = '';

function initPage() {
	randomizeTiles();
}

function randomizeTiles() {
	var tiles = document.getElementById('letterbox').getElementsByTagName('A');
	for (var i=0; i<tiles.length; i++)
	{
		var randomNumberForLetter = Math.floor(Math.random()*100);
		tiles[i].className = tiles[i].className + ' l' + lettersTable[randomNumberForLetter];
		enableButton(tiles[i]);
	}
}

function enableButton(obj) {
	obj.onclick = addLetter;
}

function addLetter() {
	var tileClasses = this.className.split(' ');
	var letterClass = tileClasses[2];
	var tileLetter = letterClass.substr(1);
	
	var currentWord = document.getElementById('currentWord');

	if (currentWord.childNodes.length == 0)
	{
		var p = document.createElement('p');
		var letterText = document.createTextNode(tileLetter);
		p.appendChild(letterText);
		currentWord.appendChild(p);
		inputLetters = letterText;
		
		enableSubmit();
	} else {
		var p = currentWord.firstChild;
		var letterText = p.firstChild;
		letterText.nodeValue += tileLetter;
		inputLetters = letterText.nodeValue;
	}
	
	disableButton(this);
}

function disableButton(obj) {
	obj.className += ' disabled';
	obj.onclick = '';
}

function submit() {
	var request = createRequest();
	
	var url = 'lookup-word.php?word=' + escape(inputLetters);
	request.open("GET", url, false);
	request.send(null);
	
	var result = request.responseText;
	
	if (result == '-1')
		alert("invalid word, try again");
	else {
		var wordList = document.getElementById('wordList');
		var p = document.createElement('p');
		var correctWord = document.createTextNode(inputLetters);
		
		p.appendChild(correctWord);
		wordList.appendChild(p);
		
		setScore(result);
	}
	
	enableTiles();
	clearText();
	disableSubmit();
}

function setScore(point) {
	var score = document.getElementById('score');
	var scoreTextNode = score.firstChild;
	var scoreStrings = scoreTextNode.nodeValue.split(':');
	var currentScore = Number(scoreStrings[1]);
	var newScore = currentScore + Number(point);
	scoreTextNode.nodeValue = "Score : " + newScore; 
}

function enableTiles() {
	var tiles = document.getElementById('letterbox').getElementsByTagName('A');
	for (var i=0; i<tiles.length; i++)
	{
		var classes = tiles[i].className.split(' ');
		if (classes.length == 4)
			classes[3] = '';
			
		tiles[i].className = classes.join(' ').trim();
		tiles[i].onclick = addLetter;
	}
}

function clearText() {
	var currentWord = document.getElementById('currentWord');
	var p = currentWord.firstChild;
	if (p)
	{
		currentWord.removeChild(p);
	}

	inputLetters = '';
}

function enableSubmit() {
	var submitDiv = document.getElementById('submit');
	var a = submitDiv.firstChild;
	while (a.nodeName == '#text')
	{
		a = a.nextSibling;
	}
	a.onclick = submit;
}

function disableSubmit() {
	var submitDiv = document.getElementById('submit');
	var a = submitDiv.firstChild;
	while (a.nodeName == '#text')
	{
		a = a.nextSibling;
	}
	a.onclick = '';
}