using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCanvasCTRL : MonoBehaviour
{
    public float originalTargetTime = 1.05f;
    private float _targettime;
    public TMP_Text m_text_topLeft;
    public TMP_Text m_text_topRight;
    public TMP_Text m_text_botLeft;
    public TMP_Text m_text_botRight;
    public TMP_Text m_text_centerMid;
    // Start is called before the first frame update
   
    //public void On_generalClicked() {
    //    Debug.Log("buttclik");
        
    //    TimerClicked = true;
    //}

    void timerEnded()
    {
        onoff = !onoff;
        _targettime= originalTargetTime ;
    }

   
    bool onoff;
    bool TimerClicked = false;
    bool TimerIsRunning = false;
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


    void Start() {
        _targettime = originalTargetTime;
        SelfeClearAllTextboxes(); 
    }
    //void Update()
    //{
    //    //UpdateTimer();

    //}
}
