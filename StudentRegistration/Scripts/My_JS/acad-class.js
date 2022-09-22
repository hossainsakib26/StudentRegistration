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
var getLabelCode = document.getElementById("CodeLbl");
var getInputCode = document.getElementById("Code");
var getLabelName = document.getElementById("NameLbl");
var getInputName = document.getElementById("Name");
var getFormValue = document.getElementById("createBeginForm");
var msgDiv = document.getElementById("msg");
var msgTextElement = document.getElementById("msgText");
var contentPage = document.getElementById("createContent");

var getSubmitBtn = document.getElementById("submitBtn");

getSubmitBtn.addEventListener("click", submitForm);

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

var successDesign = ["text-success", "fs-5", "fw-normal"];
var failedDesign = ["text-danger", "fs-5", "fw-normal"];

function getResponses() {

    console.log("Ready State: ", this.readyState);
    console.log("Status: ", this.status);

    if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
        msgDiv.classList.add(...successDesign);
        msgTextElement.textContent = "Data added Successfully!";
    } else {
        msgDiv.classList.add(...failedDesign);
        msgTextElement.textContent = "Data added operation has been failed!";
    }

}

function setAcadClassValueWithToken() {
    
    let classData = new AcadClass();
    classData.code = getInputCode.value;
    classData.name = getInputName.value;
    classData.__RequestVerificationToken = getToken.value;

    console.log("Class Object: ", classData);
    return classData;
}
