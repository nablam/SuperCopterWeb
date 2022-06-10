using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance = null;
    List<string> AvailableGameSceneNames;
    int selectedGameIndex = 1;
    private void Awake()
    {
        if (Instance == null)
        {
            if (MasterOBJ.Instance == null) { Debug.Log("NO staticMasterOBJ found"); } else {

                if (MasterOBJ.MasterCheckMobile())
                {
                    Debug.Log("is cellphone");
                    //Run_UpdateTestthink("MasterMOBILe");
                }
                else
                {
                    Debug.Log("isdesktop");
                    //Run_UpdateTestthink("MasterDESKTOP"); 
                }
            }

         


            AvailableGameSceneNames = new List<string>();
            AvailableGameSceneNames.Add("StartScene");
            AvailableGameSceneNames.Add("HelicopterGameScene");//gameindex=1
            AvailableGameSceneNames.Add("SurfGameScene");//gameindex=2
            //DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        MasterOBJ.On_EVENT_BtnPressedSTR += SceneNaveButton;
    }
    private void OnDisable()
    {
        MasterOBJ.On_EVENT_BtnPressedSTR -= SceneNaveButton;
    }

    void SceneNaveButton(string argstr) {

        switch (argstr)
        {

            case "nav_startreset":
                //Debug.Log(argstr + " 0");
                SelectStartResetSelectedGame();
                break;

            case "nav_home":
                //Debug.Log(argstr + " 1");
                SelectHome();
                break;
            case "nav_back":
                //Debug.Log(argstr + " 2");
                SelectPreviousGame();
                break;
            case "nav_next":
                //Debug.Log(argstr + " 3");
                SelectNextGame();
                break;
            
            default:
                Debug.Log("defauklt " + argstr);
                break;
        }

    }
    void SelectNextGame() {
       // Debug.Log("clicked next ");
        selectedGameIndex++;
        if (selectedGameIndex >= AvailableGameSceneNames.Count) {
            selectedGameIndex = 1;
        }
        DisplaySelectedGameName();
    }
      void SelectPreviousGame() {
        //Debug.Log("clicked prev ");
        
        selectedGameIndex--;
        if (selectedGameIndex < 1)
        {
            selectedGameIndex = AvailableGameSceneNames.Count-1;//lastindex
        }
        DisplaySelectedGameName();
    }

      void SelectStartResetSelectedGame() {
        //SceneManager.LoadScene(AvailableGameSceneNames[selectedGameIndex]);
        Debug.Log("going to " + AvailableGameSceneNames[selectedGameIndex]);
        SceneManager.LoadScene(AvailableGameSceneNames[selectedGameIndex]);
    }
      void SelectHome() {
        Debug.Log("clicked Home ");
        SceneManager.LoadScene(AvailableGameSceneNames[0]); //startscene is index0
    }

    public void DisplaySelectedGameName() {
        StartCanvasCTRL.Instance.Display_centerMid(AvailableGameSceneNames[selectedGameIndex]);

    }




}
