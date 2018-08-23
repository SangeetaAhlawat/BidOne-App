app.controller("formsubmitCtrl", function($scope,appService) {

	$scope.submitForm=function(){
		var dataObj={
			firstName:$scope.firstName,
			lastName:$scope.lastName,
		};
		
		appService.submitForm(dataObj).then(function (response) {		    
		    alert("Form data saved successfully in file : " + response.xhrStatus);
		    $scope.firstName = '';
		    $scope.lastName = '';
			//you can put the response in scope here
		});
		
	}

}); // closing controller
	


