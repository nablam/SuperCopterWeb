using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SurfGameManager : MonoBehaviour
{
      BKG_builderMoverController GOmanager;
    WavesMover _wavesmover;
    SurferController _surferController;
    bool reset;

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

    private void Awake()
    {
        _wavesmover = GetComponent<WavesMover>();
        GOmanager = GetComponent<BKG_builderMoverController>();
        _surferController = GetComponent<SurferController>();
    }
    void Start()
    {
         
        StartCanvasCTRL.Instance.Set_Mode(UI_MODE.SurfMode);
        StartCanvasCTRL.Instance.Show_HomeButtone(true);
        _wavesmover.InitWaveMover(GOmanager.FrontWave_tileGO, GOmanager.BackWave_tileGO );
        _surferController.InitSurferController(GOmanager.Surfer_tileGO, GOmanager.Board_tileGO, GOmanager.PivotOBJ, GOmanager.PivotEnd, GOmanager.MainWaveRoot, GOmanager.BigWave_tileGO);
    }

    public void Ah_anim_waveIsInPlace() {
        Debug.Log("Ah_anim_waveIsInPlace");
        _surferController.StartGameWindAndcontrolls();
    }

    int clickcount=0;
    public void On_testClicked() { DoTestMesage("testing info"); }
    // Update is called once per frame
    
}
