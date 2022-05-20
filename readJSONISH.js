const fs = require("fs");
const pathOutJasonish = "JASON.json";
var JSONdata;

function ReadandSaveLinesFromText() {
  var text = fs.readFileSync(pathOutJasonish, "utf8");
  var tempdat = JSON.parse(text);
  JSONdata = tempdat.TextContent.textContent;
}

ReadandSaveLinesFromText();
// at this point I have an object JSONdata as an array of all my blocks
// .id;
// .category; // LifeTechArt
// .subcategory; // PublicPersonal_HardwareSoftware_ClassicCad
// .ctype; personalProject_Work_Schooling
// .date;  // xxxx xx
// .title;
// .photo;
// .maintext_short;
// .maintext_Long ;
// .linkToPage; // /SelectedPages/Page_ + titleNoSpaces + .html
// .page_lable; // lbl_' + argId
console.log(JSONdata[0].id);
