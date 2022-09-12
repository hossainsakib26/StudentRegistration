class acadClass {
    //token = null;
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
    tokenData = $('input[name=__RequestVerificationToken]').val();
    codeData = getInputCode.value;
    nameData = getInputName.value;

    console.log(tokenData);

    let acadClassData = setAcadClassValue(tokenData, codeData, nameData);
    let objJson = JSON.stringify(acadClassData);

    console.log(objJson);

    let typeMethod = "POST";
    let requestUrl = baseUrl + "Create?obj=" + acadClassData +"";
    //let requestURL = baseUrl + "Create";

    //callAjax(typeMethod, requestURL, acadClassData);
    callAjax(typeMethod, requestUrl, acadClassData);

}

function callAjax(rqstType, rqstUrl, objData) {

    xmlHttpRqst = new XMLHttpRequest();

    xmlHttpRqst.open(rqstType, rqstUrl, true);
    
    xmlHttpRqst.send(objData);

    xmlHttpRqst.onload = getResponses;

    function getResponses() {

        console.log(this.readyState);
        console.log(this.status);

        if (this.readyState === XMLHttpRequest.DONE && this.status === 201) {
            // Get and convert the responseText into JSON
            var response = JSON.parse(xmlHttpRqst.responseText);
            console.log(response);
        }

    }    
}



function setAcadClassValue(data1, data2, data3) {

    let classData = new acadClass();
    //classData.token = data1;
    classData.code = data2;
    classData.name = data3;

    console.log(classData);
    return classData;
}
