var msgTextElement = document.getElementById("msgText");

var getLabelCode = document.getElementById("CodeLbl");
var getInputCode = document.getElementById("Code");
var getLabelName = document.getElementById("NameLbl");
var getInputName = document.getElementById("Name");

var getSubmitBtn = document.getElementById("submitBtn");

getInputCode.addEventListener("change", checkCode);
getInputName.addEventListener("change", checkName);

let isCodeOk;
let isNameOk;

var xmlHttpRqst;

var baseUrl = "/AcadClass/";

function checkCode() {
    let inputtedCode = getInputCode.value;
    if (inputtedCode !== null) {
        callAjax(inputtedCode, "code", "IsCodeExists");
    }
}

function checkName() {
    let inputtedName = getInputName.value;
    if (inputtedName !== null) {
        callAjax(inputtedName, "name", "IsNameExists");
    }
}

//will working with tuple letter
function checkNameTuple() {
    let inputtedName = getInputName.value;
    if (inputtedName !== null) {
        callAjax(inputtedName, "name", "IsNameExistsTuple");
    }
}

function callAjax(data, fieldName, backendMethod) {

    xmlHttpRqst = new XMLHttpRequest();
    let url = baseUrl + backendMethod + "?" + fieldName + "=" + data + "";
    xmlHttpRqst.open("GET", url, true);
    xmlHttpRqst.onreadystatechange = () => {
        backendResponse(fieldName, xmlHttpRqst);
    };
    xmlHttpRqst.send();
}

function backendResponse(fieldName, xmlRqst) {
    if (xmlRqst.readyState === XMLHttpRequest.DONE && xmlRqst.status === 200) {

        console.log(xmlRqst.response);

        (fieldName === "name") ? afterHttpRqstEffect(fieldName, xmlRqst.response, getLabelName)
            : (xmlRqst.response === "False") ? (isNameOk = true) : (isNameOk = false);
        
        (fieldName === "code") ? afterHttpRqstEffect(fieldName, xmlRqst.response, getLabelCode)
            : (xmlRqst.response === "False") ? (isCodeOk = true) : (isCodeOk = false);
        
        (isCodeOk === true && isNameOk === true) ? (getSubmitBtn.disabled = false): (getSubmitBtn.disabled = true);
    }
}

function afterHttpRqstEffect(fieldName, response, targatElement) {

    targatElement.innerText = ""+fieldName+"";
    (response === "True")
        ? (targatElement.setAttribute("class", "fs-5 bi bi-x-circle text-danger"))
        : (targatElement.setAttribute("class", "fs-5 bi bi-check-circle text-success"));

    targatElement.innerText = (response === "True") ? (" "+fieldName+" is exists") : (" "+fieldName+" is available");
}
