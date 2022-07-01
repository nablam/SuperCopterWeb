using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessController : MonoBehaviour
{

   public  Sprite[] spriteSheetSprites;
    public GameObject SpritObj_template;
    float pieceSize;
    float PiecePlaceOffset;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject[] AllPoecesObjs;
    private void Awake()
    {
          //pieceSize = 0.064f;
        PiecePlaceOffset = 0.5f;// pieceSize*2;
        spriteSheetSprites = Resources.LoadAll<Sprite>("CP_512_multi");
        AllPoecesObjs = new GameObject[spriteSheetSprites.Length];
        Texture2D tempTxt2d = CopyTexture2D(spriteSheetSprites[0].texture);
        for (int x = 0; x < 8; x++) {
            

            AllPoecesObjs[x] = Instantiate(SpritObj_template) as GameObject;


            SpriteRenderer sr = AllPoecesObjs[x].GetComponent<SpriteRenderer>();
            sr.sprite = spriteSheetSprites[x];

            
            string tempName = sr.sprite.name;
            sr.sprite = Sprite.Create(tempTxt2d, sr.sprite.rect, new Vector2(0.5f,0.5f ));
            sr.sprite.name = tempName+"z";

             sr.material.mainTexture = tempTxt2d;
            //sr.material.shader = Shader.Find("Sprites/Transparent Unlit");
            AllPoecesObjs[x].transform.position = new Vector3(x* PiecePlaceOffset,0, 0);
        }
    }

    public Texture2D CopyTexture2D(Texture2D copiedTexture)
    {
        Texture2D texture = new Texture2D(copiedTexture.width, copiedTexture.height);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;

        int y = 0;
        while (y < texture.height)
        {
            int x = 0;
            while (x < texture.width)
            {
                //INSERT YOUR LOGIC HERE
                if (copiedTexture.GetPixel(x, y) == Color.black)
                {
                    //This line of code and if statement, turn Green pixels into Red pixels.
                    texture.SetPixel(x, y, new Color(0,0,0,0.4f));
                }
                else
                {
                    //This line of code is REQUIRED. Do NOT delete it. This is what copies the image as it was, without any change.
                    texture.SetPixel(x, y, copiedTexture.GetPixel(x, y));
                }
                ++x;
            }
            ++y;
        }
        //Name the texture, if you want.
        texture.name = ( "_SpriteSheet_v2");

        //This finalizes it. If you want to edit it still, do it before you finish with .Apply(). Do NOT expect to edit the image after you have applied. It did NOT work for me to edit it after this function.
        texture.Apply();

        //Return the variable, so you have it to assign to a permanent variable and so you can use it.
        return texture;
    }

    //public void UpdateCharacterTexture()
    //{
    //    //This calls the copy texture function, and copies it. The variable characterTextures2D is a Texture2D which is now the returned newly copied Texture2D.
    //    characterTexture2D = CopyTexture2D(gameObject.GetComponent<SpriteRenderer>().sprite.texture);

    //    //Get your SpriteRenderer, get the name of the old sprite,  create a new sprite, name the sprite the old name, and then update the material. If you have multiple sprites, you will want to do this in a loop- which I will post later in another post.
    //    SpriteRenderer sr = GetComponent<SpriteRenderer>();
    //    string tempName = sr.sprite.name;
    //    sr.sprite = Sprite.Create(characterTexture2D, sr.sprite.rect, new Vector2(0, 1));
    //    sr.sprite.name = tempName;

    //    sr.material.mainTexture = characterTexture2D;
    //    sr.material.shader = Shader.Find("Sprites/Transparent Unlit");

    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
