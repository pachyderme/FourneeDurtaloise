$().ready(function () {
    var left = $('#Search').css('margin-left').replace('px','');
    $('.c-hamburger').click(function () {
        $('#Content').css({ 'margin-top': '90px' });
        $('#Search').removeClass('is-no-active-search');
        $('#Search').toggleClass('is-active-search');
        $('.is-active-search').css({ 'width':'300px' , 'left':'0' });
        $('.is-active-search').css({ 'transform': 'translateX(-300px)' });
        $('body').toggleClass('with--sidebar');        
        $('.site-container').css({ 'overflow': 'hidden' });
        $('body').css({ 'overflow': 'hidden' });
        $('.btn-menu').css({ 'z-index': '0' });
    });

    $('#site-cache').click(function () {       
        $('.c-hamburger').trigger('click');
        $('body').removeClass('with--sidebar');
        $('#Search').removeClass('is-active-search');
        $('#Search').toggleClass('is-no-active-search');
        $('#Search').css({ 'width': '21%',  });
        $('#Search').css({ 'transform': 'translateX(0px)' });
        $('.site-container').css({ 'overflow': 'hidden' });
        $('body').css({ 'overflow': 'auto' });
        $('.btn-menu').css({ 'z-index': '1' });
        $('#Content').css({ 'margin-top': '20px' });
    });
    $('.checkout__button').click(function () {
        $('checkout').css({ 'z-index': '2' });
    });
    $('.checkout__close').click(function () {
        $('checkout').css({ 'z-index': '0' });
    });
})