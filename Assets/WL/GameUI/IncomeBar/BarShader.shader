Shader "Custom/BarShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Value ("Value", Range(0, 1)) = 0.5
        _WaveFrequency ("Wave Frequency", Range(0, 10)) = 0.1
        _WaveHeight ("Wave Height", Range(0, 1)) = 0.1
        _WaveSpeed ("Wave Speed", Range(0, 10)) = 0.1
        _WaveOffset("Wave Offset", Range(0, 10)) = 0.1

        _MainColor ("Main Color", Color) = (1, 1, 1, 1)
        _SubColor ("Sub Color", Color) = (1, 1, 1, 1)
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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Value;

            float _WaveFrequency;
            float _WaveHeight;
            float _WaveSpeed;
            float _WaveOffset;

            float4 _MainColor;
            float4 _SubColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);

                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                //float wave = sin(v.uv.y * _WaveFrequency + _Time.y * _WaveSpeed) * _WaveHeight;
                o.uv = v.uv;// +float2(wave, 0);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float wave = sin(i.uv.y * _WaveFrequency + _Time.y * _WaveSpeed+ _WaveOffset) * _WaveHeight;
            i.uv = i.uv + float2(wave, 0);


                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

                if (i.uv.x > _Value)
				{
					discard;
				}

                col *= lerp(_MainColor, _SubColor, 0.1);

                return col;
            }
            ENDCG
        }
    }
}
