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

const imageDirPath = resolve(__dirname, "IOpublishing");

var ControlDocText="";
for (var b = 0; b < totalJsonBlock; b++) {
  var ControlLine = "0_" + "title";

  ControlDocText += BuildControlDoc(
    theJSON.TextContent.textContent[b].title,
    theJSON.TextContent.textContent[b].page_lable
  );
  //console.log("BEWARE UNCOMMENT NEXT" + ControlDocText);

  fs1.writeFileSync("IOpublishing/CtrlDoc.txt", ControlDocText);
}
console.log("done makin pages");

function BuildControlDoc(argTitletext, argLable) {
  var titleNOspaces = argTitletext.replace(/\s/g, "");

  return "0_" + argTitletext.replace(/\s/g, "") + "_" + argLable + "\n";
}
