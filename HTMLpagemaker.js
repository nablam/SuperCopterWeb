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

const imageDirPath = resolve(__dirname, "BulkPages");

for (var b = 0; b < totalJsonBlock; b++) {
  var projecttitle = theJSON.TextContent.textContent[b].title.replace(
    /\s/g,
    ""
  );
  var PagenameOUTpath = imageDirPath + "\\Page_" + projecttitle + ".html";

  var builtHTML = BuildHTML(
    theJSON.TextContent.textContent[b].title,
    theJSON.TextContent.textContent[b].maintext_Long,
    theJSON.TextContent.textContent[b].page_lable,
    // theJSON.TextContent.textContent[b].date
    ""
  );
  console.log("BEWARE UNCOMMENT NEXT");

  // fs1.writeFileSync(PagenameOUTpath, builtHTML);
}
console.log("done makin pages");

function BuildHTML(argTitletext, argText, argLable, argyear) {
  var titleNOspaces = argTitletext.replace(/\s/g, "");
  var title_underscored = argTitletext.replace(/\s/g, "_");
  var folder_name_slash_image_name_n_ =
    title_underscored + "/" + title_underscored + "_0_.png";
  var part0 =
    '<!DOCTYPE html> <html> <head> <title>Nabil Personal Projects Timeline</title> <meta charset="utf-8" /> <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no"/> <link rel="stylesheet" href="/assets/css/main.css" /> <noscript> <link rel="stylesheet" href="/assets/css/noscript.css" /> </noscript> </head> <body class="is-preloadr"> <div id="wrapper"> <header id="header" class="alt"> ';
  var part1 = '<a href="/indexV2.html';
  var part2 =
    '" class="logo"><strong>Nabdev</strong> <span>archives</span></a> <nav><a href="#menu">Menu</a></nav> </header> <nav id="menu"> <ul class="links"> <li><a href="'; //
  var partA = "/SelectedPages/ProjectsTimeline01_page.html#" + argLable; //  was /indexV2.html
  var partB =
    '">Home</a></li> </ul> </nav> <div id="main" class="alt"> <section id="one"> <div class="inner"> <header class="major"> <h1>';
  var part3 = argTitletext; //"TITLE";
  var part4 =
    '</h1> </header> <span class="image main"><img src= "/images/imagesFromDalle/';
  var part5 = folder_name_slash_image_name_n_;
  var part6 = '" alt="" /></span> <p> ';
  var part7 = argText + "</p> <br><h4>" + argyear + "</h4>";
  var part8 =
    '</div> </section> </div> <footer id="footer"> <div class="inner"> <ul class="icons"> <li> <a href="https:/';
  var part9 =
    '/www.youtube.com/user/usergroupX" class="icon brands alt fa-youtube"><span class="label">Youtube</span></a> </li> <li> <a href="https:/';
  var part10 =
    '/www.linkedin.com/in/nablam/" class="icon brands alt fa-linkedin-in"><span class="label">LinkedIn</span></a> </li> <li> <a href="https:/';
  var part11 =
    '/github.com/nablam" class="icon brands alt fa-github"><span class="label">GitHub</span></a> </li> </ul> <ul class="copyright"> <li>&copy; NabDev</li>  </ul> </div> </footer> </div> <script src="/assets/js/jquery.min.js"></script> <script src="/assets/js/jquery.scrolly.min.js"></script> <script src="/assets/js/jquery.scrollex.min.js"></script> <script src="/assets/js/browser.min.js"></script> <script src="/assets/js/breakpoints.min.js"></script> <script src="/assets/js/util.js"></script> <script src="/assets/js/main.js"></script> <script src="/assets/js/rawtextLoader.js"></script> <script type="text/javascript" src="/assets/js/CryptoJSgoogz.js"></script> <script type="text/javascript" src="/assets/js/Obfuscation.js"></script> </body> </html>';
  var htmltext =
    part0 +
    part1 +
    part2 +
    partA +
    partB +
    part3 +
    part4 +
    part5 +
    part6 +
    part7 +
    part8 +
    part9 +
    part10 +
    part11;
  return htmltext;
}
