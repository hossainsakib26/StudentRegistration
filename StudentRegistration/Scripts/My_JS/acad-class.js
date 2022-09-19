class acadClass {

    id = 0;
    code = "";
    name = "";
    __RequestVerificationToken = "" | null;
}

var xmlHttpRqst;

var baseUrl = "/AcadClass/";

var getToken = document.querySelector("input[name=__RequestVerificationToken]"); //get a field value without id, class and tag name
var getLabelCode = document.getElementById("CodeLbl");
var getInputCode = document.getElementById("Code");
var getLabelName = document.getElementById("NameLbl");
var getInputName = document.getElementById("Name");
var getFormValue = document.getElementById("createBeginForm");
var confirmationMsg = document.getElementById("msg");

var getSubmitBtn = document.getElementById("submitBtn");

getSubmitBtn.addEventListener("click", submitForm);

function submitForm() {

    // return a object
    let acadClassData = setAcadClassValueWithToken();
    // make it string json
    let objJson = JSON.stringify(acadClassData);

    // make a querystring parameter
    let urlQueryString = new URLSearchParams(acadClassData).toString(); 

    console.log(objJson);
    console.log(urlQueryString);

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

    console.log(this.readyState);
    console.log(this.status);

    if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
        confirmationMsg.textContent = "Data added Successfully!";
    } else {
        confirmationMsg.textContent = "Failed!";
    }

}

function setAcadClassValueWithToken() {
    
    let classData = new acadClass();
    classData.code = getInputCode.value;
    classData.name = getInputName.value;
    classData.__RequestVerificationToken = getToken.value;

    console.log(classData);
    return classData;
}
