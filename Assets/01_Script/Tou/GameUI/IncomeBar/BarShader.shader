Shader "Custom/BarShader"
{
    Properties
    {
        //[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" { }
        _MainTex("Texture", 2D) = "white" {}
        _Value ("Value", Range(0, 1)) = 0.5
        _WaveFrequency ("Wave Frequency", Range(0, 10)) = 0.1
        _WaveHeight ("Wave Height", Range(0, 1)) = 0.1
        _WaveSpeed ("Wave Speed", Range(0, 10)) = 0.1
        _WaveOffset("Wave Offset", Range(0, 10)) = 0.1

        _MainColor("Main Color",Color) = (1, 1, 1, 1)
        _SubColor ("Sub Color", Color) = (1, 1, 1, 1)

        _StencilComp("Stencil Comparison", Float) = 8
        _Stencil("Stencil ID", Float) = 0
        _StencilOp("Stencil Operation", Float) = 0
        _StencilWriteMask("Stencil Write Mask", Float) = 255
        _StencilReadMask("Stencil Read Mask", Float) = 255
        _ColorMask("Color Mask", Float) = 15
        [Toggle(UNITY_UI_ALPHACLIP)]  _UseUIAlphaClip("Use Alpha Clip", Float) = 0.000000
    }

    SubShader
    {

            //Tags{"TYPE"="Opaque"}
        Tags { "QUEUE" = "Transparent"  "RenderType" = "Transparent" }  
        LOD 100
            //Name "Default"
            //Tags { "QUEUE" = "Transparent" "IGNOREPROJECTOR" = "true" "RenderType" = "Transparent" "CanUseSpriteAtlas" = "true" "PreviewType" = "Plane" }

        Pass
        {
           ZTest[unity_GUIZTestMode]
            ZWrite Off
            Cull Off
            Stencil {
             Ref[_Stencil]
             ReadMask[_StencilReadMask]
             WriteMask[_StencilWriteMask]
             Comp[_StencilComp]
             Pass[_StencilOp]
            }
            //Blend One OneMinusSrcAlpha
            ColorMask[_ColorMask]


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

                o.uv = v.uv;

                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float wave = sin(i.uv.x * _WaveFrequency + _Time.y * _WaveSpeed + _WaveOffset) * _WaveHeight + _WaveHeight;
                i.uv = i.uv + float2(0, wave);


                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

                if (i.uv.y > _Value)
				{
					discard;
				}

                col = _MainColor;

                return col;
            }
            ENDCG
        }
    }
}
