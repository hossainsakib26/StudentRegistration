var msgTextElement = document.getElementById("msgText");

var getLabelCode = document.getElementById("CodeLbl");
var getInputCode = document.getElementById("Code");
var getLabelName = document.getElementById("NameLbl");
var getInputName = document.getElementById("Name");

var getSubmitBtn = document.getElementById("submitBtn");

getInputCode.addEventListener("change", checkCode);
getInputName.addEventListener("change", checkNameTuple);

var xmlHttpRqst;

var baseUrl = "/AcadClass/";

function checkCode() {
    let inputtedCode = getInputCode.value;
    const fieldName = "code";
    let backendMethodName = "IsCodeExists";
    if (inputtedCode !== null) {
        callAjax(inputtedCode, fieldName, backendMethodName);
    }
}

function checkName() {
    let inputtedName = getInputName.value;
    const fieldName = "name";
    let backendMethodName = "IsNameExists";
    if (inputtedName !== null) {
        callAjax(inputtedName, fieldName, backendMethodName);
    }
}

function checkNameTuple() {
    let inputtedName = getInputName.value;
    const fieldName = "name";
    let backendMethodName = "IsNameExistsTuple";
    if (inputtedName !== null) {
        callAjax(inputtedName, fieldName, backendMethodName);
    }
}

function callAjax(data, fieldName, backendMethod) {

    xmlHttpRqst = new XMLHttpRequest();
    let url = baseUrl + backendMethod + "?" + fieldName + "=" + data + "";
    xmlHttpRqst.open("GET", url, true);
    xmlHttpRqst.onreadystatechange = backendResponse;
    xmlHttpRqst.send();

}

function backendResponse() {

    if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
        const data = this.response;
        console.log(data);
    }

}

