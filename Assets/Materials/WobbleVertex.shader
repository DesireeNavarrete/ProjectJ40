Shader "Custom/WobbleVertex"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _WobbleStrength ("Wobble Strength", Float) = 0.03
        _WobbleSpeed ("Frames Per Second", Float) = 8
        _WobbleFrequency ("Vertex Variation", Float) = 18
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #pragma multi_compile _ PIXELSNAP_ON
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            sampler2D _MainTex;
            sampler2D _AlphaTex;
            fixed4 _Color;
            fixed4 _RendererColor;
            float4 _Flip;
            float _EnableExternalAlpha;
            float _WobbleStrength;
            float _WobbleSpeed;
            float _WobbleFrequency;

            float4 UnityFlipSpriteVertex(float4 vertex, float4 flip)
            {
                return float4(vertex.xy * flip.xy, vertex.z, vertex.w);
            }

            v2f vert(appdata_t input)
            {
                v2f output;

                float4 vertex = UnityFlipSpriteVertex(input.vertex, _Flip);
                float frame = floor(_Time.y * _WobbleSpeed);
                float2 seed = (vertex.xy * _WobbleFrequency) + frame;
                float jitterX = frac(sin(dot(seed, float2(12.9898, 78.233))) * 43758.5453);
                float jitterY = frac(sin(dot(seed, float2(39.3468, 11.135))) * 24634.6345);
                vertex.xy += (float2(jitterX, jitterY) * 2.0 - 1.0) * _WobbleStrength;

                output.vertex = UnityObjectToClipPos(vertex);
                output.texcoord = input.texcoord;
                output.color = input.color * _Color * _RendererColor;

                #ifdef PIXELSNAP_ON
                output.vertex = UnityPixelSnap(output.vertex);
                #endif

                return output;
            }

            fixed4 SampleSpriteTexture(float2 uv)
            {
                fixed4 color = tex2D(_MainTex, uv);

                #if ETC1_EXTERNAL_ALPHA
                fixed4 alpha = tex2D(_AlphaTex, uv);
                color.a = lerp(color.a, alpha.r, _EnableExternalAlpha);
                #endif

                return color;
            }

            fixed4 frag(v2f input) : SV_Target
            {
                fixed4 color = SampleSpriteTexture(input.texcoord) * input.color;
                color.rgb *= color.a;
                return color;
            }
            ENDCG
        }
    }
}
