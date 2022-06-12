using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWaveManager : MonoBehaviour
{
   public SurfGameManager _surfGame;
    public void HeardWaveRizeClipFinished() {
        _surfGame.Ah_anim_waveIsInPlace();
        Debug.Log("animEnd");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
