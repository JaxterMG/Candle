Shader "Custom/SphereMaskCombined"
{
    Properties
    {
        _MainTex ("Inside Texture", 2D) = "white" {}
        _OutsideTex ("Outside Texture", 2D) = "white" {}
        _SpherePosition ("Sphere Position", Vector) = (0, 0, 0, 0)
        _SphereRadius ("Sphere Radius", Range(0, 10)) = 5.0
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
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            sampler2D _MainTex;
            sampler2D _OutsideTex;
            float4 _MainTex_ST;
            float4 _SpherePosition;
            float _SphereRadius;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                float3 sphereCenter = _SpherePosition.xyz;
                float distanceToCenter = distance(i.worldPos, sphereCenter);

                if (distanceToCenter <= _SphereRadius)
                {
                    half4 col = tex2D(_MainTex, i.worldPos.xz / _MainTex_ST.xy);
                    return col;
                }
                else
                {
                    half4 col = tex2D(_OutsideTex, i.worldPos.xz / _MainTex_ST.xy);
                    return col;
                }
            }
            ENDCG
        }
    }
}