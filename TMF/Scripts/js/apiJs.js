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
    $("#steamPopup").dialog("open");
});
function getSteamDatas() {    
    $.ajax({
        type: "POST",
        url: '/users/getSteamDatas',
        data: { 'connectID': ($('#steamID').val()) },
        success: function (data) {
            //alert(data);
            $("#steamGameCount").append('<li>' + data.response.game_count + '</li>')
            $.each(data.response.games, function (index, option) {
                $("#steamGameList").append('<li>' + option.name + '</li>');
            });

        },
        error: function () {
            alert('Steam ID is not existing');
        }
    });

}