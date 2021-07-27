var app = angular.module("myApp", ["ngRoute"]);
app.config(["$routeProvider","$locationProvider",function($routeProvider,$locationProvider) {

    $routeProvider
    .when("/", {
        templateUrl : "views/pages/demopage.html"
    })
    .when("/demo", {
        templateUrl : "views/pages/demopage.html",
        controller: 'demo'
    })
    .when("/demo2", {
        templateUrl : "views/pages/demo2.html",
          controller: 'demo2'
    })
    .when("/products", {
        templateUrl : "views/pages/products.html",
        controller: 'products'
    })
    .when("/page1", {
        templateUrl : "views/pages/page1.html",
        controller: 'practise'
    })
    .when("/page2", {
        templateUrl : "views/pages/page2.html",
        controller: 'practise'
    })
    .when("/page3", {
        templateUrl : "views/pages/page3.html",
        controller: 'practise'
    })
    .when("/page4", {
        templateUrl : "views/pages/page4.html",
        controller: 'practise'
    })
    .when("/page5", {
        templateUrl : "views/pages/page5.html",
        controller: 'practise'
    })
    .otherwise({
        redirectTo:"/"
    });
      //$locationProvider.html5Mode(true);
      //$locationProvider.hashPrefix('');
      //if(window.history && window.history.pushState){
      //$locationProvider.html5Mode(true);
  //}

}]);
