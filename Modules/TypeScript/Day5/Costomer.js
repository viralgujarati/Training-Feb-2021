"use strict";
exports.__esModule = true;
exports.cust = void 0;
var customer = [
    { cusId: 1, cusName: "viral", cusCity: "rajkot", totcus: 2 },
    { cusId: 2, cusName: "Rahul", cusCity: "Ahmedabad", totcus: 5 },
    { cusId: 3, cusName: "Rohit", cusCity: "Gondal", totcus: 1 }
];
//for booking tables 
var cust = /** @class */ (function () {
    function cust() {
    }
    cust.prototype.bookTable = function (n) {
        console.log("online table booking: ");
        console.log("token for your booking:");
        //for token generation 
        function getToken(length) {
            return Math.floor(Math.random() * length);
        }
        var cusid = cust.filter(function (a) { return a.cusName == n; });
        if (n == null) {
            console.log("Please enter valid name for booking");
        }
        else {
            console.log("Customer ID " + cusid[1].cusName + " have booked tabel");
            console.log("Booking token is:", getToken(10));
        }
        // function getToken(length){
        //     var result=[];
        //     var numbers = 123456789;
        //     var numbersLength = numbers.length;
        //     for (var i=0; i<length; i++){
        //         return.push()
    };
    cust.filter = function (arg0) {
        throw new Error("Method not implemented.");
    };
    return cust;
}());
exports.cust = cust;
