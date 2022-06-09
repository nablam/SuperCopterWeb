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

    public void SelectNextGame() {
        Debug.Log("clicked next ");
        selectedGameIndex++;
        if (selectedGameIndex >= AvailableGameSceneNames.Count) {
            selectedGameIndex = 1;
        }
    }
    public void SelectPreviousGame() {
        Debug.Log("clicked prev ");
        selectedGameIndex--;
        if (selectedGameIndex < 1)
        {
            selectedGameIndex = AvailableGameSceneNames.Count-1;//lastindex
        }
    }

    public void SelectStartResetSelectedGame() {
        //SceneManager.LoadScene(AvailableGameSceneNames[selectedGameIndex]);
        Debug.Log("going to " + AvailableGameSceneNames[selectedGameIndex]);
    }
    public void SelectHome() {
        Debug.Log("clicked Home ");
    }

    


}
