class AcadClass {
    id = 0;
    code = "";
    name = "";
    __RequestVerificationToken = "" | null;
}

var xmlHttpRqst;
var baseUrl = "/AcadClass/";

//catch a field without id, class and tag name
var getToken = document.querySelector("input[name=__RequestVerificationToken]");

var getInputCode = document.getElementById("Code");
var getInputName = document.getElementById("Name");
var getLabelCode = document.getElementById("CodeLbl");
var getLabelName = document.getElementById("NameLbl");


var getFormValue = document.getElementById("createBeginForm");

var msgDiv = document.getElementById("msg");
var msgTextElement = document.getElementById("msgText");

var contentPage = document.getElementById("createContent");

var getSubmitBtn = document.getElementById("submitBtn");

getSubmitBtn.addEventListener("click", submitForm);

var successDesign = ["text-success", "fs-5", "fw-normal"];
var failedDesign = ["text-danger", "fs-5", "fw-normal"];

msgDiv.classList.add(...successDesign);

function submitForm() {

    // return a object
    let acadClassData = setAcadClassValueWithToken();
    // make it string json
    let objJson = JSON.stringify(acadClassData);

    // make a querystring parameter
    let urlQueryString = new URLSearchParams(acadClassData).toString();

    console.log("JSON Stringify: ", objJson);
    console.log("Query String: ", urlQueryString);

    let typeMethod = "POST";

    let requestUrl = baseUrl + "Create";

    //for sending json data but it works with antyforgerytoken.
    requestAjax(typeMethod, requestUrl, urlQueryString);
    //for sending json data but it didnt work with antyforgerytoken. 
    //requestAjax(typeMethod, requestUrl, objJson); 

}

function requestAjax(methodType, rqstUrl, objData) {

    xmlHttpRqst = new XMLHttpRequest();

    xmlHttpRqst.open(methodType, rqstUrl, true);

    //add this when you need to submit a form data.
    xmlHttpRqst.setRequestHeader("Content-type", "application/x-www-form-urlencoded; charset=utf-8");

    //this header is only using for json data.
    //xmlHttpRqst.setRequestHeader("Content-type", "application/json");

    (methodType === "POST" && objData) ? xmlHttpRqst.send(objData) : xmlHttpRqst.send();

    xmlHttpRqst.onload = getResponses;

}

function getResponses() {

    console.log("Ready State: ", this.readyState);
    console.log("Status: ", this.status);
    console.log("Response: ", this.response);
    var data = JSON.parse(this.response);
    console.log("Json Parse Response: ", data);
    msgTextElement.textContent = null;
    msgDiv.classList.remove(...successDesign);
    msgDiv.classList.remove(...failedDesign);
    if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
        
        if (data.acadClass.ID > 0) {
            msgDiv.classList.add(...successDesign);
            msgTextElement.textContent = "" + data.acadClass.Code + " added Successfully! and it's id is " + data.acadClass.ID + "";
        }
        if (data.acadClass.ID === 0) {
            msgDiv.classList.add(...failedDesign);
            msgTextElement.textContent = "Data added operation has been failed!"
            if (data.codeExists === true && data.nameExists === false) {
                controlLabel(getLabelCode, "code", this.response);
            }
            if (data.nameExists === true && data.codeExists === false) {
                controlLabel(getLabelName, "name", this.response);
            }
            if (data.nameExists === true && data.codeExists === true) {
                controlLabel(getLabelCode, "code", this.response);
                controlLabel(getLabelName, "name", this.response);
            }
        }

    }
}

function controlLabel(targatElement, fieldName, xttpResponse) {
    targatElement.innerText = "" + fieldName + "";
    (xttpResponse !== null)
        ? (targatElement.setAttribute("class", "fs-5 bi bi-x-circle text-danger"))
        : (targatElement.setAttribute("class", "fs-5 bi bi-check-circle text-success"));

    targatElement.innerText = (xttpResponse !== null) ? (" " + fieldName + " is exists") : (" " + fieldName + " is available");
}

function setAcadClassValueWithToken() {

    let classData = new AcadClass();
    classData.code = getInputCode.value;
    classData.name = getInputName.value;
    classData.__RequestVerificationToken = getToken.value;

    console.log("Class Object: ", classData);
    return classData;
}
