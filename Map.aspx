<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Map.aspx.cs" Inherits="Map" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
    <meta charset="utf-8">
    <title>Directions service</title>
    <style>
         /* Always set the map height explicitly to define the size of the div
        * element that contains the map. */
         #map {
             height: 100%;
         }
         /* Optional: Makes the sample page fill the window. */
         html, body {
             height: 100%;
             margin: 0;
             padding: 0;
         }

         #floating-panel {
             position: absolute;
             top: 10px;
             left: 25%;
             z-index: 5;
             background-color: #fff;
             padding: 5px;
             border: 1px solid #999;
             text-align: center;
             font-family: 'Roboto','sans-serif';
             line-height: 30px;
             padding-left: 10px;
         }
    </style>
</head>
<body>
    <div id="floating-panel">
        <b>Start: </b>

        <select id="start" runat="server" >
        </select>
        <b>End: </b>
        <select id="end" runat="server">
        </select>
    </div>
    <div id="map"></div>
    <script>
        function initMap() {
            var directionsService = new google.maps.DirectionsService;
            var directionsDisplay = new google.maps.DirectionsRenderer;
            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 7,
                center: { lat: 26.2182871, lng: 78.1828308 }
            });
            directionsDisplay.setMap(map);

            //var onChangeHandler = function () {
            //    calculateAndDisplayRoute(directionsService, directionsDisplay);
            //};
            calculateAndDisplayRoute(directionsService, directionsDisplay);
            document.getElementById('start').addEventListener('change', onChangeHandler);
            document.getElementById('end').addEventListener('change', onChangeHandler);
        }

        function calculateAndDisplayRoute(directionsService, directionsDisplay) {
            directionsService.route({
                origin: document.getElementById('start').value,
                destination: document.getElementById('end').value,
                travelMode: 'DRIVING'
            }, function (response, status) {
                if (status === 'OK') {
                    directionsDisplay.setDirections(response);
                } else {
                    //window.alert('Directions request failed due to ' + status);
                }
            });
        }

    </script>
    <script async defer
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDBnGYh38VLomSH156Y1rvh9jB-OYpXlZo&callback=initMap">
    </script>
    <script>
        var onChangeHandler = function () {
            calculateAndDisplayRoute(directionsService, directionsDisplay);
        };
    </script>
   
</body>
</html>
