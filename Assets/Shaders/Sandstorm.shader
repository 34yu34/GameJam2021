Shader "Camera/Sandstorm"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag(v2f i) : SV_Target
            {
                float2 coord = i.uv;
                
                coord.x = coord.x * _Time % 1.0f;
                coord.y = coord.y * _Time % 1.0f;

                fixed4 col = tex2D(_MainTex, i.uv);
                col.b = col.b - 0.75f;
                col.r = col.r - 0.075f;
                col.g = col.g - 0.165f;

                return col;
            }
            ENDCG
        }
    }
}
