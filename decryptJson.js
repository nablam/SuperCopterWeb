//https://www.npmjs.com/package/crypto-js
// npm install crypto-js
var CryptoJS = require("crypto-js");
const fs = require("fs");

const pathlockedJASON = "IOfiles/textfiles/lockedJASON2.txt";
const pathUNlockedJASON = "IOfiles/textfiles/UnlockedJASON2.txt";
//const pathUNlockedJASON =  "IOfiles/jsonfiles/UnlockedJASON2.json";

var EncruptedTExtdat;

function ReadandSaveLinesFromText() {
  EncruptedTExtdat = fs.readFileSync(pathlockedJASON, "utf8");
}
ReadandSaveLinesFromText();

// console.log(JSONdataStringed);

var decrypted = CryptoJS.AES.decrypt(EncruptedTExtdat, "key").toString(
  CryptoJS.enc.Utf8
);

fs.writeFile(pathUNlockedJASON, decrypted, (err) => {
  if (err) {
    console.error(err);
  }
  console.log("file written successfully");
});
console.log("file written successfully");
