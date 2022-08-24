function fnSuccess() {
    if (data !== null) {
        alert("" + data.Code + " & " + data.Name + " is added successfully!");
    } else {
        return;
    }

}

function fnFailure() {
    alert("Wouldn't send to controller action.");
}

document.getElementById("submitForm").addEventListener("click", BtnClick);
var data;
function BtnClick() {

    var code = document.getElementById("Code").value;
    var name = document.getElementById("Name").value;

    if (code !== null && name !== null) {
        data = {
            Code: code,
            Name: name
        }
        return data;
    }

    return null;
}