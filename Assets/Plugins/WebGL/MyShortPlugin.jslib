var MyShortPlugin = {
    Hello1: function()
    {
        window.alert("Hello, world!");
    },
    HelloString1: function(str)
    {
        window.alert(Pointer_stringify(str));
    },
    PrintFloatArray1: function(array, size)
    {
        for(var i=0;i<size;i++)
            console.log(HEAPF32[(array>>2)+size]);
    },
    AddNumbers1: function(x,y)
    {
        return x + y;
    },
    StringReturnValueFunction1: function()
    {
        var returnStr = "bla";
        var buffer = _malloc(returnStr.length + 1);
        writeStringToMemory(returnStr, buffer);
        return buffer;
    },
    DoWorkDebug1: function()
    {
         document.getElementById("debug0").innerHTML = "hello fromunity";
    },
	IsMobile1: function()
     {
         return UnityLoader.SystemInfo.mobile;
     }
};

mergeInto(LibraryManager.library, MyShortPlugin);