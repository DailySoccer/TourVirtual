// Shader created by FedericoArroyo //

Shader "EmiUnlitStandard" {
    Properties {
        _COLOR_TEX ("COLOR_TEX", 2D) = "white" {}
        _BaseCOLOR ("BaseCOLOR", Color) = (1,1,1,1)
        _EMISIVE_TEX ("EMISIVE_TEX", 2D) = "white" {}
        _EmisiveInt ("EmisiveInt", Float ) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _COLOR_TEX; uniform float4 _COLOR_TEX_ST;
            uniform float4 _BaseCOLOR;
            uniform sampler2D _EMISIVE_TEX; uniform float4 _EMISIVE_TEX_ST;
            uniform float _EmisiveInt;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float2 node_31 = i.uv0;
                float3 emissive = ((tex2D(_COLOR_TEX,TRANSFORM_TEX(node_31.rg, _COLOR_TEX)).rgb*_BaseCOLOR.rgb)+(tex2D(_EMISIVE_TEX,TRANSFORM_TEX(node_31.rg, _EMISIVE_TEX)).rgb*_EmisiveInt));
                float3 finalColor = emissive;
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
