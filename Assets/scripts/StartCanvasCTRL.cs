using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCanvasCTRL : MonoBehaviour
{
    public float originalTargetTime = 1.05f;
    private float _targettime;
    public TMP_Text m_text;
    public TMP_Text m_text_fromjs;
    public TMP_Text DotNetThink;
    public TMP_Text ChromeThink;
    // Start is called before the first frame update
    void Start()
    {
        _targettime = originalTargetTime;
    }

    public void On_ButtonClicked() {
        Debug.Log("buttclik");
        m_text.text = "unity button clicked";
        TimerClicked = true;
         
    }

    void timerEnded()
    {
        onoff = !onoff;
        _targettime= originalTargetTime ;
    }

    int x;
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
            m_text.text = ".";
            _targettime = originalTargetTime;
        }
       
    }

    public void Update_dotnet_thiks(string argstr) {
        DotNetThink.text = argstr;
    }
    public void Update_Chrome_thiks(string argstr)
    {
        ChromeThink.text = argstr;
    }
    public void Update_test_thiks(string argstr)
    {
        m_text.text = argstr;
    }
    void Update()
    {
        if (TimerClicked && TimerIsRunning == false) {
            RunTimer();
        }

    }
}
