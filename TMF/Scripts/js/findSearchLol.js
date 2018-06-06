$(function () {
    $('#bul').on('click', function () {
        var minHours = $('#minHours').val();
        var maxHours = $('#maxHours').val();
        var click1 = true;
        var click2 = true;
        if (minHours < 0) {
            alert("Please do not enter a Minimum Hours value less than 0!");
            click1 = false;
        }
        if (maxHours < 0) {
            alert("Please do not enter a Maximum Hours value less than 0!");
            click2 = false;
        }
        if (click1 == true && click2 == true) {
            document.getElementById('bul').type = 'submit';
            document.getElementById('bul').click();
        }

    });
});