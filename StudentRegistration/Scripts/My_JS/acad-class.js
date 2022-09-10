class acadClass {
    id = 0;
    code = "";
    name = "";
}

var xmlHttpRqst;

var getSubmitBtn = document.getElementById("submitBtn");
var getLabelCode = document.getElementById("CodeLbl");
var getInputCode = document.getElementById("Code");
var getLabelName = document.getElementById("NameLbl");
var getInputName = document.getElementById("Name");
var getFormValue = document.getElementById("createBeginForm");

function setAcadClassValue() {

    var classData = new acadClass (
        id = 0,
        code = getInputCode.value,
        name = getInputName.value,
    );

    console.log(classData);
}

var baseUrl = "/AcadClass"

getSubmitBtn.addEventListener("click", submitForm);


function submitForm() {
    setAcadClassValue();
}

function getValue() {

}
