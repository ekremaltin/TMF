$(function () {
    $.ajax({
        type: 'GET',
        url: '/games/getGames',
        datatype: 'json',
        success: function (data) {
            $.each(data, function (index, option) {
                $("#cbList").append('<label for=' + option.Text + ' class="btn btn-primary cb-font col-md-6">' + option.Text +
                    ' <input type="checkbox" data-check="on" class="badgebox games" onclick="getDiv(' + option.Value + ')" id=' + option.Text + ' name=' + option.Text + ' >' +
                    ' <span class="badge">&check;</span> ' +
                    '</label>');
            });
        }
    });

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

    $('#createBtn').on('click', function () {
        var b = false;
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
            if ($('#League:checked').length == true) {
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
            if ($('#Counter:checked').length == true) {
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

                document.getElementById('createBtn').type = 'submit';
                document.getElementById('createBtn').click();
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
        if ($("#League").data("check") == "on") {
            // Run the effect
            $("#lol").slideDown("slow");
            $("#League").data("check", "off");
        }
        else if ($("#League").data("check") == "off") {
            $("#lol").slideUp("slow");
            $("#League").data("check", "on");
        }
    }

    if (ids == "2") {
        if ($("#Counter").data("check") == "on") {
            // Run the effect
            $("#cs").slideDown("slow");
            $("#Counter").data("check", "off");
        }
        else {
            $("#cs").slideUp("slow");
            $("#Counter").data("check", "on");
        }
    }

}