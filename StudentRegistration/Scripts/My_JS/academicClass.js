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

document.getElementById("Code").addEventListener("change", getCodeValue);

var xmlHttpRequest;
function getCodeValue() {
    console.log(this.value);

    const classCode = document.getElementById("Code").value;

    const url = "https://localhost:44383/AcademicClass/ExistsCode?code="+classCode+"";

    xmlHttpRequest = new XMLHttpRequest();
    
    xmlHttpRequest.open("GET", url, true);

    //xmlHttpRequest.onreadystatechange = responseData;

    xmlHttpRequest.onload = () => {
        console.log(this.status);
        console.log(this.readyState);
        const data = xmlHttpRequest.response;
        console.log(JSON.stringify(data));
    }

    xmlHttpRequest.send();

    function responseData() {
        console.log(this.value);
    }

}
