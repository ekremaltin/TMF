$(function () {
    $('a[name=game]').on('click', function () {
        const btn = $('#game_btn');
        const selectedGame = $(this);
        if (selectedGame.attr("id") === "1") {
            $("#lolSearch").show();
            $("#csSearch").hide();

        }
        else {
            $("#csSearch").show();
            $("#lolSearch").hide();

        }

    });
});
