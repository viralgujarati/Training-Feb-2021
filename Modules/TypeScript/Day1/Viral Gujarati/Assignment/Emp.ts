
var emp = [
    {Id:1, FirstName:"Viral", LastName:"Gujarati", Address:"Rajkot", Salary: 20000},
    {Id:2, FirstName:"Rahul", LastName:"Raval", Address:"Surat", Salary: 21000},
    {Id:3, FirstName:"Krishna", LastName:"Gabani", Address:"Gondal", Salary: 15000},
    {Id:4, FirstName:"Radha", LastName:"Patel", Address:"Rajkot", Salary: 16000},
    {Id:5, FirstName:"Mayur", LastName:"Patel", Address:"Ahmedabad", Salary: 25000}
];

// Do the operation searching by indexnumber, EmployeeID, Insert the employee, delete the employee from the Array.
//1.serching 
//console.log("Emmployee:",emp[1])
//2.Insert
//emp.push({Id:6, FirstName:"Jay",LastName:"patel",Address:"Goa",Salary:23000})
//3.Delete
//emp.pop(emp)
// Create one more array emp and join the value with above array. When display list combine firstname and lastname as fullname,
//new array
//var newemp = [
//    {Id:1, FirstName:"Kunal", LastName:"Patel", Address:"Ahmedabad", Salary: 22000}
//
//];
//
//var employee = emp.concat(newemp);
//
//console.log("employee:",employee);

var fname = emp[0].FirstName;
var lname = emp[0].LastName;

function fullname(){
    var fullname = `${fname}${lname}`;
    return fullname;
}

console.log(fullname());
// From the address field flatnumber,city,state and should be splited.
//PF should be computed and total salary should be display