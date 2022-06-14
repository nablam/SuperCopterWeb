using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SurfGameManager : MonoBehaviour
{
      BKG_builderMoverController GOmanager;
    WavesMover _wavesmover;
    SurferController _surferController;
    ScoreManager _scoremanager;
    bool reset;
    public bool GameisRunning;
    bool HasBonus = false;

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
        _scoremanager = GetComponent<ScoreManager>();
    }
    void Start()
    {
       


        StartCanvasCTRL.Instance.Set_Mode(UI_MODE.SurfMode);
        StartCanvasCTRL.Instance.Show_HomeButtone(true);

        _wavesmover.InitWaveMover(GOmanager.FrontWave_tileGO, GOmanager.BackWave_tileGO );
        _surferController.InitSurferController(GOmanager.Surfer_tileGO, GOmanager.Board_tileGO, GOmanager.PivotOBJ, GOmanager.PivotEnd, GOmanager.MainWaveRoot, GOmanager.BigWave_tileGO);
        if (MasterOBJ.GetSecret() == "pigameconsole_youvegotmail_charactercreation_")
        {
            HasBonus = true;
           
        }
        else {
            HasBonus = false;
        }

        if(HasBonus)
        _scoremanager.Init_scoreManager(0.25f, true);
        else
            _scoremanager.Init_scoreManager(1.0f,false);
    }

    private void Update()
    {
        if (GameisRunning)
        {
            _scoremanager.RunTimer();
            _surferController.Run_Update();
        }
        else {
            _scoremanager.ResetTimerAndScore();
        }
    }

    public void Ah_anim_waveIsInPlace() {
        Debug.Log("Ah_anim_waveIsInPlace");
        _scoremanager.ResetTimerAndScore();
        _surferController.StartGameWindAndcontrolls();
    }

    int clickcount=0;
    public void On_testClicked() { DoTestMesage("testing info"); }
    // Update is called once per frame
    
}
