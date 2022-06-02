//uncomment to run, beware !
// /SelectedPages/ProjectPages/Page_AlienExplorerAndroidGame.html
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
const imageDirPath = resolve(__dirname, "IObasic");

for (var b = totalJsonBlock - 1; b >= 0; b--) {
  var PagenameOUTpath = imageDirPath + "\\PageArticlesSNIPETS.html";

  var builtHTML =
    buildArticlev2(
      theJSON.TextContent.textContent[b].title,
      theJSON.TextContent.textContent[b].maintext_short,
      theJSON.TextContent.textContent[b].page_lable,
      theJSON.TextContent.textContent[b].date
    ) + "\r\n";
  console.log("" + b + " done");
  //console.log(builtHTML);

  fs1.appendFileSync(PagenameOUTpath, builtHTML);
}
console.log("");
console.log("");
console.log("done making " + totalJsonBlock + "directories for images");

function buildArticlev2(argTile, argshorttext, arglable, argyear) {
  var randImageIndex = Math.floor(Math.random() * 2); //0 to 9
  var vTitleNoSpaces = argTile.replace(/\s/g, "");
  var title_underscored = argTile.replace(/\s/g, "_");

  var articletext = "";

  var vArticleID = arglable; //    '+vArticleID+'
  var vImageID = "img" + arglable; //    '+vImageID+'

  var v_imgpath =
    title_underscored +
    "/" +
    title_underscored +
    "_dalle_" +
    randImageIndex +
    "_"; //    '+v_imgpath+'   --->  Programming_In_Basic/Programming_In_Basic_dalle_0_

  var vPagePath = "SelectedPages/ProjectPages/Page_" + vTitleNoSpaces; //    '+vPagePath+'

  var arra = [
    '<article id="' + vArticleID + '"> <span class="image">',
    '<img id="' + vImageID + '" ',
    'src="/images/imagesFromDalle/' + v_imgpath + '.png" ',
    'alt=""/></span><header class="major"><h3>',
    '<a href="/' + vPagePath + '.html" class="link">',
    argTile + "</a></h3><p>",
    argshorttext + "</p><br /><h4>",
    argyear + "</h4></header></article>",
  ];

  for (var s = 0; s < arra.length; s++) {
    articletext += arra[s];
  }

  return articletext;
}

var imgs = document.getElementsByTagName("img");
for (var i = 0, l = imgs.length; i < l; i++) {
  imgs[i].src =
    " cat-wallpaper-34-713472.jpg";
}