angular.module("ProductsModule")
    .service("PandMService", function ($http)
    {
        this.getProductsAndMaterials = function () {
            return $http.get("/api/productsandmaterials/getproductsandmaterialscatalog");
        };
        
        this.getMaterials = function () {
            return $http.get("/api/productsandmaterials/getmaterials");
        };

        this.getMaterialsCatalog = function () {
            return $http.get("/api/productsandmaterials/getmaterialscatalog");
        };

        this.postMaterial = function (SubjectOfLabor) {
        var request = $http({
            method: "post",
            url: "api/productsandmaterials/postmaterial",
            data: SubjectOfLabor
            });

            return request;
        };

        this.postProduct = function (SubjectOfLabor) {
            var request = $http({
                method: "post",
                url: "api/productsandmaterials/postproduct",
                data: SubjectOfLabor
            });

            return request;
        };

        this.postMaterialEntry = function (SubjectOfLabor) {
            var request = $http({
                method: "post",
                url: "api/productsandmaterials/postmaterialcatalogentry",
                data: SubjectOfLabor
            });
        
            return request;
        };

        this.postOperation = function (operation) {
            var request = $http({
                method: "post",
                url: "api/productsandmaterials/postoperation",
                data: operation
            });

            return request;
        };

        this.getProductMaterialByID = function (id) {
            return $http.get("/api/productsandmaterials/getsubjectoflabor/" + id);
        };

        this.loadM = function () {
            var materials;
            var requitedMaterials = this.getMaterialsCatalog();
            requitedMaterials.then(function (result) {
                materials = result.data;
            },
                function (error) {
                    $scope.error = 'could not load prodcuts and materials', error;
                });
            return materials;
        };
});