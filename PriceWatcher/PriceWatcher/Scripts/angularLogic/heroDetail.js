(function (angular) {
    'use strict';
    function HeroDetailController($http) {
        var ctrl = this;

        ctrl.$onInit = function () {

            $http({
                method: 'GET',
                url: '/Home/GetValues'
            }).then(function successCallback(response) {

                $('#container').highcharts({
                    title: {
                        text: 'Monthly Average Temperature',
                        x: -20 //center
                    },
                    subtitle: {
                        text: 'Source: WorldClimate.com',
                        x: -20
                    },
                    xAxis: {
                        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
                    },
                    yAxis: {
                        title: {
                            text: 'Temperature (°C)'
                        },
                        plotLines: [{
                            value: 0,
                            width: 1,
                            color: '#808080'
                        }]
                    },
                    tooltip: {
                        valueSuffix: '°C'
                    },
                    legend: {
                        layout: 'vertical',
                        align: 'right',
                        verticalAlign: 'middle',
                        borderWidth: 0
                    },
                    series: response.data.countries
                });

                
            }, function errorCallback(response) {
                alert("Sorry, something went wrong!");
            });            
        }
    }

    angular.module('heroApp').component('heroDetail', {
        templateUrl: 'StaticHtml/Home/heroDetail.html',
        controller: HeroDetailController,
        bindings: {
            hero: '='
        }
    });
})(window.angular);