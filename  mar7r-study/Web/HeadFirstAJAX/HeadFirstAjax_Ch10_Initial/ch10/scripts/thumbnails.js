window.onload = initPage;

function initPage() {
  // find the thumbnails on the page
  var thumbs = 
    document.getElementById("thumbnailPane").getElementsByTagName("img");

  // set the handler for each image
  for (var i = 0; i < thumbs.length; i++) {
    var image = thumbs[i];
    
    // create the onclick function
    image.onclick = function() {
      // find the image name
      var detailURL = 'images/' + this.title + '-detail.jpg';
      document.getElementById("itemDetail").src = detailURL;
      getDetails(this.title);
    }
  }
}

function getDetails(itemName) {
  request = createRequest();
  if (request == null) {
    alert("Unable to create request");
    return;
  }
  // Version for XML server-side script
  var url= "getDetailsJSON.php?ImageID=" + escape(itemName);
  request.open("GET", url, true);
  request.onreadystatechange = displayDetails;
  request.send(null);
}

function displayDetails() {
  if (request.readyState == 4) {
    if (request.status == 200) {
      var detailDiv = document.getElementById("description");

      // Remove existing item details (if any)
      for (var i=detailDiv.childNodes.length; i>0; i--) {
        detailDiv.removeChild(detailDiv.childNodes[i-1]);
      }

			var itemDetails = JSON.parse(request.responseText);
			
			for (var property in itemDetails)
			{
				var value = itemDetails[property];
				if (isArray(value))
				{
					var ul = document.createElement('ul');
					for (var i=0; i<value.length; i++)
					{
						var li = document.createElement('li');
						var textNode = document.createTextNode(value[i]);
						li.appendChild(textNode);
						ul.appendChild(li);
					}
					detailDiv.appendChild(ul);
				} else {
					var p = document.createElement('p');
					var textNode = document.createTextNode(property + ' : ' + value);
					p.appendChild(textNode);
					detailDiv.appendChild(p);
				}
			}
	  }
  }
}

function isArray(arg) {
	if (typeof arg == 'object')
	{
		var criteria = arg.constructor.toString().match(/array/i);
		return (criteria != null);
	}
	return false;
}