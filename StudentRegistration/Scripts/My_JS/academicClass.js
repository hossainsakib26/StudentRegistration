﻿
function fnSuccess(obj) {
    if (obj.Code !== "" && obj.Name !== "") {
        var msgData = document.getElementById("getMessage");
        msgData.setAttribute("class", "col-lg-8 text-center text-light bg-success");
        msgData.innerText = "" + obj.Code + " & " + obj.Name + " is added successfully!";

    } else {
        return;
    }
}

function fnFailure() {
    var msgData = document.getElementById("getMessage");
    msgData.innerText = "Wouldn't send to controller action.";
    msgData.setAttribute("class", "col-lg-8 text-center text-light bg-danger");
}

document.getElementById("submitForm").addEventListener("click", BtnClick);

function BtnClick() {
    var data;
    var code = document.getElementById("Code").value;
    var name = document.getElementById("Name").value;

    if (code !== null && name !== null) {
        data = {
            Code: code,
            Name: name
        }
        //fnSuccess(data);
        //clearValues();
    }

    return null;
}


// using XMLHttpRequest
var xmlHttpRequest;
var baseURL = "https://localhost:44383/AcademicClass/";

document.getElementById("clearForm").addEventListener("click", clearValues);

function clearValues() {

    document.getElementById("submitForm").disabled = false;
    document.getElementById("Code").value = "";
    document.getElementById("Name").value = "";
    document.getElementById("code").innerText = "Code";
    document.getElementById("code").setAttribute("class", "text-light");
    document.getElementById("name").innerText = "Name";
    document.getElementById("name").setAttribute("class", "text-light");
    var msgData = document.getElementById("getMessage");
    msgData.innerText = "";
    msgData.setAttribute("class", "");

}

document.getElementById("Code").addEventListener("change", getCodeValue);

function getCodeValue() {
    //console.log(this.value);

    const classCode = document.getElementById("Code").value;
    const codeLabel = document.getElementById("code");

    if (this.value.length > 0) {

        const url = "https://localhost:44383/AcademicClass/IsExistsCode?code=" + this.value + "";

        xmlHttpRequest = new XMLHttpRequest();

        xmlHttpRequest.open("GET", url, true);

        xmlHttpRequest.onreadystatechange = responseData;

        xmlHttpRequest.send();

        function responseData() {
            if (this.readyState === xmlHttpRequest.DONE && this.status === 200) {

                xmlHttpRequest.onload = () => {
                    //console.log(this.status);
                    //console.log(this.readyState);
                    const data = xmlHttpRequest.response;
                    console.log(JSON.stringify(data));
                    codeLabel.innerText = "Code";

                    codeLabel.innerText = (data === "True")
                        ? ("Code " + classCode + " is exists")
                        : ("Code " + classCode + " is available");

                    (data === "True")
                        ? (codeLabel.setAttribute("class", "text-danger"))
                        : (codeLabel.setAttribute("class", "bi bi-check-circle text-success"));

                    var submitBtn = document.getElementById("submitForm");
                    (data === "True")
                        ? (submitBtn.disabled = true)
                        : (submitBtn.disabled = false);

                }
            }

        }


    }

}

document.getElementById("Name").addEventListener("change", getNameValue);

function getNameValue() {

    const className = document.getElementById("Name").value;
    const nameLabel = document.getElementById("name");

    const url = "https://localhost:44383/AcademicClass/IsExistsName?name=" + this.value + "";

    xmlHttpRequest = new XMLHttpRequest();

    xmlHttpRequest.open("GET", url, true);

    xmlHttpRequest.onreadystatechange = responseData;

    xmlHttpRequest.send();

    function responseData() {
        if (this.readyState === xmlHttpRequest.DONE && this.status === 200) {

            xmlHttpRequest.onload = () => {
                //console.log(this.status);
                //console.log(this.readyState);
                const data = xmlHttpRequest.response;
                console.log(JSON.stringify(data));
                nameLabel.innerText = "Code";

                nameLabel.innerText = (data === "True")
                    ? ("Name " + className + " is exists")
                    : ("Name " + className + " is available");

                (data === "True")
                    ? (nameLabel.setAttribute("class", "text-danger"))
                    : (nameLabel.setAttribute("class", "text-success"));

                var submitBtn = document.getElementById("submitForm");
                (data === "True")
                    ? (submitBtn.disabled = true)
                    : (submitBtn.disabled = false);

            }
        }

    }
}

document.getElementById("ajaxBeginFormForClass").addEventListener("submit", checkValidation);

function checkValidation() {


}