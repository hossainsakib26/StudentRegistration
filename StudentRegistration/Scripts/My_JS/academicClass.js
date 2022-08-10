(function () {

    
    document.getElementById("createStd").addEventListener("click", createStudent);
    var codeText = document.getElementById("Code").value;
    var nameText = document.getElementById("Name").value;
    let httpRequest;

    function createStudent() {
        httpRequest = new XMLHttpRequest();

        if (!httpRequest) {
            alert("xmlHttpRequest instance not created");
            return false;
        }

        httpRequest.onreadystatechange = getStdData;
        
    }

    function getStdData() {
        //var codeText = document.getElementById("Code").value;
        //var nameText = document.getElementById("Name").value;

        if (codeText === "" || nameText === null) {
            return false;
        } else {
            var obj = {
                Code: codeText,
                Name: nameText
            }

            var workMethod = "POST";
            var objData = "codeJS=" + obj.Code + "&nameJS=" + obj.Name + "";
            var url = "Create.cshtml?" + objData + "";

            var pData = {
                WorkMethod: workMethod,
                requestURL: url
            }
            sendData(pData);
        }
    }


    function sendData(peramArray) {
        
        httpRequest.open(peramArray.WorkMethod, peramArray.requestURL, true);

        httpRequest.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

        httpRequest.send(null);
    }


})();