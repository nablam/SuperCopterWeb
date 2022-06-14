using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int _score = 0;
    private float _curTimeModed;
    private float resetTimerEvery ;
    public TMP_Text m_text_Score;
    public TMP_Text m_text_info;
    void Start()
    {
        m_text_Score.color = Color.white;
    }

    public void Init_scoreManager(float argTimeScore, bool argbonus) {
        m_text_info.text = "";
        if (argbonus) {
            m_text_Score.color = Color.green;
            m_text_info.text = "bonus";
        }
         resetTimerEvery = argTimeScore;
        _score = 0;
        _curTimeModed = resetTimerEvery;
        MasterOBJ.CALL_EVENT_PlayerScoreUpdateINT(_score);
        m_text_Score.text = _score.ToString();
       
    }
 
    bool onoff;

    
   public void RunTimer()
    {
        _curTimeModed -= Time.deltaTime;

        if (_curTimeModed <= 0.0f)
        {

            onoff = !onoff;
            _curTimeModed = resetTimerEvery;


            _score++;

            MasterOBJ.CALL_EVENT_PlayerScoreUpdateINT(_score);
            m_text_Score.text = _score.ToString();


        }

    }

    public void ResetTimerAndScore() {        
        _score = 0;
        _curTimeModed = resetTimerEvery;
        MasterOBJ.CALL_EVENT_PlayerScoreUpdateINT(_score);
    }
    // Update is called once per frame
    //void Update()
    //{
    //    RunTimer();
    //}
}
