
(function () {
    'use strict';

    var conf_locate = {};

    // Init functions, called on DOMContentLoaded event
    conf_locate.init = function () {
        conf_locate.map.init($('#map-canvas'));
    };

    /***
        Google Maps implementation
    ***/
    conf_locate.map = {
        marker: '/img/marker-default.png'
    };

    // Google Maps configs
    conf_locate.map.init = function ($element) {
        conf_locate.map.element = $element;

        conf_locate.map.geocoder = new google.maps.Geocoder();

        conf_locate.map.latlng = new google.maps.LatLng(0, 0);

        conf_locate.map.options = {
            zoom: 16,
            center: conf_locate.map.latlng,
            scrollwheel: false,
            streetViewControl: true,
            labels: true,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        conf_locate.map.canvas = new google.maps.Map(conf_locate.map.element.get(0), conf_locate.map.options);
        conf_locate.map.canvas.setCenter(conf_locate.map.latlng);

        conf_locate.map.createMarker();
    };

    conf_locate.map.createMarker = function () {
        
        conf_locate.map.address = conf_locate.map.element.attr('data-address');

        conf_locate.map.geocoder.geocode({ 'address': conf_locate.map.address}, function (results, status) {

            if (status === google.maps.GeocoderStatus.OK) {

                conf_locate.map.canvas.setCenter(results[0].geometry.location);

                new google.maps.Marker({
                    map: conf_locate.map.canvas,
                    position: results[0].geometry.location,
                    icon: conf_locate.map.marker
                });
            } else {
                if (window.console) {
                    console.log('Google Maps was not loaded: ', status);
                }
            }
        });
    };
    
    conf_locate.init();
}());
