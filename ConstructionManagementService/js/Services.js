app.service("AdminService", function ($http) {

    //Read all LookupTypes  
    this.getLookupTypes = function () {

        return $http.get("/api/LookupTypeAPI");
    };

    //Fundction to Read LookupTypes by LookupType ID   
    this.getStudent = function (id) {
        return $http.get("/api/LookupTypeAPI/" + id);
    };

    //Function to create new Student   
    this.post = function (lookupType) {
        var request = $http({
            method: "post",
            url: "/api/LookupTypeAPI",
            data: lookupType
        });
        return request;
    };

    //Edit Student By ID    
    this.put = function (id, lookupType) {
        var request = $http({
            method: "put",
            url: "/api/LookupTypeAPI/" + id,
            data: lookupType
        });
        return request;
    };

    //Delete Student By Student ID   
    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: "/api/LookupTypeAPI/" + id
        });
        return request;
    };
});