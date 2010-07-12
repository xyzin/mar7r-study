window.onload = initPage;

function initPage() {  // find the thumbnails on the page  thumbs = document.getElementById("thumbnailPane").getElementsByTagName("img");  // set the handler for each image  for (var i = 0; i < thumbs.length; i++) {
    image = thumbs[i];
    
    // create the onclick function
    image.onclick = function() {
      // find the image name
      detailURL = 'images/' + this.title + '-detail.jpg';
      document.getElementById("itemDetail").src = detailURL;
      getDetails(this.title);
    }  }}

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
}function getDetails(itemName) {  request = createRequest();  if (request == null) {    alert("Unable to create request");    return;  }  var url= "getDetailsXML-updated.php?ImageID=" + escape(itemName);  request.open("GET", url, true);  request.onreadystatechange = displayDetails;  request.send(null);}
function displayDetails() {  if (request.readyState == 4) {    if (request.status == 200) {
		  var detailDiv = document.getElementById("description");
			clearDetailDiv(detailDiv);
			
			var xmlDocument = request.responseXML;
			var categories = xmlDocument.getElementsByTagName('category');
			
			for (var i=0; i<categories.length; i++)
			{
				var category = categories[i];
				var categoryName = category.getElementsByTagName('name')[0];
				var categoryNameValue = categoryName.firstChild.nodeValue;
				var categoryType = category.getAttribute('type');
				var values = category.getElementsByTagName('value');
				
				var p = document.createElement('p');
				if (categoryType == 'list')
				{
					var textNode = document.createTextNode(categoryNameValue + ' : ');
					var ul = document.createElement('ul');
					for (var j=0; j<values.length; j++)
					{
						var li = document.createElement('li');
						var categoryValue = values[j].firstChild.nodeValue;
						var textNodeForMultiValue = document.createTextNode(categoryValue);
						li.appendChild(textNodeForMultiValue);
						ul.appendChild(li);
					}
					p.appendChild(textNode);
					p.appendChild(ul);
				} else {
					var categoryValue = values[0].firstChild.nodeValue;
					var textNode = document.createTextNode(categoryNameValue + ' : ' + categoryValue);
					p.appendChild(textNode);
				}
				detailDiv.appendChild(p);
			}
    }  }}

function clearDetailDiv(obj) {
	var objChildren = obj.childNodes;
	for (var i=objChildren.length; i>0; i--)
	{
		var child = objChildren[i-1];
		obj.removeChild(child);
	}
}