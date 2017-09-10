// <reference path="../angular.js" />  
/// <reference path="../angular.min.js" />   
/// <reference path="../angular-animate.js" />   
/// <reference path="../angular-animate.min.js" />   


"use strict";
var app;


(function () {
    app = angular.module("RESTClientModule", ['ngAnimate']);
})();


app.controller("AngularJs_studentsController", function ($scope, $timeout, $rootScope, $window, $http) {
    $scope.date = new Date();
    $scope.MyName = "shanu";
    $scope.stdName = "";
    $scope.stdemail = "";

    $scope.showStudentAdd = true;
    $scope.addEditStudents = false;
    $scope.StudentsList = true;
    $scope.showItem = true;

    //This variable will be used for Insert/Edit/Delete Students details.
    $scope.StdIDs = 0;
    $scope.stdNames = '';
    $scope.stdEmails = '';
    $scope.Phones = '';
    $scope.Addresss = '';

    $scope.soSalesOrderID = 0;
    $scope.soSalesOrderNumber = '';
    $scope.soSubTotal = 0;
    $scope.soTaxAmt = 0;
    $scope.soFreight = 0;
    $scope.soTotalDue = 0;
    $scope.soComment = '';

    var url = "http://localhost:57483/";

    selectStudentDetails($scope.stdName, $scope.stdemail);

    function selectStudentDetails() {

        $http.get(url + "api/salesorderheaders/")
            .then(function(data) {
                    $scope.SalesOrder = data;

                    $scope.showStudentAdd = true;
                    $scope.addEditStudents = false;
                    $scope.StudentsList = true;
                    $scope.showItem = true;

                    if ($scope.SalesOrder.length > 0) {

                    }

            },function(error) {
                    $scope.error = error + " An Error has occured while loading posts!";
            });
    }


    //Search
    $scope.searchStudentDetails = function () {

        selectStudentDetails($scope.stdName, $scope.stdemail);
    }

    //Edit Student Details
    // id, sub, tax, freight, comment
    $scope.soEdit = function(salesOrderId, salesOrderNumber, subTotal, taxAmt, freight, comment) {
        cleardetails();
        $scope.soSalesOrderID = salesOrderId;
        $scope.soSalesOrderNumber = salesOrderNumber;
        $scope.soSubTotal= subTotal;
        $scope.soTaxAmt = taxAmt;
        $scope.soFreight= freight;
        $scope.soComment = comment;

        $scope.showStudentAdd = true;
        $scope.addEditStudents = true;
        $scope.StudentsList = true;
        $scope.showItem = true;
    }

    //Delete Dtudent Detail
    $scope.soDelete = function(salesOrderId, salesOrderNumber) {
        cleardetails();
        $scope.soSalesOrderID = salesOrderId;
        //$scope.soSalesOrderNumber = salesOrderNumber;
        var delConfirm = confirm('Are you sure you want to delete the Sales Order #: ' + salesOrderNumber + ' ?');
        if (delConfirm) {

            $http.delete(url + 'api/salesOrderHeaders?id=' + salesOrderId)
                .then(function (data) {
                    alert('SO deleted successfully!' + data.statusText);
                    cleardetails();
                    selectStudentDetails('', '');
                },function(error) {
                        $scope.error = error + " An Error has occured while loading posts!";

                });

        }
    }

    // New Student Add Details
    $scope.showStudentDetails = function () {
        cleardetails();
        $scope.showStudentAdd = true;
        $scope.addEditStudents = true;
        $scope.StudentsList = true;
        $scope.showItem = true;


    }

    //clear all the control values after insert and edit.
    function cleardetails() {
        $scope.soSalesOrderID = 0;
        $scope.soSalesOrderNumber = '';
        $scope.soSubTotal = '';
        $scope.soTaxAmt = '';
        $scope.soFreight = '';
        $scope.soComment= '';
    }

    //Form Validation
    $scope.Message = '';
    $scope.IsFormSubmitted = false;

    $scope.IsFormValid = false;


    $scope.$watch('f1.$valid', function (isValid) {
        $scope.IsFormValid = isValid;

    });

    //Save Student
    $scope.saveDetails = function () {

        $scope.IsFormSubmitted = true;
        var config;
        var data = {
            //SalesOrderID: 1
            //, OrderDate: getDate()
            //, OnlineOrderFlag: true
            //, SalesOrderNumber: 'SO1'
            SubTotal: $scope.soSubTotal,
            TaxAmt: $scope.soTaxAmt,
            Freight: $scope.soFreight,
            //TotalDue: soTotalDue,
            Comment: $scope.soComment
            //, ModifiedDate: getDate()
        }

        if ($scope.IsFormValid) {
            //if the SalesOrderID=0 means its new SO insert here i will call the Web api insert method
            if ($scope.soSalesOrderID == 0) {

                config = {
                    method: 'POST',
                    url: url + 'api/SalesOrderHeaders/',
                    data: data,
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8'
                    }
                };

                $http(config)
                    .then(function (data) {

                        $scope.StudentsInserted = data;
                        alert($scope.StudentsInserted.statusText);

                        cleardetails();
                        selectStudentDetails('', '');

                    },function(error)
                    {
                        $scope.error = error + ' An Error has occured while loading posts!';
                    });

            } else {  // to update to the student details

                data = {
                    SalesOrderID: $scope.soSalesOrderID
                    , SubTotal: $scope.soSubTotal
                    , TaxAmt: $scope.soTaxAmt
                    , Freight: $scope.soFreight
                    , Comment: $scope.soComment
                    , ModifiedDate: new Date()
                }
                config = {
                    method: 'PUT',
                    url: url + 'api/SalesOrderHeaders',
                    data: data,
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8'
                    }
                };

                $http(config)
                    .then(function (data) {

                        $scope.soUpdated = data;

                        if ($scope.soUpdated.statusText == 'No Content') {
                            alert('Update complete');
                        }

                        cleardetails();
                        selectStudentDetails('', '');

                    }, function (error) {
                        $scope.error = error + ' An Error has occured while loading posts!';
                    });

                //$http.get('/api/students/updateStudent/',
                //    {
                //        params: {
                //            stdID: $scope.StdIDs,
                //            StudentName: $scope.stdNames,
                //            StudentEmail: $scope.stdEmails,
                //            Phone: $scope.Phones,
                //            Address: $scope.Addresss
                //        }
                //    }).then(function(data) {
                //        $scope.StudentsUpdated = data;
                //        alert($scope.StudentsUpdated);

                //        cleardetails();
                //        selectStudentDetails('', '');

                //    },function(error) {
                //        $scope.error = error + ' An Error has occured while loading posts!';

                //    });
            }

        } else {
            $scope.Message = 'All the fields are required.';
        }


    }

});