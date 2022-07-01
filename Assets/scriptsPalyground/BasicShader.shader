Shader "Unlit/BasicShader"
{
    Properties
    {
       // _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            //themeshdata
            struct MeshDataz
            {
                float4 vertex : POSITION;
                
            };

            struct VertexOutput
            {
                
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

           

            VertexOutput vert (MeshDataz argMeshData)
            {
                VertexOutput o;
                o.vertex = UnityObjectToClipPos(argMeshData.vertex);
               // o.uv = TRANSFORM_TEX(argMeshData.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }


            float4 frag(VertexOutput argVertOutput) : SV_Target
            {
             
            return float4(0,0.5,1,0);
            }
      
            ENDCG
        }
    }
}
