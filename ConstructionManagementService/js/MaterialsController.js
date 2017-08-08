app.controller('MaterialsController', function ($scope, $location, AdminService, ShareData) {
    loadAllLookupTypeRecords();

    function loadAllMaterialRecords() {
        var promiseGetMaterials = AdminService.getMaterials();

        promiseGetMaterials.then(function (pl) { $scope.Material = pl.data },
            function (errorPl) {
                $scope.error = errorPl;
            });
    }

    //To Edit Student Information   
    $scope.editMaterial = function (MaterialId) {
        ShareData.value = materialId;
        $location.path("/editLookupType");
    }

    //To Delete a Student   
    $scope.deleteMaterial = function (materialId) {
        ShareData.value = materialId;
        $location.path("/deleteMaterial");
    }
});