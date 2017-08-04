angular.module("ProductsModule")
    .controller('AddProductsController', function ($scope, PandMService) {
        var requiredMaterials = [];

        $scope.saveMaterial = function () {
            var Material = {
                Id: 0,
                Name: $scope.materialName,
                Quantity: 0
            };

            var promisePutProduct = PandMService.postMaterial(Material);
            promisePutProduct.then(function (result) {
                $scope.materials = PandMService.loadM();
            });
           
        };

        $scope.saveProduct = function () {
            var Product = {
                Id: 0,
                Name: $scope.productName,
                RequiredMaterials: requiredMaterials,
                RequiredOperations: []
            };

            var promisePostProduct = PandMService.postProduct(Product);
        };

        $scope.saveMaterialEntry = function () {
            var MaterialEntry = {
                Id: 0,
                Name: $scope.materialName
            };

            var promisePostMaterialEntry = PandMService.postMaterialEntry(MaterialEntry);
        };
        
        $scope.materials = PandMService.loadM();

        $scope.saveOperation = function () {
            var Operation = {
                Id: 0,
                Name: $scope.operationName,
                Duration: $scope.operationDuration
            };

            var promisePostOperation = PandMService.postOperation(Operation);
        };

        $scope.displayOperationsCatalog = function () {
            $scope.select = 1;
            var requitedMaterials = PandMService.getMaterialsCatalog();
            requitedMaterials.then(function (result) {
                $scope.materialsCatalog = result.data;
            },
                function (error) {
                    $scope.error = 'could not load prodcuts and materials', error;
                });
        };

        $scope.displayMaterialsCatalog = function () {
            $scope.select = 2;
        };
 
        //The Save scope method used to define the Employee object and 
        //post the Employee information to the server by making call to the Service

        $scope.materials = requiredMaterials;

        $scope.addRequiredMaterial = function () {
            var Material = {
                Name: $scope.selected_material.Name,
                Quantity: $scope.material_quantity
            };
            requiredMaterials.push(Material);
            $scope.requiredMaterials = requiredMaterials;
        };

        $scope.deleteRequiredMaterial = function (material) {
            var index = requiredMaterials.indexOf(material);
            requiredMaterials.splice(index, 1);
        };
    });

angular.module("ProductsModule")
    .controller('ShowPandMController', function ($scope, $location, PandMService) {
        loadPandM();


        $scope.viewDetails = function (subjectOfLabor) {
            var item = PandMService.getProductMaterialByID(subjectOfLabor.Id);
            item.then(function (result) {
                var data = result.data;
            },
                function (error) {
                    $scope.error = 'could not load prodcuts and materials', error;
                });
        };

        function loadPandM()
        {
            var productsAndMaterials = PandMService.getProductsAndMaterials();
            productsAndMaterials.then(function (result) {
                $scope.PandM = result.data;
            },
                function (error) {
                    $scope.error = 'could not load prodcuts and materials', error;
                });
        }
    });
