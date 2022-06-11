using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCanvasCTRL : MonoBehaviour
{
    public static StartCanvasCTRL Instance = null;

    public float originalTargetTime = 1.05f;
    private float _targettime;
    public TMP_Text m_text_topLeft;
    public TMP_Text m_text_topRight;
    public TMP_Text m_text_botLeft;
    public TMP_Text m_text_botRight;
    public TMP_Text m_text_centerMid;

    public List<GameObject> SurfButtons;
    public List<GameObject> HeliButons;
    public List<GameObject> NavButtons;
    MasterOBJ _masterobj;
    GameObject HomeButton;
    void grabChildren() {
        SurfButtons = new List<GameObject>();
        HeliButons = new List<GameObject>();
        NavButtons = new List<GameObject>();


        for (int c = 0; c < this.transform.childCount; c++) {
            GameObject objref = this.transform.GetChild(c).gameObject;
            string objname = objref.name;
            //Debug.Log(this.transform.GetChild(c).gameObject.name);
            if (objname.Contains("(heli)")) {
                HeliButons.Add(objref);
            }
            else 
            if (objname.Contains("(navi)"))
            {
               
                if (objname.Contains("Home"))
                {
                    HomeButton = objref;
                }
                else {
                    NavButtons.Add(objref);
                }
            }
            else
            if (objname.Contains("(surf)"))
            {
                SurfButtons.Add(objref);
            }
        }
         
    }

    void ShowHide_buttonsInList(bool argShow, List<GameObject> argList) {
        foreach (GameObject go in argList) {
            go.SetActive(argShow);
        }
    }


    public void On_generalClicked()
    {
        Debug.Log("buttclik");

        TimerClicked = true;
    }

    void timerEnded()
    {
        onoff = !onoff;
        _targettime= originalTargetTime ;
    }

   
    bool onoff;
    bool TimerClicked = false;
    bool TimerIsRunning = false;

    UI_MODE _curMode;
    void RunTimer()
    {
        _targettime -= Time.deltaTime;

        if (_targettime <= 0.0f)
        {
            TimerClicked = false;
            TimerIsRunning = false;
           
            _targettime = originalTargetTime;
        }
       
    }
    void UpdateTimer() {
        if (TimerClicked && TimerIsRunning == false)
        {
            RunTimer();
        }
    }


    public void Display_topLeft(string argstr)
    {
        m_text_topLeft.text = argstr;
    }
    public void Display_topRight(string argstr)
    {
        m_text_topRight.text = argstr;
    }

    public void Display_botLeft(string argstr)
    {
        m_text_botLeft.text = argstr;
    }
    public void Display_botRight(string argstr)
    {
        m_text_botRight.text = argstr;
    }

    public void Display_centerMid(string argstr)
    {
        m_text_centerMid.text = argstr;
    }


    void SelfeClearAllTextboxes() {
        Display_topLeft("");
        Display_topRight("");
        Display_botLeft("");
        Display_botRight("");
        Display_centerMid("");
    }

    public void On_Bt_press_str(string argstr) {
        switch (argstr)
        {

            case "nav_startreset":
                // Debug.Log(argstr + " 0");
                break;

            case "nav_home":
                // Debug.Log(argstr + " 1");

                SceneManager.LoadScene("StartScene");
                break;
            case "nav_back":
                // Debug.Log(argstr + " 2");
                break;
            case "nav_next":
                // Debug.Log(argstr + " 3");
                break;
            case "dpad_up":
                // Debug.Log(argstr + " 4 up");
                break;
            case "dpad_down":
                // Debug.Log(argstr + " 5 down");
                break;
            case "dpad_left":
                // Debug.Log(argstr + " 6 left");
                break;

            case "dpad_right":
                // Debug.Log(argstr + " 7 right");
                break;

            case "dpad_actionA":
                // Debug.Log(argstr + " 8 act A");
                break;
            case "dpad_actionB":
                // Debug.Log(argstr + " 9 act B");
                break;
            default:
                // Debug.Log("defauklt "+ argstr);
                break;
        }
      
        MasterOBJ.CALL_EVENT_BtnPressedSTR(argstr);
    }
    public void Set_Mode(UI_MODE argUimode) {

        if (argUimode == UI_MODE.Navigation) {
            ShowHide_buttonsInList(true, NavButtons);
            ShowHide_buttonsInList(false, HeliButons);
            ShowHide_buttonsInList(false, SurfButtons);
        }
        else
               if (argUimode == UI_MODE.HiliMode)
        {
            ShowHide_buttonsInList(false, NavButtons);
            ShowHide_buttonsInList(true, HeliButons);
            ShowHide_buttonsInList(false, SurfButtons);
        }
        else if (argUimode == UI_MODE.SurfMode)
        {
            ShowHide_buttonsInList(false, NavButtons);
            ShowHide_buttonsInList(false, HeliButons);
            ShowHide_buttonsInList(true, SurfButtons);
        }
         

            _curMode = argUimode;
    }
    public void Show_HomeButtone(bool argOnoff) {
       HomeButton.SetActive(argOnoff);
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
    void Start() {
        
    
        _targettime = originalTargetTime;
        SelfeClearAllTextboxes();
        grabChildren();

        _curMode = UI_MODE.Navigation;
        Set_Mode(_curMode);
        Show_HomeButtone(true);
    }

    public void On_down_debug() { }
    public void On_up_debug() { }
    public void On_enter_debug() { }
    public void On_exit_debug() { }


}
