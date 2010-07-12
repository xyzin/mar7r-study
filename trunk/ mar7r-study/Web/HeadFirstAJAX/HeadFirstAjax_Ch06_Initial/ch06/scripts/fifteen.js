window.onload = initPage;

function initPage() {
	var table = document.getElementById('puzzleGrid');
	var cells = table.getElementsByTagName('TD');
	for (var i=0; i<cells.length; i++)
	{
		//addEventHandler(cells[i], 'click', tileClick);
		cells[i].onclick = tileClick;
	}
}

function tileClick(e) {
	var clickedCell = this;//getActivatedObject(e);
	if (cellIsEmpty(clickedCell))
	{
		alert("Please click on a numbered tile.");
		return;
	}
	
	var emptyCell = getEmptyCell(clickedCell);
	if (emptyCell == null)
	{
		alert("Please click on a numbered tile next to a empty cell.");
		return;
	}
	swapTiles(clickedCell, emptyCell);
}

function getEmptyCell(clickedCell) {
	var currentRow = clickedCell.id.charAt(4);
	var currentCol = clickedCell.id.charAt(5);
	
	if (currentRow > 1)
	{
		var testCell = getTestCell(Number(currentRow) - 1, currentCol);
		if (cellIsEmpty(testCell))
			return testCell;
	}
	
	if (currentCol < 4)
	{
		var testCell = getTestCell(currentRow, Number(currentCol) + 1);
		if (cellIsEmpty(testCell))
			return testCell;
	}
	
	if (currentRow < 4)
	{
		var testCell = getTestCell(Number(currentRow) + 1, currentCol);
		if (cellIsEmpty(testCell))
			return testCell;
	}
	
	if (currentCol > 1)
	{
		var testCell = getTestCell(currentRow, Number(currentCol) - 1);
		if (cellIsEmpty(testCell))
			return testCell;
	}
	return null;
}

function getTestCell(row, col) {
	var cellId = 'cell' + row + col;
	return document.getElementById(cellId);
}

function cellIsEmpty(cell) {
	var image = cell.firstChild;
	while (image.nodeName == '#text')
	{
		image = image.nextSibling;
	}
	
	if (image.alt == 'empty')
		return true;
	else
		return false;
}

function swapTiles(selectedCell, destinationCell) {
	selectedImage = selectedCell.firstChild;
	while (selectedImage.nodeName == '#text')
	{
		selectedImage = selectedImage.nextSibling;
	}
	destinationImage = destinationCell.firstChild;
	while (destinationImage.nodeName == '#text')
	{
		destinationImage = destinationImage.nextSibling;
	}
	
	selectedCell.appendChild(destinationImage);
	destinationCell.appendChild(selectedImage);
	
	if (puzzleIsComplete())
	{
		document.getElementById('puzzleGrid').className = 'win';
	}
}

function puzzleIsComplete() {
	var tiles = document.getElementById('puzzleGrid').getElementsByTagName('IMG');
	var tileOrder = '';
	for (var i=0; i<tiles.length; i++)
	{
		if (tiles[i].alt == 'empty')
			continue;
		var num = tiles[i].src.substr(-6, 2);
		tileOrder += num;
	}
	if (tileOrder == '010203040506070809101112131415')
		return true;
	return false;
}