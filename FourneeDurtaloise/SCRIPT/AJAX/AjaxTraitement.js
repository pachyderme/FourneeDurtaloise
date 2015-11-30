$().ready(function () {
    var aData = [];
    var urlService = "";
    $('.btn-menu-cat').click(function () {
        $("#Content").html("<img src='IMG/loading-content.gif' style='margin-left: 40%; width:20%;'/>");
        $('#site-cache').trigger('click');
        
        if ($(this).attr('id') == "btnProduitAll") {            
            aData[0] = "0";
            urlService = "MenuService.asmx/RecupProduitDix";
            $('#CatProd').text("Nos Produits");
        } else {
            if ($(this).attr('id') == "btnHoraires") {
                urlService = "MenuService.asmx/RecupHoraires";
                $('#CatProd').text("Nos Horaires");
            } else {
                aData[0] = "0";
                aData[1] = $(this).attr('id').replace("btnProduit", "");
                urlService = "MenuService.asmx/RecupProduitCatDix";
                $('#CatProd').text($(this).val());
            }            
        }
        var jsonData = JSON.stringify({ aData: aData });
        $.ajax({
            type: "POST", 
            url: urlService,
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            error: OnErrorCall
        });
    });
    $(window).scroll(function () {
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {
            try {
                if ($('#CatProd').text() != "Nos Horaires") {
                    $("#Content").append("<img src='IMG/loading-content.gif' style='margin-left: 40%; width:20%;'/>");
                    aData[0] = $('.TitreProduit:last').text();
                    if ($('#CatProd').text() == "Nos Produits") {
                        urlService = "MenuService.asmx/RecupProduitDix";
                    } else {
                        aData[1] = $('#CatProd').text();
                        urlService = "MenuService.asmx/RecupProduitCatDix";
                    }
                    var jsonData = JSON.stringify({ aData: aData });
                    $.ajax({
                        type: "POST",
                        url: urlService,
                        data: jsonData,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: OnSuccessScroll,
                        error: OnErrorCall
                    });
                }
                 
            }catch(err){}
            }
    });
    $('.ControlLikeLi').click(function () {
        var aData = [];
        if ($(this).hasClass("is-active-iconLike")) {
            var nbLike = parseInt($(this).next().text()) - 1;            
        } else {
            var nbLike = parseInt($(this).next().text()) + 1;
        }
        aData[nbLike] = $(this).parent().parent().prev().children(".TitreProduit").text();
        var jsonData = JSON.stringify({ aData: aData });

        $.ajax({
            type: "POST",
            //getListOfCars is my webmethod   
            url: "MenuService.asmx/ModifLikeProduit",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json", // dataType is json format
            success: OnSuccessLike,
            error: OnErrorCall
        });
        $(this).next().html(nbLike);     
    });
    function OnSuccess(response) {
        console.log(response.d)
        $("#Content img").fadeOut("slow", function () {
        });     
        $("#Content").html(response.d);
    }
    function OnSuccessScroll(response) {
        console.log(response.d)
        $("#Content img").fadeOut("slow", function () {
        });     
        $("#Content").append(response.d);
    }
    function OnSuccessLike(response) {
        console.log(response.d)        
    }
    function OnErrorCall(response) { console.log(response); }
})