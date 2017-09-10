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
    $scope.stdNames = "";
    $scope.stdEmails = "";
    $scope.Phones = "";
    $scope.Addresss = "";

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
    $scope.studentEdit = function(studentId, name, email, phone, address) {
        cleardetails();
        $scope.StdIDs = studentId;
        $scope.stdNames = name;
        $scope.stdEmails = email;
        $scope.Phones = phone;
        $scope.Addresss = address;

        $scope.showStudentAdd = true;
        $scope.addEditStudents = true;
        $scope.StudentsList = true;
        $scope.showItem = true;
    }

    //Delete Dtudent Detail
    $scope.studentDelete = function(studentId, name) {
        cleardetails();
        $scope.StdIDs = studentId;
        var delConfirm = confirm('Are you sure you want to delete the Student ' + name + ' ?');
        if (delConfirm) {

            $http.get(url + 'api/students/deleteStudent/', { params: { stdID: $scope.StdIDs } }).success(function (data) {
                alert('Student Deleted Successfully!!');
                cleardetails();
                selectStudentDetails('', '');
            })
                .error(function () {
                    $scope.error = "An Error has occured while loading posts!";
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
        $scope.StdIDs = 0;
        $scope.stdNames = "";
        $scope.stdEmails = "";
        $scope.Phones = "";
        $scope.Addresss = "";
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
        if ($scope.IsFormValid) {
            //if the SalesOrderID=0 means its new SO insert here i will call the Web api insert method
            if ($scope.StdIDs == 0) {

                $http.post(url + 'api/SalesOrderHeaders/',
                    {
                        params: {
                            SalesOrderID: 1
                            , OrderDate: getDate()
                            , OnlineOrderFlag: true
                            , SalesOrderNumber: 'SO1'
                            , SubTotal: 100
                            , TaxAmt: 30
                            , Freight: 50
                            , TotalDue: 180
                            , Comment: 'test'
                            , ModifiedDate: getDate()
                        }
                    }).then(function (data) {

                        $scope.StudentsInserted = data;
                        alert($scope.StudentsInserted);

                        cleardetails();
                        selectStudentDetails('', '');

                    },function(error)
                    {
                        $scope.error = error + ' An Error has occured while loading posts!';
                    });

            } else {  // to update to the student details
                $http.get('/api/students/updateStudent/',
                    {
                        params: {
                            stdID: $scope.StdIDs,
                            StudentName: $scope.stdNames,
                            StudentEmail: $scope.stdEmails,
                            Phone: $scope.Phones,
                            Address: $scope.Addresss
                        }
                    }).then(function(data) {
                        $scope.StudentsUpdated = data;
                        alert($scope.StudentsUpdated);

                        cleardetails();
                        selectStudentDetails('', '');

                    },function(error) {
                        $scope.error = error + ' An Error has occured while loading posts!';

                    });
            }

        } else {
            $scope.Message = 'All the fields are required.';
        }


    }

});