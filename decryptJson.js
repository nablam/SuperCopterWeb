//https://www.npmjs.com/package/crypto-js
// npm install crypto-js
var CryptoJS = require("crypto-js");
const fs = require("fs");

const pathUNlockedJASON = "UnlockedJASON.txt";
var EncruptedTExtdat;

function ReadandSaveLinesFromText() {
  EncruptedTExtdat = fs.readFileSync(pathReadLockedJSON, "utf8");
}
ReadandSaveLinesFromText();

// console.log(JSONdataStringed);

var decrypted = CryptoJS.AES.decrypt(EncruptedTExtdat, "key").toString();

fs.writeFile(pathUNlockedJASON, decrypted, (err) => {
  if (err) {
    console.error(err);
  }
  console.log("file written successfully");
});
