using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformatiions : MonoBehaviour
{
    public GameObject Ball_green, Ball_red;
    public Transform objTf;
    void OnDrawGizmos()
    {
        Vector2 center =transform.position; 
        Vector2 playerPos = objTf.position; 
        Vector2 playerLookDir = objTf.right; // x axis,

        Vector2 VectorToPlayer = (playerPos - center);
        

        Gizmos.color = Color.white; 
        Gizmos.DrawLine(center, VectorToPlayer);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(playerPos, playerPos + playerLookDir);
    }

}