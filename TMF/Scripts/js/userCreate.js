$(function () {
    $.ajax({
        type: 'GET',
        url: '/games/getGames',
        datatype: 'json',
        success: function (data) {
            $.each(data, function (index, option) {
                $("#cbList").append('<label for=' + option.Text + ' class="btn btn-primary cb-font col-md-6">' + option.Text +
                    ' <input type="checkbox" data-check="on" class="badgebox" onclick="getDiv(' + option.Value + ')" id=' + option.Text + ' name=' + option.Text + ' >' +
                    ' <span class="badge">&check;</span> ' +
                    '</label>');
            });
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