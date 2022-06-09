using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SurfGameManager : MonoBehaviour
{
    public BKG_builderMoverController GOmanager;
    TMP_Text m_text_fromjs;

    public void DoTestMesage(string argstr) {
        clickcount++;
        GOmanager.GEtAllTIleGOS()[13].GetComponent<TMP_Text>().text = argstr+"_"+clickcount; //infobox
    }

    private void OnEnable()
    {
        MasterOBJ.On_EVENT_WriteToTXT += DoTestMesage;
         
    }

    private void OnDisable()
    {
        MasterOBJ.On_EVENT_WriteToTXT -= DoTestMesage;

    }
    void Start()
    {
      //  DoTestMesage("helloteststts");
    }

    int clickcount=0;
    public void On_testClicked() { DoTestMesage("testing info"); }
    // Update is called once per frame
    
}
