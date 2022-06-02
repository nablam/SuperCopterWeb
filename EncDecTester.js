var CryptoJS = require("crypto-js");
const fs = require("fs");

const path_originaltext = "IObasic/original.text";
const path_originalInJsonAsJson = "IObasic/originalInJsonAs.json";
const path_originalInJsonAsText = "IObasic/originalInJsonAs.text";
const path_privatizedJsonFormatText = "IObasic/privatizedJsonFormat.text";
const path_zDecryptedintJson = "IObasic/zDecryptedint.json";
const path_zDecryptedintotext = "IObasic/zDecryptedinto.text";

const pathOutJasonish = path_originalInJsonAsJson;
const READPATH = path_originaltext;
let TEXTLINES_00 = [];
var FULLJSON_00 = [];
let id_int_00 = 0;
let year_str_00 = "";
let title_str_00 = "";
let text_str_00 = "";
let oneof4_00 = -1;

function Do_original_to_JSON_00() {
  clearOutputJASONISH_00();
  start_originalTextTOJasonFormat_00();
}

function start_originalTextTOJasonFormat_00() {
  ReadandSaveLinesFromText_00();
  PushPrefix_00();
  PopulateBlocks_00();
  TPushSufixtfix_00();
  DoWriteJASONish_00();
}

function ReadandSaveLinesFromText_00() {
  var text = fs.readFileSync(READPATH, "utf8");
  TEXTLINES_00 = text.split(/\r\n|\n/);
}

function PushPrefix_00() {
  FULLJSON_00.push("{");
  FULLJSON_00.push('  "TextContent": {');
  FULLJSON_00.push('    "textContent": [');
}
function PopulateBlocks_00() {
  for (var line = 0; line < TEXTLINES_00.length - 1; line++) {
    oneof4_00 = line % 4;
    if (oneof4_00 == 0) {
      year_str_00 = TEXTLINES_00[line];
    } else if (oneof4_00 == 1) {
      title_str_00 = TEXTLINES_00[line];
    } else if (oneof4_00 == 2) {
      text_str_00 = TEXTLINES_00[line];
      id_int_00++;
      PushBlocksToFULLJSON_00(
        id_int_00,
        year_str_00,
        title_str_00,
        text_str_00
      );
    } else if (oneof4_00 == 3) {
    }
  }
}
function PushBlocksToFULLJSON_00(argId, argDate, argTitle, argText) {
  var titleNoSpaces = argTitle.replace(/\s/g, "");
  FULLJSON_00.push("      {");
  FULLJSON_00.push('        "id": "' + argId + '",');
  FULLJSON_00.push('        "category":"LifeTechArt",');
  FULLJSON_00.push(
    '        "subcategory":"PublicPersonal_HardwareSoftware_ClassicCad",'
  );
  FULLJSON_00.push('        "ctype":"personalProject_Work_Schooling",');
  FULLJSON_00.push('        "date": "' + argDate + '",');
  FULLJSON_00.push('        "title": "' + argTitle + '",');
  FULLJSON_00.push('        "photo": "",');
  FULLJSON_00.push('        "maintext_short":"",');
  FULLJSON_00.push('        "maintext_Long":"' + argText + '",');
  FULLJSON_00.push(
    '        "linkToPage":"/SelectedPages/Page_' + titleNoSpaces + '.html",'
  );
  FULLJSON_00.push('        "page_lable":"lbl_' + argId + '"');
  FULLJSON_00.push("      },");
}

function TPushSufixtfix_00() {
  FULLJSON_00.push("    ]");
  FULLJSON_00.push("  }");
  FULLJSON_00.push("}");
}

function DoWriteJASONish_00() {
  FULLJSON_00[FULLJSON_00.length - 4] = FULLJSON_00[
    FULLJSON_00.length - 4
  ].slice(0, -1);
  for (var i = 0; i < FULLJSON_00.length; i++) {
    fs.appendFileSync(pathOutJasonish, FULLJSON_00[i] + "\r\n", (err) => {
      if (err) console.log(err);
      else {
        console.log("File written original to JSON successfully\n");
      }
    });
  }
}

function clearOutputJASONISH_00() {
  const content = "";

  fs.writeFile(pathOutJasonish, content, (err) => {
    if (err) {
      console.error(err);
    }
    // file written successfully
  });
}

//----------------------------------------------------------------------------
//Do_original_to_JSON();   //will take original text and make json
//----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
//lets encryypt
//-----------------------------------------------------------------------------

var readJsonObject_01;
var JSONdataStringed_01;
function Do_Encrypt_saved_JSONfile_01() {
  readJsonObject_01 = JSON.parse(
    fs.readFileSync(path_originalInJsonAsJson, "utf8")
  );

  JSONdataStringed_01 = JSON.stringify(readJsonObject_01);

  var encrypted = CryptoJS.AES.encrypt(JSONdataStringed_01, "key").toString();

  fs.writeFile(path_privatizedJsonFormatText, encrypted, (err) => {
    if (err) {
      console.error(err);
    }
    console.log("file written successfully");
  });
  console.log("file written successfully");
}
//-----------------------------------------------------------------------------
// Do_Encrypt_saved_JSONfile_01();  //will take the json file and  make private.txt
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
//lets dencryypt
//-----------------------------------------------------------------------------

var theDecryptedJsonObject_02;
function ReadandSaveLinesFromText_02() {
  theDecryptedJsonObject_02 = JSON.parse(
    CryptoJS.AES.decrypt(
      fs.readFileSync(path_privatizedJsonFormatText, "utf8"),
      "key"
    ).toString(CryptoJS.enc.Utf8)
  );
}

//-----------------------------------------------------------------------------
// ReadandSaveLinesFromText_02(); //will decrypt and read saved private
//-----------------------------------------------------------------------------

  function testDecrtypted_jsonObject() {
    let mainTexts = theDecryptedJsonObject_02.TextContent.textContent;
    let len = theDecryptedJsonObject_02.TextContent.textContent.length;
    for (var i = 0; i < len; i++) {
      console.log(mainTexts[i].date);
    }
    console.log(theDecryptedJsonObject_02.TextContent.textContent.length);
  }
