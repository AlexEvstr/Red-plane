Shader "Custom/ShieldShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Texture", 2D) = "white" {}
        _NoiseTex ("Noise Texture", 2D) = "white" {}
        _Radius ("Radius", Float) = 0.35
        _Feather ("Feather", Float) = 0.01
        _InnerRadius ("Inner Radius", Float) = 0.275
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _NoiseTex;
            fixed4 _Color;
            float _Radius;
            float _Feather;
            float _InnerRadius;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float circle(float2 position, float radius, float feather)
            {
                return smoothstep(radius, radius + feather, length(position - float2(0.5, 0.5)));
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float outer = circle(i.uv, _Radius, _Feather);
                float fade_effect = sin(_Time.y) * 0.01;
                float inner = 1.0 - circle(i.uv, _InnerRadius, 0.1 - fade_effect);
                
                fixed4 texColor = tex2D(_MainTex, i.uv);
                fixed4 noiseColor = tex2D(_NoiseTex, i.uv * 2.0 + _Time.y * 0.1);
                
                fixed4 color = texColor * _Color;
                color.a *= outer * noiseColor.r;
                color.a -= inner;
                
                return color;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
