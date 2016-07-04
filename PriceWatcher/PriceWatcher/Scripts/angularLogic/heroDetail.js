(function (angular) {
    'use strict';
    function HeroDetailController() {

    }

    angular.module('heroApp').component('heroDetail', {
        templateUrl: 'StaticHtml/Home/heroDetail.html',
        controller: HeroDetailController,
        bindings: {
            hero: '='
        }
    });
})(window.angular);