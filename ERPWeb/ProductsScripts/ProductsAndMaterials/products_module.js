angular.module("ProductsModule", ['ngRoute', 'ngAnimate', 'ui.bootstrap'])
    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

        location.pathname;

        $routeProvider
            .when("/home/index/productsandmaterialscatalog",
            {
                templateUrl: '/Home/ProductsAndMaterialsCatalog',
                controller: 'AddProductsController'
            })
            .when("/addproduct",
            {
                templateUrl: '/Home/AddProductPartial',
                controller: 'AddProductsController'
            })
            .when('/addmaterial',
            {
                templateUrl: '/Home/AddMaterial',
                controller: 'AddProductsController'
            })
            .when("/home/index/addproduct",
            {
                templateUrl: '/Home/AddProductPartial',
                controller: 'AddProductsController'
            })
            .when('/home/index/addmaterial',
            {
                templateUrl: '/Home/AddMaterial',
                controller: 'AddProductsController'
            })
            .when('/home/index/viewcatalogs',
            {
                templateUrl: '/Home/viewcatalogs',
                controller: 'AddProductsController'
            })
            .when('/Home/AddProduct',
            {
                templateUrl: '/home/index"',
                controller: 'AddProductsController'
            })
            .when('/home/index',
            {
                templateUrl: '/Home/ProductsAndMaterialsCatalog'
            })
            .when('/',
            {
                templateUrl: '/Home/ProductsAndMaterialsCatalog'
            });

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
}]);