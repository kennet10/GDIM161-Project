Shader "Custom/GlowShader" {
    Properties{
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _GlowColor("Glow Color", Color) = (1, 1, 1, 1)
        _GlowIntensity("Glow Intensity", Range(0.0, 1.0)) = 0.5
    }

        SubShader{
            Tags {"Queue" = "Transparent" "RenderType" = "Transparent"}

            Pass {
                ZWrite Off
                Blend SrcAlpha One
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                    float4 color : COLOR;
                };

                sampler2D _MainTex;
                float4 _Color;
                float4 _GlowColor;
                float _GlowIntensity;

                v2f vert(appdata v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    o.color = _Color;
                    return o;
                }

                float4 frag(v2f i) : SV_Target {
                    float4 glow = _GlowColor * _GlowIntensity;
                    float4 tex = tex2D(_MainTex, i.uv);
                    return tex + glow;
                }
                ENDCG
            }
        }
            FallBack "Diffuse"
}
