var CryptoJS = require("crypto-js");
const fs = require("fs");

const Deleteme = "";

const path_originaltext = "IObasic/original_X.txt";
const path_originalInJsonAsJson = "IOpublishing/originalInJsonAs.json";

const path_privatizedJsonFormatText = "IOpublishing/privatizedJsonFormat.text";

const pathOutJasonish = path_originalInJsonAsJson;
const READPATH = path_originaltext;
let TEXTLINES_00 = [];
var FULLJSON_00 = [];
let id_int_00 = 0;
let year_str_00 = "";
let category_str_00 = "";
let title_str_00 = "";
let text_str_00 = "";
let oneof4_00 = -1;

function Do_original_to_JSON_00() {
  clearOutputJASONISH_00();
  clearOutputPrivatized_00();
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
    oneof4_00 = line % 5;
    if (oneof4_00 == 0) {
      year_str_00 = TEXTLINES_00[line];
    } else if (oneof4_00 == 1) {
      category_str_00 = TEXTLINES_00[line];
    } else if (oneof4_00 == 2) {
      title_str_00 = TEXTLINES_00[line];
    } else if (oneof4_00 == 3) {
      text_str_00 = TEXTLINES_00[line];
      id_int_00++;
      PushBlocksToFULLJSON_00(
        id_int_00,
        year_str_00,
        category_str_00,
        title_str_00,
        text_str_00
      );
    } else if (oneof4_00 == 4) {
    }
  }
} //SelectedPageImages images/SelectedPageImages/imagePage_test.jpg
//                   SelectedPages\ProjectsTimeline02.html
function PushBlocksToFULLJSON_00(argId, argDate, argCat, argTitle, argText) {
  var titleNoSpaces = argTitle.replace(/\s/g, "");
  var shortText = argText.substring(0, 246) + " ...";

  var _separated_arra = argCat.split("_");
  var theauth = _separated_arra[1];
  var thecategory = _separated_arra[2];
  var _arra_size = _separated_arra.length;
  var subcats = _separated_arra.slice(2, _arra_size);
  var the_subcats_ = "";
  var title_with_underscored_name = argTitle.replace(/\s/g, "_");
  var _path_daleimage =
    "/images/imagesFromDalle/" +
    title_with_underscored_name +
    "/" +
    title_with_underscored_name +
    "_0_";
  for (var x = 0; x < subcats.length; x++) {
    the_subcats_ += "_" + subcats[x];
  }
  FULLJSON_00.push("      {");
  FULLJSON_00.push('        "id": "' + argId + '",');
  FULLJSON_00.push('        "category":"' + thecategory + '",');
  FULLJSON_00.push('        "subcategory":"' + the_subcats_ + '",');
  FULLJSON_00.push('        "ctype":"' + theauth + '",');
  FULLJSON_00.push('        "date": "' + argDate + '",');
  FULLJSON_00.push('        "title": "' + argTitle + '",');
  FULLJSON_00.push('        "image":"' + _path_daleimage + '.png",');
  FULLJSON_00.push('        "maintext_short":"' + shortText + '",');
  FULLJSON_00.push('        "maintext_Long":"' + argText + '",');
  FULLJSON_00.push(
    '        "linkToPage":"/SelectedPages/ProjectPages/Page_' +
      titleNoSpaces +
      '.html",'
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
  const content2 = "";

  fs.writeFile(pathOutJasonish, content2, (err) => {
    if (err) {
      console.error(err);
    }
    // file written successfully
  });
}

function clearOutputPrivatized_00() {
  const contenttemp = "";

  fs.writeFile(path_privatizedJsonFormatText, contenttemp, (err) => {
    if (err) {
      console.error(err);
    }
    // file written successfully
  });
}

//----------------------------------------------------------------------------
Do_original_to_JSON_00(); //will take original text and make json
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

  var encrypted = CryptoJS.AES.encrypt(
    JSONdataStringed_01,
    Deleteme
  ).toString();

  fs.writeFile(path_privatizedJsonFormatText, encrypted, (err) => {
    if (err) {
      console.error(err);
    }
    console.log("file written successfully");
  });
  console.log("file written successfully");
}
//-----------------------------------------------------------------------------
Do_Encrypt_saved_JSONfile_01(); //will take the json file and  make private.txt
//-----------------------------------------------------------------------------
