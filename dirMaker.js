//uncomment to run, beware !
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
const imageDirPath = resolve(__dirname, "imagesFromDalle"); //SelectedPageImages

for (var b = 0; b < totalJsonBlock; b++) {
  var projecttitle = theJSON.TextContent.textContent[b].title.replace(
    /\s/g,
    "_"
  );

  //  var dir = __dirname + "\\" + "imagesFromDalle" + "\\" + projecttitle;
  //   if (!fs1.existsSync(dir)) {
  //     fs1.mkdirSync(dir);
  //   }
  console.log(dir);
}
console.log("done making " + totalJsonBlock + "directories for images");
