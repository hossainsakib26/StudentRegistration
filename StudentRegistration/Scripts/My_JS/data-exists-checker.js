var msgTextElement = document.getElementById("msgText");

var getLabelCode = document.getElementById("CodeLbl");
var getInputCode = document.getElementById("Code");
var getLabelName = document.getElementById("NameLbl");
var getInputName = document.getElementById("Name");

var getSubmitBtn = document.getElementById("submitBtn");

getInputCode.addEventListener("change", checkCode);
getInputName.addEventListener("change", checkName);

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

        let isCodeOk;
        let isNameOk;

        if (fieldName === "name") {
            afterHttpRqstEffect(fieldName, xmlRqst.response, getLabelName);
            (xmlRqst.response === "True") ? (isNameOk = false) : (isNameOk = true);
        }

        if (fieldName === "code") {

            afterHttpRqstEffect(fieldName, xmlRqst.response, getLabelCode);
            (xmlRqst.response === "True") ? (isCodeOk = false) : (isCodeOk = true);
        }
        (isCodeOk === true && isNameOk === true)? (getSubmitBtn.isDisabled = true): (getSubmitBtn.isDisabled = false);
    }
}

function afterHttpRqstEffect(fieldName, response, targatElement) {

    targatElement.innerText = ""+fieldName+"";
    (response === "True")
        ? (targatElement.setAttribute("class", "bi bi-x-circle text-danger"))
        : (targatElement.setAttribute("class", "bi bi-check-circle text-success"));

    targatElement.innerText = (response === "True") ? (" "+fieldName+" is exists") : (" "+fieldName+" is available");
}
