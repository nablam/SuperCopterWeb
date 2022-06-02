//import fetch from "node-fetch";
//var data;
const fetch = require("node-fetch");

//http://api.icndb.com/jokes/random
//https://api.chucknorris.io/jokes/random

const urlCategories = "https://api.chucknorris.io/jokes/categories";
const chuckCategories = [
  "animal",
  "career",
  "celebrity",
  "dev",
  "explicit",
  "fashion",
  "food",
  "history",
  "money",
  "movie",
  "music",
  "political",
  "religion",
  "science",
  "sport",
  "travel",
];

const urlNorrisRand = "https://api.chucknorris.io/jokes/random/";
const urlByCategory =
  "https://api.chucknorris.io/jokes/random?category=" + chuckCategories[3];

fetch(urlByCategory)
  .then((response) => response.json())
  .then((data) => {
    console.log(data.value.replace(/Chuck Norris/g, "Nabil"));
    // console.log("secobd");
  });

// const numbs = [1, 2, 3, 4, 5, 7, 6, 8];
// const sum = numbs.reduce((acc, curr) => acc + curr);

// const over20 = numbs.filter((numbs) => numbs > 4);
