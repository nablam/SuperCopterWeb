var MyPlugin = {
    Hello: function()
    {
        window.alert("Hello, world!");
    },
    HelloString: function(str)
    {
        window.alert(UTF8ToString(str));
    },
    PrintFloatArray: function(array, size)
    {
        for(var i=0;i<size;i++)
            console.log(HEAPF32[(array>>2)+size]);
    },
    AddNumbers: function(x,y)
    {
        return x + y;
    },
    StringReturnValueFunction: function()
    {
        var returnStr = "bla";
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize); 
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
 
	IsMobile: function()
     {
         return Module.SystemInfo.mobile;
     }
};

mergeInto(LibraryManager.library, MyPlugin);