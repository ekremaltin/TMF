$(function () {
    $("#slider-rangeCS").slider({
        range: true,
        min: 1,
        max: 10,
        values: [1, 10],
        slide: function (event, ui) {
            $("#minDataCS").val(ui.values[0]);                  
            $("#maxDataCS").val(ui.values[1]);                  
            if (ui.values[0] === 1) {                                                
                $("#minPicCS").attr('src', '/TMF Documents/CS/Silver1.png');
                $("#amountCS1").val("Silver 1");
            }                                                                       
            else if (ui.values[0] === 2) {                                           
                $("#minPicCS").attr('src', '/TMF Documents/CS/Silver3.png');             
                $("#amountCS1").val("Silver 3");
            }
            else if (ui.values[0] === 3) {
                $("#minPicCS").attr('src', '/TMF Documents/CS/Silver5.png');
                $("#amountCS1").val("Silver 5");
            }
            else if (ui.values[0] === 4) {
                $("#minPicCS").attr('src', '/TMF Documents/CS/Nova1.png');
                $("#amountCS1").val("Nova 1");
            }
            else if (ui.values[0] === 5) {
                $("#minPicCS").attr('src', '/TMF Documents/CS/Nova3.png');
                $("#amountCS1").val("Nova 3");
            }
            else if (ui.values[0] === 6) {
                $("#minPicCS").attr('src', '/TMF Documents/CS/Keles.png');
                $("#amountCS1").val("Master Guardian 1");
            }
            else if (ui.values[0] === 7) {
                $("#minPicCS").attr('src', '/TMF Documents/CS/CiftKeles.png');
                $("#amountCS1").val("Master Guardian Elite");
            }
            else if (ui.values[0] === 8) {
                $("#minPicCS").attr('src', '/TMF Documents/CS/Le.png');
                $("#amountCS1").val("Legendary Eagle");
            }
            else if (ui.values[0] === 9) {
                $("#minPicCS").attr('src', '/TMF Documents/CS/Supreme.png');
                $("#amountCS1").val("Supreme Master First Class");
            }
            else if (ui.values[0] === 10) {
                $("#minPicCS").attr('src', '/TMF Documents/CS/Global.png');
                $("#amountCS1").val("The Global Elite");
            }
            if (ui.values[1] === 1) {
                $("#maxPicCS").attr('src', '/TMF Documents/CS/Silver2.png');
                $("#amountCS2").val("Silver 2");
            } 
            else if (ui.values[1] === 2) {
                $("#maxPicCS").attr('src', '/TMF Documents/CS/Silver4.png');
                $("#amountCS2").val("Silver 4");
            }
            else if (ui.values[1] === 3) {
                $("#maxPicCS").attr('src', '/TMF Documents/CS/Silver6.png');
                $("#amountCS2").val("Silver 6");
            } 
            else if (ui.values[1] === 4) {
                $("#maxPicCS").attr('src', '/TMF Documents/CS/Nova2.png');
                $("#amountCS2").val("Nova 2");
            } 
            else if (ui.values[1] === 5) {
                $("#maxPicCS").attr('src', '/TMF Documents/CS/Nova4.png');
                $("#amountCS2").val("Nova 4");
            } 
            else if (ui.values[1] === 6) {
                $("#maxPicCS").attr('src', '/TMF Documents/CS/Keles2.png');
                $("#amountCS2").val("Master Guardian 2");
            } 
            else if (ui.values[1] === 7) {
                $("#maxPicCS").attr('src', '/TMF Documents/CS/Dmg.png');
                $("#amountCS2").val("Distinguished Master Guardian");
            } 
            else if (ui.values[1] === 8) {
                $("#maxPicCS").attr('src', '/TMF Documents/CS/Lem.png');
                $("#amountCS2").val("Legendary Eagle Master");
            } 
            else if (ui.values[1] === 9) {
                $("#maxPicCS").attr('src', '/TMF Documents/CS/Supreme.png');
                $("#amountCS2").val("Supreme Master First Class");
            } 
            else if (ui.values[1] === 10) {
                $("#maxPicCS").attr('src', '/TMF Documents/CS/Global.png');
                $("#amountCS2").val("The Global Elite");
            }
            $("#galleryCS").slideDown("slow");
        },
        stop: function (event, ui) {
            $("#galleryCS").slideUp("slow");
        }
    });    /* Ranked aralık Js*/
    
    $("#amountCS1").val("Silver 1"); /* İlk sayfa açılışta Slider için yazılması gerekenler */
    $("#amountCS2").val("The Global Elite");
    $("#minDataCS").val($("#slider-rangeCS").slider("values", 0));
    $("#maxDataCS").val($("#slider-rangeCS").slider("values", 1));

    $("#slider-rangeLOL").slider({
        range: true,
        min: 1,
        max: 13,
        values: [1, 13],
        slide: function (event, ui) {
            $("#minDataLOL").val(ui.values[0]);
            $("#maxDataLOL").val(ui.values[1]);
            if (ui.values[0] === 1) {
                $("#minPicLOL").attr('src', '/TMF Documents/LOL/bronze_5.png');
                $("#amountLOL1").val("Bronze 5");
            }
            else if (ui.values[0] === 2) {
                $("#minPicLOL").attr('src', '/TMF Documents/LOL/silver_5.png');
                $("#amountLOL1").val("Silver 5");
            }
            else if (ui.values[0] === 3) {
                $("#minPicLOL").attr('src', '/TMF Documents/LOL/silver_3.png');
                $("#amountLOL1").val("Silver 3");
            }
            else if (ui.values[0] === 4) {
                $("#minPicLOL").attr('src', '/TMF Documents/LOL/silver_1.png');
                $("#amountLOL1").val("Silver 1");
            }
            else if (ui.values[0] === 5) {
                $("#minPicLOL").attr('src', '/TMF Documents/LOL/gold_4.png');
                $("#amountLOL1").val("Gold 4");
            }
            else if (ui.values[0] === 6) {
                $("#minPicLOL").attr('src', '/TMF Documents/LOL/gold_2.png');
                $("#amountLOL1").val("Gold 2");
            }
            else if (ui.values[0] === 7) {
                $("#minPicLOL").attr('src', '/TMF Documents/LOL/platinum_5.png');
                $("#amountLOL1").val("Platinum 5");
            }
            else if (ui.values[0] === 8) {
                $("#minPicLOL").attr('src', '/TMF Documents/LOL/platinum_3.png');
                $("#amountLOL1").val("Platinum 3");
            }
            else if (ui.values[0] === 9) {
                $("#minPicLOL").attr('src', '/TMF Documents/LOL/platinum_1.png');
                $("#amountLOL1").val("Platinum 1");
            }
            else if (ui.values[0] === 10) {
                $("#minPicLOL").attr('src', '/TMF Documents/LOL/diamond_4.png');
                $("#amountLOL1").val("Diamond 4");
            }
            else if (ui.values[0] === 11) {
                $("#minPicLOL").attr('src', '/TMF Documents/LOL/diamond_2.png');
                $("#amountLOL1").val("Diamond 2");
            }
            else if (ui.values[0] === 12) {
                $("#minPicLOL").attr('src', '/TMF Documents/LOL/master_1.png');
                $("#amountLOL1").val("Master");
            }
            else if (ui.values[0] === 13) {
                $("#minPicLOL").attr('src', '/TMF Documents/LOL/challenger_1.png');
                $("#amountLOL1").val("Challenger" + " - ");
            }
            if (ui.values[1] === 1) {
                $("#maxPicLOL").attr('src', '/TMF Documents/LOL/bronze_1.png');
                $("#amountLOL2").val("Bronze 1");
            }
            else if (ui.values[1] === 2) {
                $("#maxPicLOL").attr('src', '/TMF Documents/LOL/silver_2.png');
                $("#amountLOL2").val("Siver 2");
            }
            else if (ui.values[1] === 3) {
                $("#maxPicLOL").attr('src', '/TMF Documents/LOL/gold_5.png');
                $("#amountLOL2").val("Gold 5");
            }
            else if (ui.values[1] === 4) {
                $("#maxPicLOL").attr('src', '/TMF Documents/LOL/gold_3.png');
                $("#amountLOL2").val("Gold 3");
            }
            else if (ui.values[1] === 5) {
                $("#maxPicLOL").attr('src', '/TMF Documents/LOL/gold_1.png');
                $("#amountLOL2").val("Gold 1");
            }
            else if (ui.values[1] === 6) {
                $("#maxPicLOL").attr('src', '/TMF Documents/LOL/platinum_4.png');
                $("#amountLOL2").val("Platinum 4");
            }
            else if (ui.values[1] === 7) {
                $("#maxPicLOL").attr('src', '/TMF Documents/LOL/platinum_2.png');
                $("#amountLOL2").val("Platinum 2");
            }
            else if (ui.values[1] === 8) {
                $("#maxPicLOL").attr('src', '/TMF Documents/LOL/diamond_5.png');
                $("#amountLOL2").val("Diamond 5");
            }
            else if (ui.values[1] === 9) {
                $("#maxPicLOL").attr('src', '/TMF Documents/LOL/diamond_3.png');
                $("#amountLOL2").val("Diamond 3");
            }
            else if (ui.values[1] === 10) {
                $("#maxPicLOL").attr('src', '/TMF Documents/LOL/diamond_1.png');
                $("#amountLOL2").val("Diamond 1");
            }
            else if (ui.values[1] === 11) {
                $("#maxPicLOL").attr('src', '/TMF Documents/LOL/master_1.png');
                $("#amountLOL1").val("Master");
            }
            else if (ui.values[1] === 12) {
                $("#maxPicLOL").attr('src', '/TMF Documents/LOL/challenger_1.png');
                $("#amountLOL2").val("Challenger");
            }
            else if (ui.values[1] === 13) {
                $("#maxPicLOL").attr('src', '/TMF Documents/LOL/challenger_1.png');
                $("#amountLOL2").val("Challenger");
            }

            $("#galleryLOL").slideDown("slow");
        },
        stop: function (event, ui) {
            $("#galleryLOL").slideUp("slow");
        }
    });    /* Ranked aralık Js*/

    $("#amountLOL1").val("Bronze 5"); /* İlk sayfa açılışta Slider için yazılması gerekenler */
    $("#amountLOL2").val("Challenger");
    $("#minDataLOL").val($("#slider-rangeLOL").slider("values", 0));
    $("#maxDataLOL").val($("#slider-rangeLOL").slider("values", 1));

});