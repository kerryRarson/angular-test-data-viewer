var _map = null;
var _lat = '';
var _lon = '';
function showLocation(lat, lon, title) {
    _lat = lat;
    _lon = lon;
    
    var coords = new google.maps.LatLng(_lat, _lon);

    var mapOptions = {
        zoom: 15,
        center: coords,
        mapTypeControl: true,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    //create the map, and place it in the HTML map div
    _map = new google.maps.Map(
        document.getElementById("mapPlaceholder"), mapOptions
    );
    //force a resize so it draws
    var currentCenter = _map.getCenter();  // Get current center before resizing
    google.maps.event.trigger(_map, "resize");
    _map.setCenter(currentCenter); // Re-set previous center

    //place the initial marker
    var contentString = "<div id='content'><div id='siteNotice'></div><div id='bodyContent'><p>" + title + "</p></div></div>";
    var infowindow = new google.maps.InfoWindow({
        content: contentString
    });
    var marker = new google.maps.Marker({
        position: coords,
        map: _map
    });
    google.maps.event.addListener(marker, 'click', function () {
        infowindow.open(_map, marker);
    });
}

function showLocationInner() {
    var coords = new google.maps.LatLng(_lat, _lon);

    var mapOptions = {
        zoom: 15,
        center: coords,
        mapTypeControl: true,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    //create the map, and place it in the HTML map div
    var map = new google.maps.Map(
        document.getElementById("mapPlaceholder"), mapOptions
    );
    //force a resize so it draws
    var currentCenter = map.getCenter();  // Get current center before resizing
    google.maps.event.trigger(map, "resize");
    map.setCenter(currentCenter); // Re-set previous center

    ////place the initial marker
    //var contentString = "<div id='content'><div id='siteNotice'></div><div id='bodyContent'><p>INNER</p></div></div>";
    //var infowindow = new google.maps.InfoWindow({
    //    content: contentString
    //});
    //var marker = new google.maps.Marker({
    //    position: coords,
    //    map: map
    //});
    //google.maps.event.addListener(marker, 'click', function () {
    //    infowindow.open(map, marker);
    //});
}
function showLocationAsync(lat, lon, title) {
    _lat = lat;
    _lon = lon;

    window.setTimeout(showLocationInner, 1000);
}