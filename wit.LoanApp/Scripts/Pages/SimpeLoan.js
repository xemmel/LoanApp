var SimpleLoanCtrl = function ($scope,$http) {
  $scope.x = "Clara";
  $scope.G = 2391000;
  $scope.years = 30;
  $scope.paymentsYear = 4;
  $scope.InterestPercent = 2.5;
  $scope.r = ($scope.InterestPercent /100) / $scope.paymentsYear;
  $scope.n = $scope.years * $scope.paymentsYear;
  $scope.y = 0;
  $scope.interestTotal = 0;
  $scope.payTotal = 0;
  $scope.terms = [];

  $scope.calculate = function () {

    $http({ method: "GET", url: "getAnnoLoan", params: { "G": $scope.G, "r": ($scope.InterestPercent / 100) / $scope.paymentsYear, "n": $scope.years * $scope.paymentsYear } }).
      success(function (data) {
       // console.log("Success");
        //  console.dir(data);
        $scope.y = data;
       //$scope.interestTotal = 10;
      }).
      error(function (data) {
        console.log("Error");
        console.log(data);


      });

    $http({ method: "GET", url: "GetTerms", params: { "G": $scope.G, "r": ($scope.InterestPercent / 100) / $scope.paymentsYear, "n": $scope.years * $scope.paymentsYear } }).
      success(function (data) {
         console.log("Success");
            console.dir(data);
            $scope.terms = data;
            var index;
            $scope.interestTotal = 0;
            $scope.payTotal = 0;
            for (index = 0; index < data.length; index++) {
              $scope.interestTotal += data[index].Interest;
              $scope.payTotal += data[index].Payment;
            }


      }).
      error(function (data) {
        console.log("Error");
        console.log(data);


      });

  };
};