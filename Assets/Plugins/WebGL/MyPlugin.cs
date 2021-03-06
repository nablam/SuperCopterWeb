using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class MyPlugin : MonoBehaviour
{

#if UNITY_WEBGL && !UNITY_EDITOR
 
#endif


#if UNITY_WEBGL && !UNITY_EDITOR
 
    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void HelloString(string str);

    [DllImport("__Internal")]
    private static extern void PrintFloatArray(float[] array, int size);

    [DllImport("__Internal")]
    private static extern int AddNumbers(int x, int y);

    [DllImport("__Internal")]
    private static extern string StringReturnValueFunction();

    //[DllImport("__Internal")]
    //private static extern void BindWebGLTexture(int texture);
	
	 [DllImport("__Internal")]
     private static extern bool IsMobile();
#endif

    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        // Hello();

        //HelloString("This is a string.");

        //float[] myArray = new float[10];
        //PrintFloatArray(myArray, myArray.Length);

        //int result = AddNumbers(5, 7);
        //Debug.Log(result);

        //Debug.Log(StringReturnValueFunction());

      
#endif

    }
	     public bool checkMobile()
     {
         #if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
         #endif
         return false;
     }
}
