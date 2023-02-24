$(document).ready(function () {
    $("#btnRegister").click(function () {

        var FullName = $("#txtfName").val();
        var Email = $("#txtemail").val();
        var Contact = $("#txtContact").val();
        var Password = $("#txtPassword").val();
        
        var obj = {
            "userName": FullName,
            "userEmail": Email,
            "userContact": Contact,
            "userPassword": Password
        }
        //alert(JSON.stringify(obj));
       // var myToken = getCookie("MyToken");
        $.ajax({
            url: '/api/Register/SignUpData',
            type: "POST",
            'contentType': 'application/json',
            dataType: "json",
         //   headers: {
        //        "Authorization": "Bearer " + myToken
         //   },
            data: JSON.stringify(obj),
            success: function (data) {
                if (data.result == "Added Successfully") {
                    //alert(data.result);
                    //alert("Please proceed next");

                    $("#txtfName").val("");
                    $("#txtfName").focus();
                    $("#txtemail").val("");
                    $("#txtContact").val("");
                    $("#txtPassword").val("");
                    $("#alertMessage").html(''); 
                    window.location.href = "/RegisterFront/Login";
                }
                else {
                        $("#alertMessage").css("color", "red");
                    $("#alertMessage").html('Invalid Credentials'); 
                    $("#txtfName").focus();
                    
                }
            }
        })
    })
})