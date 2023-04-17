function validate1() {
    var lname = document.getElementById("fname").value;
    var fname = document.getElementById("fname").value;
    var username = document.getElementById("username").value;
    let password = document.getElementById("password").value;
    let length = password.length;
    var userid = document.getElementById("userid").value;
    var male = document.getElementById("male").checked;
    var female = document.getElementById("female").checked;
    var fav1 = document.getElementById("fav1").checked;
    var fav2 = document.getElementById("fav2").checked;
    var fav3 = document.getElementById("fav3").checked;


    console.log(username);
    var errMsg = "";
    var result = true;

    if (fname == "") {
        errMsg += "First name cant not be empty.\n";

    }
    else if (!isNaN(fname)) {
        errMsg += "First name can not be a number.\n";
    }

    if (lname == "") {
        errMsg += "Last name can not not be empty.\n";

    }
    else if (!isNaN(lname)) {
        errMsg += "Last name can not be a number.\n";
    }

    if (username == "") {
        errMsg += "User name can not be empty.\n";
    } ""
    if (password == "") {
        errMsg += "Password can not be empty\n";

    }
    else if (length <= 8) {
        errMsg += "Password must have at least 8 characters\n";
    }
    if (male || female) {
    }
    else {
        errMsg += "Please select your gender \n";
    }
    if (fav1 || fav2 || fav3) { }
    else {
        errMsg += "Please check your favorite taco\n";
    }

    if (errMsg != "") {
        alert(errMsg);
        result = false;
    }
    else {
        var choice = confirm("Login successfully!!!\n\n" + fname + " " + lname
            + "\n" + username + "\n" + userid + "\n");
    }
    return result;
}
function init1() {
    var regForm = document.getElementById("regform");
    regForm.onsubmit = validate1;
}
window.onload = init1;
