class acadClass {

    id = 0;
    code = "";
    name = "";

}

var xmlHttpRqst;

var getToken = document.getElementsByName("__RequestVerificationToken");
var getSubmitBtn = document.getElementById("submitBtn");
var getLabelCode = document.getElementById("CodeLbl");
var getInputCode = document.getElementById("Code");
var getLabelName = document.getElementById("NameLbl");
var getInputName = document.getElementById("Name");
var getFormValue = document.getElementById("createBeginForm");

//var baseUrl = "https://localhost:44383/AcadClass/";
var baseUrl = "/AcadClass/";

getSubmitBtn.addEventListener("click", submitForm);

function submitForm() {

    let codeData = getInputCode.value;
    let nameData = getInputName.value;

    
    let acadClassData = setAcadClassValue(codeData, nameData);
    let objJson = JSON.stringify(acadClassData);

    let urlQueryString = new URLSearchParams(acadClassData).toString();
    console.log(objJson);
    console.log(urlQueryString);

    let typeMethod = "POST";
    //let requestUrl = baseUrl + "Create?obj=" + acadClassData + "";
    //let requestUrl = baseUrl + "Create?obj=";
    let requestUrl = baseUrl + "Create";

    requestAjax(typeMethod, requestUrl, urlQueryString);
    //requestAjax(typeMethod, requestUrl, objJson);

}

function requestAjax(rqstType, rqstUrl, objData) {

    xmlHttpRqst = new XMLHttpRequest();

    xmlHttpRqst.open(rqstType, rqstUrl, true);

    xmlHttpRqst.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    //xmlHttpRqst.setRequestHeader("Content-type", "application/json");

    (rqstType === "POST" && objData) ? xmlHttpRqst.send(objData) : xmlHttpRqst.send();;

    xmlHttpRqst.onload = getResponses;

    function getResponses() {

        console.log(this.readyState);
        console.log(this.status);

        if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
            // Get and convert the responseText into JSON
            var response = JSON.parse(xmlHttpRqst.responseText);
            console.log(response);
        }

    }
}



function setAcadClassValue(data1, data2) {

    let classData = new acadClass();
    classData.code = data1;
    classData.name = data2;

    console.log(classData);
    return classData;
}
