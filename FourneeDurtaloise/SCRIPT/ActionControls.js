$().ready(function () {
    $('.ControlAdLi').click(function () {
        var icon = jQuery(this).find("a");
        if ($(icon).hasClass("is-active-iconAd")) {
            $(this).css({ 'border-color': 'rgba(123,117,117,0.4)' });
            $(icon).css({ 'color':  'rgba(123,117,117,0.4)' });
            $(icon).removeClass('is-active-iconAd');
        } else {
            $(this).css({ 'border-color': '#6CB359' });
            $(icon).css({ 'color': '#6CB359' });
            $(icon).addClass('is-active-iconAd');
        }      
    });
    $('.ControlLikeLi').click(function () {
        var icon = jQuery(this).find("a");
        var SpanLike = $(this).next();
        if ($(this).hasClass("is-active-iconLike")) {
            $(this).css({ 'border-color': 'rgba(123,117,117,0.4)' });
            $(icon).css({ 'color': 'rgba(123,117,117,0.4)' });            
            $(SpanLike).css({ 'color': 'rgba(123,117,117,0.4)' });
            $(this).removeClass('is-active-iconLike');
        } else {
            $(this).css({ 'border-color': '#A6373F' });
            $(icon).css({ 'color': '#A6373F' });
            $(SpanLike).css({ 'color': '#A6373F' });
            $(this).addClass('is-active-iconLike');
        }
    });
    $('.ControlPictureLi').click(function () {
        var icon = jQuery(this).find("a");
        var Picture = jQuery(this).parent().parent().next();
        var nbImg = jQuery(Picture).children().length;
        if (nbImg > 0) {
            if ($(this).hasClass("is-active-iconPicture")) {
                $(this).css({ 'border-color': 'rgba(123,117,117,0.4)' });
                $(icon).css({ 'color': 'rgba(123,117,117,0.4)' });
                $(this).removeClass('is-active-iconPicture');
                $(Picture).css({ 'display': 'none' });
            } else {
                $(this).css({ 'border-color': '#ff5e5e' });
                $(icon).css({ 'color': '#ff5e5e' });
                $(this).addClass('is-active-iconPicture');
                if (nbImg % 2 != 0) {
                    var Img = $(Picture).children().last();
                    $(Img).addClass('DerniereImageImpaire');
                }
                $(Picture).css({ 'display': 'block' });
            }
        }      
    });   
})