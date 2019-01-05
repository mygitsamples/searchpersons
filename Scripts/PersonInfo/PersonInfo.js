
function textupdate()
{
	var btnsearch = document.getElementById("btnSearch");
	var txtsearch = document.getElementById("txtSearch");
	if (txtsearch.value === "") {
		btnsearch.disabled = true;
	} else {
		btnsearch.disabled = false;
	}
}

function addPerson() {

	
	var firstname = document.getElementById("firstname");
	var lastname = document.getElementById("lastname");
	var gender = document.getElementById("gender");
	var state = document.getElementById("state");
	var dob = document.getElementById("dob");



}