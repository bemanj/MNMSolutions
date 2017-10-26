function ProductsController($scope, $timeout, $rootScope, $window, $http) {
    // Modules/Panel
    $scope.ProductsList = true;

    var url = "http://localhost:57483/";

    // Invoke function
    //selectStudentDetails($scope.stdName, $scope.stdemail); // uncomment to show sales orders list
    getProductsList();

    // Get Products List
    function getProductsList() {

        $http.get(url + "api/products/")
            .then(function (data) {
                $scope.Product = data;

                $scope.showStudentAdd = false;
                $scope.addEditStudents = false;
                $scope.ProductsList = true;
                $scope.showItem = false;

                if ($scope.Product.length > 0) {

                }

            }, function (error) {
                $scope.error = error + " An Error has occured while loading posts!";
            });
    }

    
};