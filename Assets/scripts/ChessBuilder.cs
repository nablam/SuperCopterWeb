using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBuilder : MonoBehaviour
{
    public Texture2D[] AllReds;
    public GameObject[] AllBlackChessObjs;
    public GameObject[] AllWhiteChessObjs;
    public GameObject sampleObj;
    public Material samplmat;
    float width, height;
    private void Awake()
    {
        width = height = 1;
        AllReds = Resources.LoadAll<Texture2D>("Red64");
        samplmat = Resources.Load<Material>("MyMaterials/Mat_chess_S");

        sampleObj = new GameObject("samle");
       
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(0, 0, 0),
            new Vector3(width, 0, 0),
            new Vector3(0, height, 0),
            new Vector3(width, height, 0)
        };
        mesh.vertices = vertices;
        int[] tris = new int[6]
        {
            // lower left triangle
            0, 2, 1,
            // upper right triangle
            2, 3, 1
        };
        mesh.triangles = tris;
        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        mesh.normals = normals;
        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        mesh.uv = uv;

        sampleObj.AddComponent<MeshFilter>();
        sampleObj.GetComponent<MeshFilter>().mesh = mesh;
        sampleObj.AddComponent<MeshRenderer>();
        sampleObj.AddComponent<MeshCollider>();
        sampleObj.GetComponent<Renderer>().receiveShadows = false;
        sampleObj.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        sampleObj.GetComponent<Renderer>().material = samplmat;
        sampleObj.GetComponent<Renderer>().material.mainTexture = AllReds[0];
        sampleObj.GetComponent<Renderer>().material.SetFloat("_FlipColors", 0.0f);
    }
    void Start()
    {
        
    }
    GameObject CreateATile(int argId, bool argisblack) {
        float _flipcolor = 1.0f;
        if (argisblack) {
            _flipcolor = 0.0f;
        }
    GameObject Tile= new GameObject("tile"+argId.ToString());

        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(0, 0, 0),
            new Vector3(width, 0, 0),
            new Vector3(0, height, 0),
            new Vector3(width, height, 0)
        };
        mesh.vertices = vertices;
        int[] tris = new int[6]
        {
            // lower left triangle
            0, 2, 1,
            // upper right triangle
            2, 3, 1
        };
        mesh.triangles = tris;
        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        mesh.normals = normals;
        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        mesh.uv = uv;

        Tile.AddComponent<MeshFilter>();
        Tile.GetComponent<MeshFilter>().mesh = mesh;
        Tile.AddComponent<MeshRenderer>();
        Tile.AddComponent<MeshCollider>();
        Tile.GetComponent<Renderer>().receiveShadows = false;
        Tile.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        sampleObj.GetComponent<Renderer>().material = samplmat;
        sampleObj.GetComponent<Renderer>().material.mainTexture = AllReds[0];
        sampleObj.GetComponent<Renderer>().material.SetFloat("_FlipColors", _flipcolor);

        return Tile;
    }
    void createBlackPawns() {
        for (int p = 0; p < 8; p++) {
            string name = "blackPawn_" + p;


        }
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
