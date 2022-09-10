document.getElementById("addNewClassBtn").addEventListener("click", createPageUrl);

var xmlHttpRqst;
//function createPageUrl() {
//    xmlHttpRqst = new XMLHttpRequest();

//    const url = "/AcadClass/Create";

//    //window.location.href = "/AcadClass/Create";
//    xmlHttpRqst.open("GET", url, true);

//    xmlHttpRqst.onreadystatechange = responseUrl;

//    xmlHttpRqst.send();
//    var i = 1
//    function responseUrl() {

//        console.log(this.readyState, "" + i + "");
//        console.log(this.status, "" + i + "");
//        i++;
//        //window.history.pushState(null, null, "/AcadClass/Create");
//        //window.history.replaceState(null, null, "/AcadClass/Create");
//        //window.location.href = `@Url.Action("Create", "AcadClass")`;

//        var targetURL = "/AcadClass/Create";

//        window.location.href = targetURL;

//        window.location.assign(targetURL);
//        window.location.replace(targetURL);

//    }

    
//}

var i = 1;
function createPageUrl() {
    var targetURL = "/AcadClass/Create";
    window.location.href = targetURL;

    window.location.assign(targetURL);
    window.location.replace(targetURL);

    console.log("Call count: ", ++i);
}