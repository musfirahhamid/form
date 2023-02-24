$(document).ready(function () {
    var myToken = getCookie("MyToken");
    
    if (myToken != null) {
        window.location.href = "/RegisterFront/CMS";
    }
    alert(myToken);


    $("#btnLogin").click(function () {
        var Email = $("#txtEmail").val();
        var Password = $("#txtPassword").val();
        var obj = {
            "userEmail": Email,
            "userPassword": Password
        }
       
        //alert(JSON.stringify(obj));
        $.ajax({
            url: '/api/Register/GetLoginToken',
            type: "POST",
            'contentType': 'application/json',
            dataType: "json",
            data: JSON.stringify(obj),
            success: function (data) {

                if (data.result == "Logged In Successfully") {

                    
                    setCookie("MyToken", data.objectData, 1);
                    //alert("Please proceed next");
                    $("#txtEmail").val("");
                    $("#txtEmail").focus();
                    $("#txtPassword").val("");
                    $("#alertMessage").html('');
                    window.location.href = "/RegisterFront/CMS";
                }
                else {
                    $("#alertMessage").css("color", "red");
                    $("#alertMessage").html('Invalid Credentials');
                }
            }
        })

    })


    //Forget Password
    $("#resetPassword").click(function () {
        alert("Reset Password");
    })

})