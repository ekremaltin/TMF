$(function () {
    $("#steamPopup").dialog({
        autoOpen: false,
        show: {
            effect: "blind",
            duration: 1000
        },
        hide: {
            effect: "explode",
            duration: 1000
        },
        minWidth: 600,
        maxWidth: 600
    });
    
    

});

$("#opener").on("click", function () {
    getSteamDatas();
});
function getSteamDatas() {    
    $.ajax({
        type: "POST",
        url: '/users/getSteamDatas',
        data: { 'connectID': ($('#steamID').val()) },
        success: function (data) {
            if (data == false) {
                alert('Steam ID is not existing');
            }
            else {
                $("#steamGameCount").append('<li>' + data.response.game_count + '</li>')
                $.each(data.response.games, function (index, option) {
                    $("#steamGameList").append('<li>' + option.name + '</li>');
                });
                $("#steamPopup").dialog("open");
            }
            

        },
        error: function () {
            
        }
    });

}