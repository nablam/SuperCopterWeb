using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfGameManager : MonoBehaviour
{
    public GameObject pivot;
    Vector3 Hard_Pivot_relPs;
    Vector3 Hard_Pivot_WORLDPs;
    Vector3 original_Pivot_relPs;
    Vector3 origin_Pivot_WORLDPs;

    public GameObject surfer;
    Vector3 original_SurferRelPos;
    Vector3 original_SurferWORLDPos;
    Vector3 Hard_Surfer_WORLDPs;
    Vector3 Hard_Surfer_relPs;

    public GameObject board;
    Vector3 origina_BoardRelPos;
    Vector3 origina_BoardWORLSPos;
    Vector3 Hard_Board_WORLDPs;
    Vector3 Hard_Board_relPs;


    public GameObject BigWave;
    Vector3 origina_BigWaveRelPos;
    Vector3 origina_BigWaveWORLSPos;
    Vector3 Hard_BigWave_WORLDPs;
    Vector3 Hard_BigWave_relPs;

    public GameObject bigFoam;
    Vector3 origina_bigFoamRelPos;
    Vector3 origina_bigFoamWORLSPos;
    Vector3 Hard_bigFoam_WORLDPs;
    Vector3 Hard_bigFoam_relPs;


    public GameObject smallFoam;
    Vector3 origina_smallFoamRelPos;
    Vector3 origina_smallFoamWORLSPos;
    Vector3 Hard_smallFoam_WORLDPs;
    Vector3 Hard_smallFoam_relPs;

    public GameObject backWave;
    Vector3 Hard_backWaveScale = new Vector3(50, 18, 1);
    Vector3 origina_backWaveRelPos;
    Vector3 origina_backWaveWORLSPos;
    Vector3 Hard_backWave_WORLDPs;
    Vector3 Hard_backWave_relPs;

    public GameObject frontwave;
    Vector3 origina_frontwaveRelPos;
    Vector3 origina_frontwaveWORLSPos;
    Vector3 Hard_frontwave_WORLDPs;
    Vector3 Hard_frontwave_relPs;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
