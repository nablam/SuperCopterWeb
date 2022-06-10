using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKG_builderMoverController : MonoBehaviour
{
    public GameObject Sky_tileGO;
    

    public GameObject Surfer_tileGO;

    public GameObject Board_tileGO;
 
    public GameObject BigWave_tileGO;

    public GameObject BigFoam_tileGO;
 
    public GameObject SmallFoam_tileGO;
 
    public GameObject BackWave_tileGO;
   
    public GameObject FrontWave_tileGO;

    public GameObject Sun_tileGO;

    public GameObject Cloud1_tileGO;

    public GameObject Cloude2_tileGO;

    public GameObject Seagull1_tileGO;

    public GameObject Seagull2_tileGO;

    public GameObject ScoreBox_tileGO;

    public GameObject InfoBox_tileGO;

    public GameObject IamageBox_tileGO;

    List<GameObject> AllTileGOS ;
    public List<GameObject> GEtAllTIleGOS() { return this.AllTileGOS; }
    public List<Vector3> AllTileWorldPos;
    public List<Vector3> AllTileRelPos;
    public List<Vector3> AllTileScacle;

    public GameObject PivotOBJ;
    public GameObject PivotEnd;
    //*********************************************************

    Vector3 Sky_tileGO_worldPos = new Vector3(0f, 0f, 14f);
    Vector3 Sky_tileGO_relPos = new Vector3(0f, 0f, 14f);
    Vector3 Sky_tileGO_Scale = new Vector3(126f, 80f, 1f);

    Vector3 Surfer_tileGO_worldPos = new Vector3(-44.5f, 20.1f, 1f);
    Vector3 Surfer_tileGO_relPos = new Vector3(-44.5f, 20.1f, 1f);
    Vector3 Surfer_tileGO_Scale = new Vector3(20f, 20f, 1f);

    Vector3 Board_tileGO_worldPos = new Vector3(-44.5f, 15.1f, 1f);
    Vector3 Board_tileGO_relPos = new Vector3(-44.5f, 15.1f, 1f);
    Vector3 Board_tileGO_Scale = new Vector3(20f, 20f, 1f);

    Vector3 BigWave_tileGO_worldPos = new Vector3(-51f, -23f, 6.7f);
    Vector3 BigWave_tileGO_relPos = new Vector3(-51f, -23f, 6.7f);
    Vector3 BigWave_tileGO_Scale = new Vector3(78.645f, 41.565f, 50f);

    Vector3 BigFoam_tileGO_worldPos = new Vector3(-109.5f, -84.4f, 2.6f);
    Vector3 BigFoam_tileGO_relPos = new Vector3(-109.5f, -84.4f, 2.6f);
    Vector3 BigFoam_tileGO_Scale = new Vector3(130.85f, 100f, 100f);

    Vector3 SmallFoam_tileGO_worldPos = new Vector3(-22f, -1f, 0.5f);
    Vector3 SmallFoam_tileGO_relPos = new Vector3(-22f, -1f, 0.5f);
    Vector3 SmallFoam_tileGO_Scale = new Vector3(45.668f, 21.406f, 0f);

    Vector3 BackWave_tileGO_worldPos = new Vector3(0f, -70f, 8f);
    Vector3 BackWave_tileGO_relPos = new Vector3(0f, -70f, 8f);
    Vector3 BackWave_tileGO_Scale = new Vector3(50f, 18f, 1f);

    Vector3 FrontWave_tileGO_worldPos = new Vector3(0f, -80f, 1f);
    Vector3 FrontWave_tileGO_relPos = new Vector3(0f, -80f, 1f);
    Vector3 FrontWave_tileGO_Scale = new Vector3(126f, 20f, 1f);

    Vector3 Sun_tileGO_worldPos = new Vector3(-105f, 63f, 1f);
    Vector3 Sun_tileGO_relPos = new Vector3(-105f, 63f, 1f);
    Vector3 Sun_tileGO_Scale = new Vector3(20f, 20f, 1f);

    Vector3 Cloud1_tileGO_worldPos = new Vector3(106.1f, 59.6f, 0f);
    Vector3 Cloud1_tileGO_relPos = new Vector3(106.1f, 59.6f, 0f);
    Vector3 Cloud1_tileGO_Scale = new Vector3(20f, 15f, 1f);

    Vector3 Cloude2_tileGO_worldPos = new Vector3(49.9f, 70.1f, 0f);
    Vector3 Cloude2_tileGO_relPos = new Vector3(49.9f, 70.1f, 0f);
    Vector3 Cloude2_tileGO_Scale = new Vector3(20f, 20f, 1f);

    Vector3 Seagull1_tileGO_worldPos = new Vector3(100.6f, 28.2f, 0f);
    Vector3 Seagull1_tileGO_relPos = new Vector3(100.6f, 28.2f, 0f);
    Vector3 Seagull1_tileGO_Scale = new Vector3(10f, 10f, 1f);

    Vector3 Seagull2_tileGO_worldPos = new Vector3(-35.1f, 63.3f, 0f);
    Vector3 Seagull2_tileGO_relPos = new Vector3(-35.1f, 63.3f, 0f);
    Vector3 Seagull2_tileGO_Scale = new Vector3(10f, 10f, 1f);

    Vector3 ScoreBox_tileGO_worldPos = new Vector3(501.7f, 486.8f, 0f);
    Vector3 ScoreBox_tileGO_relPos = new Vector3(21.7f, 186.8f, 0f);
    Vector3 ScoreBox_tileGO_Scale = new Vector3(1f, 1f, 1f);

    Vector3 InfoBox_tileGO_worldPos = new Vector3(500.3f, 417.4f, 0f);
    Vector3 InfoBox_tileGO_relPos = new Vector3(20.3f, 117.4f, 0f);
    Vector3 InfoBox_tileGO_Scale = new Vector3(1f, 1f, 1f);

    Vector3 IamageBox_tileGO_worldPos = new Vector3(480f, 82f, 0f);
    Vector3 IamageBox_tileGO_relPos = new Vector3(0f, -218f, 0f);
    Vector3 IamageBox_tileGO_Scale = new Vector3(1f, 1f, 1f);



    //*********************************************************
    void BuildLists()
    {
        AllTileGOS = new List<GameObject>();


        AllTileGOS.Add(Sky_tileGO);

        AllTileGOS.Add(Surfer_tileGO);

        AllTileGOS.Add(Board_tileGO);

        AllTileGOS.Add(BigWave_tileGO);

        AllTileGOS.Add(BigFoam_tileGO);

        AllTileGOS.Add(SmallFoam_tileGO);

        AllTileGOS.Add(BackWave_tileGO);

        AllTileGOS.Add(FrontWave_tileGO);

        AllTileGOS.Add(Sun_tileGO);

        AllTileGOS.Add(Cloud1_tileGO);

        AllTileGOS.Add(Cloude2_tileGO);

        AllTileGOS.Add(Seagull1_tileGO);

        AllTileGOS.Add(Seagull2_tileGO);

        AllTileGOS.Add(ScoreBox_tileGO);

        AllTileGOS.Add(InfoBox_tileGO);

        AllTileGOS.Add(IamageBox_tileGO);

        AllTileWorldPos = new List<Vector3>();
        AllTileRelPos = new List<Vector3>();
        AllTileScacle = new List<Vector3>();


        AllTileWorldPos.Add(Sky_tileGO_worldPos);
        AllTileRelPos.Add(Sky_tileGO_relPos);
        AllTileScacle.Add(Sky_tileGO_Scale);

        AllTileWorldPos.Add(Surfer_tileGO_worldPos);
        AllTileRelPos.Add(Surfer_tileGO_relPos);
        AllTileScacle.Add(Surfer_tileGO_Scale);

        AllTileWorldPos.Add(Board_tileGO_worldPos);
        AllTileRelPos.Add(Board_tileGO_relPos);
        AllTileScacle.Add(Board_tileGO_Scale);

        AllTileWorldPos.Add(BigWave_tileGO_worldPos);
        AllTileRelPos.Add(BigWave_tileGO_relPos);
        AllTileScacle.Add(BigWave_tileGO_Scale);

        AllTileWorldPos.Add(BigFoam_tileGO_worldPos);
        AllTileRelPos.Add(BigFoam_tileGO_relPos);
        AllTileScacle.Add(BigFoam_tileGO_Scale);

        AllTileWorldPos.Add(SmallFoam_tileGO_worldPos);
        AllTileRelPos.Add(SmallFoam_tileGO_relPos);
        AllTileScacle.Add(SmallFoam_tileGO_Scale);

        AllTileWorldPos.Add(BackWave_tileGO_worldPos);
        AllTileRelPos.Add(BackWave_tileGO_relPos);
        AllTileScacle.Add(BackWave_tileGO_Scale);

        AllTileWorldPos.Add(FrontWave_tileGO_worldPos);
        AllTileRelPos.Add(FrontWave_tileGO_relPos);
        AllTileScacle.Add(FrontWave_tileGO_Scale);

        AllTileWorldPos.Add(Sun_tileGO_worldPos);
        AllTileRelPos.Add(Sun_tileGO_relPos);
        AllTileScacle.Add(Sun_tileGO_Scale);

        AllTileWorldPos.Add(Cloud1_tileGO_worldPos);
        AllTileRelPos.Add(Cloud1_tileGO_relPos);
        AllTileScacle.Add(Cloud1_tileGO_Scale);

        AllTileWorldPos.Add(Cloude2_tileGO_worldPos);
        AllTileRelPos.Add(Cloude2_tileGO_relPos);
        AllTileScacle.Add(Cloude2_tileGO_Scale);

        AllTileWorldPos.Add(Seagull1_tileGO_worldPos);
        AllTileRelPos.Add(Seagull1_tileGO_relPos);
        AllTileScacle.Add(Seagull1_tileGO_Scale);

        AllTileWorldPos.Add(Seagull2_tileGO_worldPos);
        AllTileRelPos.Add(Seagull2_tileGO_relPos);
        AllTileScacle.Add(Seagull2_tileGO_Scale);

        AllTileWorldPos.Add(ScoreBox_tileGO_worldPos);
        AllTileRelPos.Add(ScoreBox_tileGO_relPos);
        AllTileScacle.Add(ScoreBox_tileGO_Scale);

        AllTileWorldPos.Add(InfoBox_tileGO_worldPos);
        AllTileRelPos.Add(InfoBox_tileGO_relPos);
        AllTileScacle.Add(InfoBox_tileGO_Scale);

        AllTileWorldPos.Add(IamageBox_tileGO_worldPos);
        AllTileRelPos.Add(IamageBox_tileGO_relPos);
        AllTileScacle.Add(IamageBox_tileGO_Scale);
    }
    private void Awake()
    {
        BuildLists();
        //BuildTally only works by looking intp the list of public gos and builds a string of vector3 pos loc scale and alist for ewach of em
        // BuildTally();
        DoOriginalPlacements_noCanvas();

    }

    void DoOriginalPlacements_noCanvas() {
        for (int x = 0; x < AllTileGOS.Count - 3; x++) {
            AllTileGOS[x].transform.position = AllTileWorldPos[x];


        }
    
    }

    void BuildTally() {
        List<string> orderedNameList = new List<string>();

        orderedNameList.Add("Sky_tileGO");


        orderedNameList.Add("Surfer_tileGO");

        orderedNameList.Add("Board_tileGO");

        orderedNameList.Add("BigWave_tileGO");

        orderedNameList.Add("BigFoam_tileGO");

        orderedNameList.Add("SmallFoam_tileGO");

        orderedNameList.Add("BackWave_tileGO");

        orderedNameList.Add("FrontWave_tileGO");

        orderedNameList.Add("Sun_tileGO");

        orderedNameList.Add("Cloud1_tileGO");

        orderedNameList.Add("Cloude2_tileGO");

        orderedNameList.Add("Seagull1_tileGO");

        orderedNameList.Add("Seagull2_tileGO");

        orderedNameList.Add("ScoreBox_tileGO");

        orderedNameList.Add(" InfoBox_tileGO");
        orderedNameList.Add(" IamageBox_tileGO");

        string Tally = "";
        string TallyAdds = "";

        for (int i = 0; i < AllTileGOS.Count; i++)
        {
            string NameOf_WorldPosV3Var = orderedNameList[i] + "_worldPos";
            string NameOf_LocalPsV3Var = orderedNameList[i] + "_relPos";
            string NameOf_ScaleV3Var = orderedNameList[i] + "_Scale";


            string outstrPosworld = "Vector3 " + NameOf_WorldPosV3Var + " = new Vector3(" + AllTileGOS[i].transform.position.x + "f , " + AllTileGOS[i].transform.position.y + "f , " + AllTileGOS[i].transform.position.z + "f); \n";
            string outstrPosLoc = "Vector3 " + NameOf_LocalPsV3Var + " = new Vector3(" + AllTileGOS[i].transform.localPosition.x + "f , " + AllTileGOS[i].transform.localPosition.y + "f , " + AllTileGOS[i].transform.localPosition.z + "f); \n";
            string outstrScale = "Vector3 " + NameOf_ScaleV3Var + " = new Vector3(" + AllTileGOS[i].transform.localScale.x + "f , " + AllTileGOS[i].transform.localScale.y + "f , " + AllTileGOS[i].transform.localScale.z + "f); \n";

            //List<Vector3> AllTileWorldPos;
            //List<Vector3> AllTileRelPos;
            //List<Vector3> AllTileScacle;
            string outstrADDPosworld = "AllTileWorldPos.Add("+ NameOf_WorldPosV3Var+"); \n";
            string outstrADDPoslocal = "AllTileRelPos.Add(" + NameOf_LocalPsV3Var + "); \n";
            string outstrADDscale = "AllTileScacle.Add(" + NameOf_ScaleV3Var + "); \n";

            //string outstrPosworld = "Vector3 " + orderedNameList[i] + "_worldPos = new Vector3(" + AllTileGOS[i].transform.position.x + "f , " + AllTileGOS[i].transform.position.y + "f , " + AllTileGOS[i].transform.position.z + "f); \n";
            //string outstrPosLoc = "Vector3 " + orderedNameList[i] + "_relPos = new Vector3(" + AllTileGOS[i].transform.localPosition.x + "f , " + AllTileGOS[i].transform.localPosition.y + "f , " + AllTileGOS[i].transform.localPosition.z + "f); \n";
            //string outstrScale = "Vector3 " + orderedNameList[i] + "_Scale = new Vector3(" + AllTileGOS[i].transform.localScale.x + "f , " + AllTileGOS[i].transform.localScale.y + "f , " + AllTileGOS[i].transform.localScale.z + "f); \n";


            Tally += outstrPosworld;
            TallyAdds += outstrADDPosworld;
            Tally += outstrPosLoc;
            TallyAdds += outstrADDPoslocal;
            Tally += outstrScale;
            TallyAdds += outstrADDscale;
            Tally += " \n";
            TallyAdds += " \n";
        }

        Debug.Log(Tally);
        Debug.Log(TallyAdds);
    }


    

}
