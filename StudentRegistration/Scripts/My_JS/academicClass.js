function fnSuccess(obj) {
    if (obj.Code !== "" && obj.Name !== "") {
        var msgData = document.getElementById("getMessage");
        msgData.innerText = "" + obj.Code + " & " + obj.Name + " is added successfully!";
        msgData.setAttribute("class", "col-lg-8 text-center text-light bg-success");

    } else {
        return;
    }
}

function fnFailure() {
    var msgData = document.getElementById("getMessage");
    msgData.innerText = "Wouldn't send to controller action.";
    msgData.setAttribute("class", "text-light bg-danger");
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
        fnSuccess(data);
    }

    return null;
}


document.getElementById("Code").addEventListener("change", getCodeValue);

var xmlHttpRequest;
function getCodeValue() {
    console.log(this.value);

    const classCode = document.getElementById("Code").value;
    const codeLabel = document.getElementById("code");

    const url = "https://localhost:44383/AcademicClass/IsExistsCode?code="+classCode+"";

    xmlHttpRequest = new XMLHttpRequest();
    
    xmlHttpRequest.open("GET", url, true);

    xmlHttpRequest.onreadystatechange = responseData;
    
    xmlHttpRequest.send();

    function responseData() {
        if (this.readyState === xmlHttpRequest.DONE && this.status === 200) {
            console.log(this.value);

            xmlHttpRequest.onload = () => {
                console.log(this.status);
                console.log(this.readyState);
                const data = xmlHttpRequest.response;
                console.log(JSON.stringify(data));
                codeLabel.innerText = "Code";

                codeLabel.innerText = (data === "True")
                    ? ("Code " + classCode + " is exists")
                    : ("Code " + classCode + " is available");

                (data === "True")
                    ? (codeLabel.setAttribute("class", "text-danger"))
                    : (codeLabel.setAttribute("class", "text-success"));

            }
        }
        
    }

}


document.getElementById("clearForm").addEventListener("click", clearValues);

function clearValues() {
    document.getElementById("Code").value = "";
    document.getElementById("Name").value = "";
    document.getElementById("code").innerText = "Code";
    document.getElementById("code").setAttribute("class", "text-light");
    var msgData = document.getElementById("getMessage");
    msgData.innerText = "";
    msgData.setAttribute("class", "");
}

