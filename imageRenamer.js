const { readdirSync, rename } = require("fs");
const { resolve } = require("path");

const fs1 = require("fs");

let theJSON;
const path_originalInJsonAsJson = "IOpublishing/originalInJsonAs.json"; //IOpublishing\originalInJsonAs.json
const READPATH = path_originalInJsonAsJson;
var t = fs1.readFileSync(READPATH, "utf8");
theJSON = JSON.parse(t);
var totalJsonBlock = theJSON.TextContent.textContent.length;
console.log(totalJsonBlock);

// Get path to image directory
const imageDirPath = resolve(__dirname, "SelectedPageImages"); //SelectedPageImages
// Get an array of the files inside the folder
const files = readdirSync(imageDirPath);
var totalfiles = files.length;
console.log(totalfiles);

for (var b = 0; b < totalJsonBlock; b++) {
  var imagePathname = theJSON.TextContent.textContent[b].image;
  var pathenamelen = imagePathname.length;
  var newname = imagePathname.substr(28 - pathenamelen - 1); // => "Tabs1"

  var oldpath = imageDirPath + "\\" + files[b];
  var newpath = imageDirPath + "\\" + newname;
  fs1.renameSync(oldpath, newpath);
}

// Loop through each file that was retrieved
// files.forEach((file) =>
//   rename(
//     imageDirPath + `/${file}`,
//     imageDirPath + `/${file.toLowerCase()}`,
//     (err) => console.log(err)
//   )
// );
