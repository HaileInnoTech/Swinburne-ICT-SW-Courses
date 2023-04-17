function validates() {
    var fname = document.getElementById("fname").value;
    var lname = document.getElementById("lname").value;
    var phonenumber = document.getElementById("phonenumber").value;
    var address = document.getElementById("address").value;
    var namecard = document.getElementById("namecard").value;
    let text = document.getElementById("cardnumber").value;
    let length = text.length;
    var exdate = document.getElementById("exdate").value;
    var cvv = document.getElementById("cvv").value;


    var billingadd;
    var errMsg = "";
    var result = true;
    var method = "";
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

    if (phonenumber == "") {
        errMsg += "Phone number can not not be empty.\n";

    }
    else if (isNaN(phonenumber)) {
        errMsg += "Phone number must be a number.\n";
    }

    //if same as address is check, billing address will be the fill automatically
    if (document.getElementById("box").checked) {
    }
    else {
        billingadd = document.getElementById("billingaddress").value;
    }
    if (document.getElementById("box").checked && address == "") {
        errMsg += " Please enter your delivery address first\n";
    }
    // if choose delivery card information must be provided
    if (document.getElementById("delivery").checked) {
        if (document.getElementById("visa").checked ||
            document.getElementById("mastercard").checked
            || document.getElementById("AE").checked) {

        }
        else {
            errMsg += "A payment method must be chose\n";
        }

        if (text == "") {
            errMsg += "Card number must be provided\n";
        }
        if (exdate == "") {
            errMsg += "Expire date must be provided\n";
        }
        if (cvv == "") {
            errMsg += "CVV number must be provided\n";
        }
        if (namecard == "") {
            errMsg += "Holder name must be provided";
        }

    }

    //check the limit for card number
    if (document.getElementById("visa").checked || document.getElementById("mastercard").checked) {
        if (length >= 16 && !isNaN(text)) {
            errMsg += "Invalid number must have less than 16 digits for Visa and Mastercard";
        }
    }
    else if (document.getElementById("AE").checked) {
        if (length >= 15 && !isNaN(text)) {
            errMsg += "Invalid number must have less than 15 digits for American Express card";
        }
    }

    if (document.getElementById("visa").checked) {
        method = "Visa";
    }
    else if (document.getElementById("mastercard").checked) {
        method = "Mastercard";
    }
    else if (document.getElementById("AE").checked) {
        method = "American Express";
    }


    if (errMsg != "") {
        alert(errMsg);
        result = false;
    }
    else {
        var choice = confirm("Thanks for your purchase!!!\nCustomer: " + fname + " " +
            lname + "\nAddress: " + address
            + "\nPayment: " + method + "\nCard number : " + text + "\nBilling Address:" + String(billingadd) +
            "\nCard holder: " + namecard);

    }
    return result;
}
function inits() {
    var ordForm = document.getElementById("ordform");
    ordForm.onsubmit = validates;
}
window.onload = inits;






