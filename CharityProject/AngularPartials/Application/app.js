
(function () {


    var myAPP = angular.module("myAPP", ["ngRoute"]);

    myAPP.config(function ($routeProvider) {
        $routeProvider.
            when('/', {
                templateUrl: '/AngularPartials/pages/gallery.html',
                controller: 'GalleryController'
            }).
            when('/chartA', {
                templateUrl: '/AngularPartials/pages/events.html',
                controller: 'EventsController'
            }).
            when('/chartB', {
                templateUrl: '/AngularPartials/pages/gallery.html',
                controller: 'GalleryController'
            }).
            otherwise({             
                redirectTo: '/AngularPartials/pages/gallery.html',
                controller: 'GalleryController'
            });


      
    });

}());