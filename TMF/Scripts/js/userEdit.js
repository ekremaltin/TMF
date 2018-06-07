$(function () {
    $('#pswShow').on('click', function () {
        
        if ($("#password").data("check") == "on") {
            // Run the effect
            $('#password').prop("type", "text");
            $("#password").data("check", "off");
        }
        else if ($("#password").data("check") == "off") {
            $('#password').prop("type", "password");
            $("#password").data("check", "on");
        }
    });

    $('#saveBtn').on('click', function () {
        var i = $('.games:checked').length;
        var roleLol = $('.roleLol:checked').length;
        var roleCS = $('.roleCS:checked').length;
        var lolHours = $('#lolHours').val();
        var csHours = $('#csHours').val();
        var click1 = true;
        var click2 = true;
        var click3 = true;
        var click4 = true;
        //Oyunlar Seçili ise
        if (i > 0) {

            //LoL özellik kontrolü
            if ($('#League:checked').length > 0 ) {
                $('#lolNickname').prop("required", true);
                if (roleLol == 0) {
                    alert("Please select at least 1 role for LoL!");
                    click1 = false;
                }

                $('#rankLol').prop("required", true);
                if (lolHours < 0) {
                    alert("Please do not enter a clock less than 0 for LoL!");
                    click2 = false;
                }
            }


            //CS:GO özellik kontrolü
            if ($('#Counter:checked').length > 0) {
                $('#steamName').prop("required", true);
                $('#steamID').prop("required", true);
                if (roleCS == 0) {
                    alert("Please select at least 1 role for CS:GO!");
                    click3 = false;
                }
                $('#rankCs').prop("required", true);
                if (csHours < 0) {
                    alert("Please do not enter a clock less than 0 for CS:GO!");
                    click4 = false;
                }
            }

            if (click1 == true && click2 == true && click3 == true && click4 == true) {

                document.getElementById('saveBtn').type = 'submit';
                document.getElementById('saveBtn').click();
            }


        }
        //Hiçbir oyun seçili değilse
        else {
            alert("Please select at least 1 game!");
        }



    });
});

function getDiv(ids) {
    if (ids == "1") {
        if ($("#League").data("check") == "off") {
            // Run the effect
            $("#lolDiv").slideDown("slow");
            $("#League").data("check", "on");
        }
        else if ($("#League").data("check") == "on") {
            $("#lolDiv").slideUp("slow");
            $("#League").data("check", "off");
        }
    }

    if (ids == "2") {
        if ($("#Counter").data("check") == "off") {
            // Run the effect
            $("#csDiv").slideDown("slow");
            $("#Counter").data("check", "on");
        }
        else {
            $("#csDiv").slideUp("slow");
            $("#Counter").data("check", "off");
        }
    }

}

function getDiv2(ids) {
    if (ids == "1") {
        if ($("#League").data("check") == "on") {
            // Run the effect
            $("#lolDivNew").slideDown("slow");
            $("#League").data("check", "off");
        }
        else if ($("#League").data("check") == "off") {
            $("#lolDivNew").slideUp("slow");
            $("#League").data("check", "on");
        }
    }

    if (ids == "2") {
        if ($("#Counter").data("check") == "off") {
            // Run the effect
            $("#csDivNew").slideDown("slow");
            $("#Counter").data("check", "on");
        }
        else {
            $("#csDivNew").slideUp("slow");
            $("#Counter").data("check", "off");
        }
    }

}