const fs = require("fs");
const path0 = "TextLines_57ids_mintext_Full.txt";
const path1 = "TextLines_3ids_mintext_test.txt";
const path2 = "TextLines_fromDocks.txt";
// const pathOutJasonish = "JASONish.txt";
const pathOutJasonish = "JASON.json";
const READPATH = path2;
let TEXTLINES = [];
var FULLJSON = [];
let id_int = 0;
let year_str = "";
let title_str = "";
let text_str = "";
let oneof4 = -1;

clearOutputJASONISH();
start();

function start() {
  ReadandSaveLinesFromText();
  PushPrefix();
  PopulateBlocks();
  TPushSufixtfix();
  DoWriteJASONish();
}

function ReadandSaveLinesFromText() {
  var text = fs.readFileSync(READPATH, "utf8");
  TEXTLINES = text.split(/\r\n|\n/);
}

function PushPrefix() {
  FULLJSON.push("{");
  FULLJSON.push('  "TextContent": {');
  FULLJSON.push('    "textContent": [');
}
function PopulateBlocks() {
  for (var line = 0; line < TEXTLINES.length - 1; line++) {
    oneof4 = line % 4;
    if (oneof4 == 0) {
      year_str = TEXTLINES[line];
    } else if (oneof4 == 1) {
      title_str = TEXTLINES[line];
    } else if (oneof4 == 2) {
      text_str = TEXTLINES[line];
      id_int++;
      PushBlocksToFULLJSON(id_int, year_str, title_str, text_str);
    } else if (oneof4 == 3) {
    }
  }
}
function PushBlocksToFULLJSON(argId, argDate, argTitle, argText) {
  var titleNoSpaces = argTitle.replace(/\s/g, "");
  FULLJSON.push("      {");
  FULLJSON.push('        "id": "' + argId + '",');
  FULLJSON.push('        "category":"LifeTechArt",');
  FULLJSON.push(
    '        "subcategory":"PublicPersonal_HardwareSoftware_ClassicCad",'
  );
  FULLJSON.push('        "ctype":"personalProject_Work_Schooling",');
  FULLJSON.push('        "date": "' + argDate + '",');
  FULLJSON.push('        "title": "' + argTitle + '",');
  FULLJSON.push('        "photo": "",');
  FULLJSON.push('        "maintext_short":"",');
  FULLJSON.push('        "maintext_Long":"' + argText + '",');
  FULLJSON.push(
    '        "linkToPage":"/SelectedPages/Page_' + titleNoSpaces + '.html",'
  );
  FULLJSON.push('        "page_lable":"lbl_' + argId + '"');
  FULLJSON.push("      },");
}

function TPushSufixtfix() {
  FULLJSON.push("    ]");
  FULLJSON.push("  }");
  FULLJSON.push("}");
}

function DoWriteJASONish() {
  FULLJSON[FULLJSON.length - 4] = FULLJSON[FULLJSON.length - 4].slice(0, -1);
  for (var i = 0; i < FULLJSON.length; i++) {
    fs.appendFileSync(pathOutJasonish, FULLJSON[i] + "\r\n", (err) => {
      if (err) console.log(err);
      else {
        console.log("File written successfully\n");
      }
    });
  }
}

function clearOutputJASONISH() {
  const content = "";

  fs.writeFile(pathOutJasonish, content, (err) => {
    if (err) {
      console.error(err);
    }
    // file written successfully
  });
}
