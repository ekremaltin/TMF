$(function () {
    $("#slider-range").slider({
        range: true,
        min: 1,
        max: 10,
        values: [1, 10],
        slide: function (event, ui) {
            $("#amount").val(ui.values[0] + " - " + ui.values[1]);                  
            $("#minData").val(ui.values[0]);                  
            $("#maxData").val(ui.values[1]);                  
            if (ui.values[0] == 1) {                                                
                $("#minPic").attr('src', '/TMF Documents/Silver1.png');             
            }                                                                       
            else if (ui.values[0] == 2) {                                           
                $("#minPic").attr('src', '/TMF Documents/Silver3.png');             
            }
            else if (ui.values[0] == 3) {
                $("#minPic").attr('src', '/TMF Documents/Silver5.png');
            }
            else if (ui.values[0] == 4) {
                $("#minPic").attr('src', '/TMF Documents/Nova1.png');
            }
            else if (ui.values[0] == 5) {
                $("#minPic").attr('src', '/TMF Documents/Nova3.png');
            }
            else if (ui.values[0] == 6) {
                $("#minPic").attr('src', '/TMF Documents/Keles.png');
            }
            else if (ui.values[0] == 7) {
                $("#minPic").attr('src', '/TMF Documents/CiftKeles.png');
            }
            else if (ui.values[0] == 8) {
                $("#minPic").attr('src', '/TMF Documents/Le.png');
            }
            else if (ui.values[0] == 9) {
                $("#minPic").attr('src', '/TMF Documents/Supreme.png');
            }
            else if (ui.values[0] == 10) {
                $("#minPic").attr('src', '/TMF Documents/Global.png');
            }
            if (ui.values[1] == 1) {
                $("#maxPic").attr('src', '/TMF Documents/Silver2.png');
            } 
            else if (ui.values[1] == 2) {
                $("#maxPic").attr('src', '/TMF Documents/Silver4.png');
            }
            else if (ui.values[1] == 3) {
                $("#maxPic").attr('src', '/TMF Documents/Silver6.png');
            } 
            else if (ui.values[1] == 4) {
                $("#maxPic").attr('src', '/TMF Documents/Nova2.png');
            } 
            else if (ui.values[1] == 5) {
                $("#maxPic").attr('src', '/TMF Documents/Nova4.png');
            } 
            else if (ui.values[1] == 6) {
                $("#maxPic").attr('src', '/TMF Documents/Keles2.png');
            } 
            else if (ui.values[1] == 7) {
                $("#maxPic").attr('src', '/TMF Documents/Dmg.png');
            } 
            else if (ui.values[1] == 8) {
                $("#maxPic").attr('src', '/TMF Documents/Lem.png');
            } 
            else if (ui.values[1] == 9) {
                $("#maxPic").attr('src', '/TMF Documents/Supreme.png');
            } 
            else if (ui.values[1] == 10) {
                $("#maxPic").attr('src', '/TMF Documents/Global.png');
            }
            $("#gallery").slideDown("slow");
        },
        stop: function (event, ui) {
            $("#gallery").slideUp("slow");
        }
    });    /* Ranked aralık Js*/
    
    $("#amount").val($("#slider-range").slider("values", 0) + /* İlk sayfa açılışta Slider için yazılması gerekenler */
        " - " + $("#slider-range").slider("values", 1));
    $("#minData").val($("#slider-range").slider("values", 0));
    $("#maxData").val($("#slider-range").slider("values", 1));


});