
function IsNumberKey(evt) {
    var charCode = (evt.which) ? String.fromCharCode(evt.which) : St.fromCharCode(evt.keyCode)

    if (evt.keyCode == 37) {
        return true;
    }
    else if (evt.keyCode == 39) {
        return true;
    }

    if (/[0-9\b]/.test(charCode) || /[\b]/.test(charCode))
        return true;
    return false;
}


//function IsBoolKey(evt) {

//    debugger;
//    var charCode = (evt.which) ? String.fromCharCode(evt.which) : St.fromCharCode(evt.keyCode)

//    if (evt.keyCode == 37) {
//        return true;
//    }
//    else if (evt.keyCode == 39) {
//        return true;
//    }

//    if (/[YN\b]/.test(charCode) || /[\b]/.test(charCode))
//        return true;
//    return false;
//}

function IsAlphaNumeric(evt) {
    var charCode = (evt.which) ? String.fromCharCode(evt.which) : String.fromCharCode(evt.keyCode);

    if (evt.keyCode == 37) {
        return true;
    }
    else if (evt.keyCode == 39) {
        return true;
    }

    if (/[a-zA-Z0-9-_ ]/.test(charCode) || /[\b]/.test(charCode))
        return true;
    return false;
}

function CompareDate(startDate, endDate) {

    var effDate = Date.parse(document.getElementById(startDate).value);

    var expDate = Date.parse(document.getElementById(endDate).value);

    if (effDate != null && expDate != null) {

        if (effDate > expDate) {
            alert("Expiry date cannot be smaller than effective date.");
            document.getElementById(endDate).value = '';
            document.getElementById(endDate).focus();
            return false;
        }
    }
    return true;
}

