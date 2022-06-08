using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicBallanceCTRL : MonoBehaviour
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
    Vector3 origina_backWaveRelPos;
    Vector3 origina_backWaveWORLSPos;
    Vector3 Hard_backWave_WORLDPs;
    Vector3 Hard_backWave_relPs;

    public GameObject frontwave;
    Vector3 origina_frontwaveRelPos;
    Vector3 origina_frontwaveWORLSPos;
    Vector3 Hard_frontwave_WORLDPs;
    Vector3 Hard_frontwave_relPs;

    public float MaxIntensity= 0.7f;
  
    private float _targettime;
    private float ChangeDirectionTimer = 3.0f;
    private float RandomeIndensity = 0f;
    private float LowestOutOfScreen = -100f;


    float direction = 0;
    bool onoff;

    bool SurferIsSurfing;
    void RunTimer()
    {
        _targettime -= Time.deltaTime;

        if (_targettime <= 0.0f)
        {
            
            onoff = !onoff;
            _targettime = ChangeDirectionTimer;
            RandomeIndensity = Random.Range(0f, MaxIntensity);

            if (onoff)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }
                 RandomeIndensity = Random.Range(0f, MaxIntensity)* direction;
           
        }

    }

    void Awake()
    {
        RandomeIndensity = Random.Range(0f, MaxIntensity);
        SurferIsSurfing = true;
        original_SurferRelPos = new Vector3( surfer.transform.localPosition.x, surfer.transform.localPosition.y , surfer.transform.localPosition.z);
        Debug.Log("original_SurferRelPos " + original_SurferRelPos);
        original_SurferWORLDPos = new Vector3(surfer.transform.position.x, surfer.transform.position.y, surfer.transform.position.z);
        Debug.Log("original_SurferWORLDPos " + original_SurferWORLDPos);
        origina_BoardRelPos = new Vector3(board.transform.localPosition.x, board.transform.localPosition.y, board.transform.localPosition.z);
        Debug.Log("origina_BoardRelPos " + origina_BoardRelPos);
        origina_BoardWORLSPos = new Vector3(board.transform.position.x, board.transform.position.y, board.transform.position.z);
        Debug.Log("origina_BoardWORLSPos " + origina_BoardWORLSPos);

        original_Pivot_relPs = new Vector3(pivot.transform.localPosition.x, pivot.transform.localPosition.y, pivot.transform.localPosition.z);
        Debug.Log("original_Pivot_relPs " + original_Pivot_relPs);
        origin_Pivot_WORLDPs = new Vector3(pivot.transform.position.x, pivot.transform.position.y, pivot.transform.position.z);
        Debug.Log("origin_Pivot_WORLDPs " + origin_Pivot_WORLDPs);
    }

    void RunPivotControleWithRandomWinds()
    {
        RunTimer();

        float h = Input.GetAxisRaw("Horizontal");

        pivot.transform.Rotate(0, 0, RandomeIndensity - h, Space.Self);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SurferIsSurfing = false;
            surfer.transform.parent = null;
           
        }
        if (SurferIsSurfing == false) {
            surfer.transform.Rotate(0, 0, 3f, Space.World);
            surfer.transform.Translate(0, -2f, 0, Space.World);
            if (surfer.transform.position.y < LowestOutOfScreen) {
                Debug.Log("restart");
            }
        }
  
    }
}
