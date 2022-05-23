//https://www.npmjs.com/package/crypto-js
// npm install crypto-js
var CryptoJS = require("crypto-js");
const fs = require("fs");

const pathOutJasonish = "JASON.json";
const pathlockedJASON = "lockedJASON.txt";
var JSONdata;
var JSONdataStringed;

function ReadandSaveLinesFromText() {
  var text = fs.readFileSync(pathOutJasonish, "utf8");
  JSONdata = JSON.parse(text);
}
ReadandSaveLinesFromText();
JSONdataStringed = JSON.stringify(JSONdata);

// console.log(JSONdataStringed);

var encrypted = CryptoJS.AES.encrypt(JSONdataStringed, "key").toString();

fs.writeFile(pathlockedJASON, encrypted, (err) => {
  if (err) {
    console.error(err);
  }
  console.log("file written successfully");
});