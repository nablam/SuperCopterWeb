using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_WEBGL && !UNITY_EDITOR

 
using System.Runtime.InteropServices;
#endif
public class MasterOBJ : MonoBehaviour
{
	public static MasterOBJ Instance = null;



#if UNITY_WEBGL && !UNITY_EDITOR
	
	 [DllImport("__Internal")]
	 private static extern bool IsMobile();
#endif

	public static bool MasterCheckMobile()
	{
#if !UNITY_EDITOR && UNITY_WEBGL
			 return IsMobile();
#endif
		return false;
	}

	private void Awake()
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(this.gameObject);
			Instance = this;
		}
		else
			Destroy(gameObject);
	}

	public delegate void EVENT_WriteToTXT(string argstr);
	public static event EVENT_WriteToTXT On_EVENT_WriteToTXT;
	public static void CALL_EVENT_WriteToTXT(string argstr)
	{
		if (On_EVENT_WriteToTXT != null) On_EVENT_WriteToTXT(argstr);
	}

	public void RunUpdateTestText(string astringFromJs) {
		CALL_EVENT_WriteToTXT(astringFromJs);
	}


	public delegate void EVENT_BtnPressedSTR(string argstr);
	public static event EVENT_BtnPressedSTR On_EVENT_BtnPressedSTR;
	public static void CALL_EVENT_BtnPressedSTR(string argstr)
	{
		if (On_EVENT_BtnPressedSTR != null) On_EVENT_BtnPressedSTR(argstr);
	}
}
