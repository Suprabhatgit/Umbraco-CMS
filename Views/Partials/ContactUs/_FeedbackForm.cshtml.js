var submitbutton = document.getElementById('contact-submit');

submitbutton.onclick = function () {
    if (ValidateElements() == false) {
        return false;
    }
    var formData = {
        FullName: document.getElementById('fullname').value,
        Email: document.getElementById('email').value,
        Subject: document.getElementById('subject').value,
        Message: document.getElementById('message').value
    };
    var submitSucessMessage = document.getElementById('submitSuccessMessage');
    var submitErrorMessage = document.getElementById('submitErrorMessage');

    fetch("/umbraco/api/contactus/insert", {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(formData)
    }).then(res => {
        console.log("Request complee response:", res);
        if (res.status == 200) {
            submitSucessMessage.classList.remove("d-none");
            submitErrorMessage.classList.add("d-none");
        }
        else {
            submitSucessMessage.classList.remove("d-none");
            submitErrorMessage.classList.add("d-none");
        }
    }).catch(err => {
        console.error(err);
        submitErrorMessage.classList.remove("d-none");
    });
}

function ValidateElements() {
    if (document.getElementById('fullname').value.trim() == "") {
        document.getElementById('fullnameValidation').classList.remove("d-none");
        document.getElementById()
        return false;
    }
    else {
        document.getElementById('fullnameValidation').classList.add("d-none");
    }
    if (document.getElementById('email').value.trim() == "") {
        document.getElementById('emailValidation').classList.remove("d-none");
        return false;
    }
    else {
        document.getElementById('emailValidation').classList.add("d-none");
    }
    if (document.getElementById('subject').value.trim() == "") {
        document.getElementById('subjectValidation').classList.remove("d-none");
        return false;
    }
    else {
        document.getElementById('subjectValidation').classList.add("d-none");
    }
    if (document.getElementById('message').value.trim() == "") {
        document.getElementById('messageValidation').classList.remove("d-none");
        return false;
    }
    else {
        document.getElementById('messageValidation').classList.add("d-none");
    }
}
