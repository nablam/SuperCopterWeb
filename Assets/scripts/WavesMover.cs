using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesMover : MonoBehaviour
{
      //GameObject BackWaveRef;
      //GameObject FrontWaveRef;
      float frontwaveSpeed = 20f;
      float backwaveSpeed = 15f;
    float FullscreenScale = 162;
    List<GameObject> BackWaves;
    List<GameObject> FrontWaves;

    float frontwave_xscal =64f;
    float frontwave_limitx=-242f;
    float frontwaveOffset=163f;


    float backwave_xscal = 128;
    float backtwave_limitx=-324f;
    float backwaveOffset=326f;
    Vector3 frontwaveResetPos;
    Vector3 backwaveResetPos;

    public void InitWaveMover(GameObject argWaveFront, GameObject argWaveBack )
    {
        //FrontWaveRef = argWaveFront;
        //BackWaveRef = argWaveBack;
        FrontWaves = new List<GameObject>();
        BackWaves = new List<GameObject>();


     


        CreateWaveTIlesbetter(argWaveFront, FrontWaves, frontwave_xscal, -80f, frontwave_limitx,  frontwaveOffset,  true);
        CreateWaveTIlesbetter(argWaveBack, BackWaves, backwave_xscal, -74f, backtwave_limitx, backwaveOffset, false);
    
    }

  
    void CreateWaveTIlesbetter(GameObject argWaveTileSample, List<GameObject> argListref, float argScalex,float argYpos,   float argLeftLimitPos,   float argOffsets, bool argIsFrontwave)
    {
        float xoffset=0f;
        float CurXpositionInstanc = argLeftLimitPos;
        Vector3 scaleV3 = new Vector3(argScalex, 20f, 1);
        Vector3 posV3 = new Vector3(CurXpositionInstanc, argYpos, argWaveTileSample.transform.position.z);

        argWaveTileSample.transform.localScale = scaleV3;
        argWaveTileSample.transform.position = posV3;
        argListref.Add(argWaveTileSample);

        for (int fwi = 0; fwi < 3; fwi++)
        {
            GameObject tempwave1 = Instantiate(argWaveTileSample);


            xoffset = CurXpositionInstanc + ((fwi + 1) * argOffsets);
            posV3.x = xoffset;
            tempwave1.transform.localScale = scaleV3;
            tempwave1.transform.position = posV3;
            argListref.Add(tempwave1);
        }


        if (argIsFrontwave)
        {
          frontwaveResetPos = new Vector3(xoffset, argYpos, argWaveTileSample.transform.position.z);
        }
        else { 
          backwaveResetPos= new Vector3(xoffset, argYpos, argWaveTileSample.transform.position.z);
        }

        
    }


    void MoveAllWaves() {
        foreach (GameObject go in FrontWaves) { 
            go.transform.Translate(Vector3.left * Time.deltaTime* frontwaveSpeed, Space.World);
            if (go.transform.position.x < frontwave_limitx) {
                go.transform.position = frontwaveResetPos;
            }
        }

        foreach (GameObject go in BackWaves)
        {
            go.transform.Translate(Vector3.left * Time.deltaTime* backwaveSpeed, Space.World);
            if (go.transform.position.x < backtwave_limitx)
            {
                go.transform.position = backwaveResetPos;
            }
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveAllWaves();
    }
}
