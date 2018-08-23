var app = angular.module("demoapp", ["ngRoute"]);
app.config(function($routeProvider) {
    $routeProvider
     .when("/", {
         templateUrl: "PartialHTML/FormSubmit.html"
    })
    
});