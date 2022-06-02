var CryptoJS = require("crypto-js");
const fs = require("fs");
const Deleteme = "";
const path_privatizedJsonFormatText = "IOpublishing/privatizedJsonFormat.text";
const path_zDecryptedintJson = "IOpublishing/zDecryptedint.json";

const READPATH = path_privatizedJsonFormatText;
const WRITEPATH = path_zDecryptedintJson;

//-----------------------------------------------------------------------------
var theDecryptedJsonObject_02;
//-----------------------------------------------------------------------------
function DotheQuick() {
  theDecryptedJsonObject_02 = JSON.parse(
    CryptoJS.AES.decrypt(fs.readFileSync(READPATH, "utf8"), Deleteme).toString(
      CryptoJS.enc.Utf8
    )
  );

  fs.writeFile(
    WRITEPATH,
    JSON.stringify(theDecryptedJsonObject_02, null, 4),
    function (err) {
      if (err) {
        console.log(err);
      } else {
        console.log("JSON saved to " + theDecryptedJsonObject_02);
      }
    }
  );
}
DotheQuick();

function testDecrtypted_jsonObject() {
  let mainTexts = theDecryptedJsonObject_02.TextContent.textContent;
  let len = theDecryptedJsonObject_02.TextContent.textContent.length;
  for (var i = 0; i < len; i++) {
    console.log(mainTexts[i].date);
  }
  console.log(theDecryptedJsonObject_02.TextContent.textContent.length);
}

//testDecrtypted_jsonObject();
