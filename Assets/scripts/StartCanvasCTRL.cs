using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCanvasCTRL : MonoBehaviour
{
    public float originalTargetTime = 1.05f;
    private float _targettime;
    public TMP_Text m_text;
  
    // Start is called before the first frame update
    void Start()
    {
        _targettime = originalTargetTime;
    }

    public void On_ButtonClicked() {
        Debug.Log("buttclik");
        m_text.text = "was ckiked";
    }

    void timerEnded()
    {
       
        onoff = !onoff;
        _targettime= originalTargetTime ;
    }

    int x;
    bool onoff;
    void Update()
    {
        _targettime -= Time.deltaTime;

        if (_targettime <= 0.0f)
        {
            timerEnded();
        }


        if (onoff)
        {

        }
        else

        {
            m_text.text = "_";
        }



        //= myatlas.GetSprite(spritename)
    }
}
