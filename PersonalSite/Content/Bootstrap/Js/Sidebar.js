$(window).scroll(function () {




    if ($(this).width() < 800) {
        $('.bs-docs-sidenav.affix').css({position:'static', top:'0'})
    }
});