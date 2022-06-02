//uncomment to run, beware !
const { readdirSync, rename } = require("fs");
const { resolve } = require("path");

const fs1 = require("fs");

// Get path to image directory
const _path_imagesfromdalle = resolve(__dirname, "imagesFromDalle"); // e:\Nablam_Github_IO\TheJournalGitted_purejs\TheJournal\imagesFromDalle
// Get an array of the files inside the folder

const DALLEDIR = readdirSync(_path_imagesfromdalle);
const DalleDirTotalFiles = DALLEDIR.length; //62 folders

for (var f = 0; f < DalleDirTotalFiles; f++) {
  var _path_toSubDir = _path_imagesfromdalle + "\\" + DALLEDIR[f]; //e:\Nablam_Github_IO\TheJournalGitted_purejs\TheJournal\imagesFromDalle\Alien_Explorer_Android_Game
  let SUBDIR = readdirSync(_path_toSubDir);
  let subeDirTotalFiles = SUBDIR.length;
  for (var s = 0; s < subeDirTotalFiles; s++) {
    var _path_tiImage = _path_toSubDir + "\\" + SUBDIR[s];
    var _path_new_Image =
      _path_toSubDir + "\\" + DALLEDIR[f] + "_dalle_" + s + "_.png";
    fs1.renameSync(_path_tiImage, _path_new_Image);
    // console.log(_path_tiImage);
    // console.log(_path_new_Image);
  }
}

console.log(DalleDirTotalFiles);
