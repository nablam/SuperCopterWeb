using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteAtlasScript : MonoBehaviour
{
    [SerializeField] SpriteAtlas myatlas;
    [SerializeField] string spritename;
    // Sprite toshow;
    SpriteRenderer sr;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public float targetTime = 0.05f;

    

    
 

    void timerEnded()
    {
        //do your stuff here.
        onoff = !onoff;
        targetTime =0.05f;
    }

    int x;
    bool onoff;
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
        //if (onoff) {
        //    GetComponent<Image>().sprite = myatlas.GetSprite(spritename+"1");
        //}
        //else
        //    GetComponent<Image>().sprite = myatlas.GetSprite(spritename+"2");


        if (onoff)
        {
            sr.sprite = myatlas.GetSprite(spritename + "1");
        }
        else
            sr.sprite = myatlas.GetSprite(spritename + "2");




        //= myatlas.GetSprite(spritename)
    }
}
