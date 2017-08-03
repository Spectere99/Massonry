app.controller('LookupTypesController', function ($scope, $location, AdminService, ShareData) {
    loadAllLookupTypeRecords();

    function loadAllLookupTypeRecords() {
        var promiseGetLookupTypes = AdminService.getLookupTypes();

        promiseGetLookupTypes.then(function (pl) { $scope.lookupType = pl.data },
            function (errorPl) {
                $scope.error = errorPl;
            });
    }

    //To Edit Student Information   
    $scope.editLookupType = function (lookupTypeId) {
        ShareData.value = lookupTypeId;
        $location.path("/editLookupType");
    }

    //To Delete a Student   
    $scope.deleteLookupType = function (lookupTypeId) {
        ShareData.value = lookupTypeId;
        $location.path("/deleteLookupType");
    }
});