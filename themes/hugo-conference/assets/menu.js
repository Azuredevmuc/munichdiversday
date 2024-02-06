(function () {
    'use strict';

    var conf_nav = {};

    // Init functions, called on DOMContentLoaded event
    conf_nav.init = function () {
        conf_nav.menu.init();
    };


    /***
        Create animated scroll for menu links
    ***/
    conf_nav.menu = {
        itemsSelector: '.nav-link[href^="#"]',
        animationSpeed: 400
    };

    conf_nav.menu.init = function () {
        conf_nav.menu.menuItems = $(conf_nav.menu.itemsSelector);
        conf_nav.menu.document = $('html, body');

        conf_nav.menu.menuItems.on('click.animateScroll', function (event) {
            event.preventDefault();

            conf_nav.menu.animateTo(event.target);
        });
    };

    conf_nav.menu.animateTo = function (link) {

        var $link = $(link),
            href = $link.attr('href'),
            offSetTop = $(href).offset().top;
        
            conf_nav.menu.document.finish().animate({scrollTop : offSetTop}, conf_nav.menu.animationSpeed, function () {
            location.hash = href;
        });
    };

    conf_nav.init();
}());
