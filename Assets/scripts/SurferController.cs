using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurferController : MonoBehaviour
{
      GameObject surfer;
      GameObject board;
      GameObject pivot;
      GameObject PivotEnd;

    SurfGameManager _gm;
   
    Vector3 Hard_Pivot_relPs;
    Vector3 Hard_Pivot_WORLDPs;
    Vector3 original_Pivot_relPs;
    Vector3 origin_Pivot_WORLDPs;

   
    Vector3 original_SurferRelPos;
    Vector3 original_SurferWORLDPos;
    Vector3 Hard_Surfer_WORLDPs;
    Vector3 Hard_Surfer_relPs;
  
    Vector3 origina_BoardRelPos;
    Vector3 origina_BoardWORLSPos;
    Vector3 Hard_Board_WORLDPs;
    Vector3 Hard_Board_relPs;
    float speed = 1.2f;

    //bool _gm.GameisRunning;
    public float MaxIntensity = 0.7f;
    float _cachedMaxIntensity;
    public bool UseWind;
    private float _targettime;
    private float ChangeDirectionTimer = 3.0f;
    private float RandomeIndensity = 0f;
    private float LowestOutOfScreen = -100f;
    float direction = 0;
    bool onoff;

    bool SurferIsSurfing;
    Animator _wavanimator;
    private void OnEnable()
    {
        MasterOBJ.On_EVENT_BtnPressedSTR += SceneNaveButton;
    }
    private void OnDisable()
    {
        MasterOBJ.On_EVENT_BtnPressedSTR -= SceneNaveButton;
    }
    bool Rbutton_d = false;
    bool Rbutton_u = false;
    bool Lbutton_d = false;
    bool Lbutton_u = false;

    void SceneNaveButton(string argstr)
    {
        Debug.Log(argstr);

        switch (argstr)
        {
 
            case "brd":

                 Debug.Log("Rbutton_d is DOWN");
                Rbutton_d = true;
                Rbutton_u = false;
                break;
            case "bru":
                Debug.Log("Rbutton_d is UP");
                Rbutton_d = false;
                Rbutton_u = true;
                     
                break;

         

    
            case "bld":
                  Debug.Log("leftb_d is down");
                Lbutton_d = true;
                Lbutton_u = false;
                break;

            case "blu":
                Debug.Log("leftb_d is up");
                Lbutton_d = false;
                Lbutton_u = true;
                break;
            default:
                 
                break;
        }

    }
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
            if (!_gm.GameisRunning)
            {
                _cachedMaxIntensity = 0f;
            }
            else {
                _cachedMaxIntensity = MaxIntensity;
            }
            RandomeIndensity = Random.Range(0f, _cachedMaxIntensity) * direction;

        }

    }


    public void InitSurferController(GameObject argSurfer, GameObject argBoard, GameObject argPivot, GameObject argPivotend, GameObject argBaseObj, GameObject argWaveObj)
    {
        _cachedMaxIntensity = MaxIntensity;
        surfer = argSurfer;
        board = argBoard;
        pivot = argPivot;
        PivotEnd = argPivotend;
        _wavanimator = argBaseObj.GetComponent<Animator>();

        RandomeIndensity = Random.Range(0f, MaxIntensity);
        SurferIsSurfing = true;
        original_SurferRelPos = new Vector3(surfer.transform.localPosition.x, surfer.transform.localPosition.y, surfer.transform.localPosition.z);
        //Debug.Log("original_SurferRelPos " + original_SurferRelPos);
        original_SurferWORLDPos = new Vector3(surfer.transform.position.x, surfer.transform.position.y, surfer.transform.position.z);
      //  Debug.Log("original_SurferWORLDPos " + original_SurferWORLDPos);
        origina_BoardRelPos = new Vector3(board.transform.localPosition.x, board.transform.localPosition.y, board.transform.localPosition.z);
      //  Debug.Log("origina_BoardRelPos " + origina_BoardRelPos);
        origina_BoardWORLSPos = new Vector3(board.transform.position.x, board.transform.position.y, board.transform.position.z);
      //  Debug.Log("origina_BoardWORLSPos " + origina_BoardWORLSPos);

        original_Pivot_relPs = new Vector3(pivot.transform.localPosition.x, pivot.transform.localPosition.y, pivot.transform.localPosition.z);
      //  Debug.Log("original_Pivot_relPs " + original_Pivot_relPs);
        origin_Pivot_WORLDPs = new Vector3(pivot.transform.position.x, pivot.transform.position.y, pivot.transform.position.z);
      //  Debug.Log("origin_Pivot_WORLDPs " + origin_Pivot_WORLDPs);


        //PivotOBJ.transform.position = new Vector3(-43, -77,1f);
        surfer.transform.parent = PivotEnd.transform;
        board.transform.parent = PivotEnd.transform;
        _gm.GameisRunning = false;
    }
    void Awake()
    {
        _gm = GetComponent<SurfGameManager>();
    }

    float _H_ = 0.0f;
    float _K_ = 0.0f;
    void RunPivotControleWithRandomWinds()
    {
        RunTimer();

        _K_ = Input.GetAxisRaw("Horizontal");

        if (Rbutton_d) _H_ = 1f;
        else
               if (Lbutton_d) _H_ = -1f;
        else
            _H_ = 0f;


        if (_K_ > 0.0f || _K_ < 0.0f)
            _H_ = _K_;

        if (!_gm.GameisRunning)
        {

            _H_ = 0f;
        }

        pivot.transform.Rotate(0, 0, RandomeIndensity - _H_, Space.Self);

    }
    IEnumerator WaitAndRestart( )
    {
        yield return new WaitForSeconds(2f);
        ResetPlayer();
    }

    IEnumerator WaitAndReset()
    {
        yield return new WaitForSeconds(2f);
        _wavanimator.SetBool("resetbool", false);
    }
    void ResetPlayer() {

        _wavanimator.SetBool("resetbool", true);
        SurferIsSurfing = true;
        surfer.transform.eulerAngles = new Vector3(0, 0, 0);
        board.transform.eulerAngles = new Vector3(0, 0, 0);

        pivot.transform.eulerAngles=  new Vector3(0, 0, 0);


        surfer.transform.position = new Vector3(PivotEnd.transform.position.x, PivotEnd.transform.position.y +30 , 0);
        board.transform.position = new Vector3(PivotEnd.transform.position.x, PivotEnd.transform.position.y + 30, 0);

        surfer.transform.parent = PivotEnd.transform;
        board.transform.parent = PivotEnd.transform;
        StartCoroutine("WaitAndReset");

    }

    void Updatefingers()
    {
        var fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {

                fingerCount++;
                Debug.Log(touch.position);
            }
        }
        if (fingerCount > 0)
        {
            Debug.Log("User has " + fingerCount + " finger(s) touching the screen");
           
        }


    }

    public void StartGameWindAndcontrolls() {

        _gm.GameisRunning = true;
    }
    public float maxAngle=50;
    public void Run_Update()
    {



        




        RunPivotControleWithRandomWinds();

        if (!(pivot.transform.eulerAngles.z < maxAngle || pivot.transform.eulerAngles.z > 360- maxAngle)   )  
        {
            SurferIsSurfing = false;
            surfer.transform.parent = null;
            board.transform.parent = null;

        }
        if (SurferIsSurfing == false)
        {
            surfer.transform.Rotate(0, 0, 3f, Space.World);
            surfer.transform.Translate(0, -2f, 0, Space.World);

            board.transform.Rotate(0, 0, 3f, Space.World);
            board.transform.Translate(1, -2f, 0, Space.World);
            if (surfer.transform.position.y < LowestOutOfScreen)
            {
                _gm.GameisRunning = false;
                StartCoroutine("WaitAndRestart");
            }
        }

         

    }

  

  
}
