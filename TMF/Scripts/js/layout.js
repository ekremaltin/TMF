$(function () {
    $('a[name=game]').on('click', function () {
        const btn = $('#game_btn');
        const selectedGame = $(this);
        if (selectedGame.attr("id") === "1") {
            $("#lolSearch").show();
            $("#csSearch").hide();
            $("#searchKey").val("1");
            $("#searchKey2").val("1");
        }
        else {
            $("#csSearch").show();
            $("#lolSearch").hide();
            $("#searchKey").val("2");
            $("#searchKey2").val("2");
        }

    });
});
