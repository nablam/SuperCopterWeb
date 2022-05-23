// const api = require("chuck_norris_api");
// api.getRandom(options).then(function (data) {
//   console.log(data.value.joke);
// });
//https://api.chucknorris.io/jokes/random
//http://api.icndb.com/jokes/random
//http://api.icndb.com/jokes/random?exclude=[nerdy]
// http://api.icndb.com/jokes/random?exclude=[nerdy,explicit]
//Fetching the list of joke categories
//http://api.icndb.com/categories

// const api_url = "https://employeedetails.free.beeceptor.com/my/api/path";

// // Defining async function
// async function getapi(url) {
//   // Storing response
//   const response = await fetch(url);

//   // Storing data in form of JSON
//   var data = await response.json();
//   console.log(data);
//   if (response) {
//     hideloader();
//   }
//   show(data);
// }
// // Calling that async function
// getapi(api_url);

// // Function to hide the loader
// function hideloader() {
//   document.getElementById("loading").style.display = "none";
// }
// // Function to define innerHTML for HTML table
// function show(data) {
//   let tab = `<tr>
//           <th>Name</th>
//           <th>Office</th>
//           <th>Position</th>
//           <th>Salary</th>
//          </tr>`;

//   // Loop to access all rows
//   for (let r of data.list) {
//     tab += `<tr>
//     <td>${r.name} </td>
//     <td>${r.office}</td>
//     <td>${r.position}</td>
//     <td>${r.salary}</td>
// </tr>`;
//   }
//   // Setting innerHTML as tab variable
//   document.getElementById("employees").innerHTML = tab;
// }
