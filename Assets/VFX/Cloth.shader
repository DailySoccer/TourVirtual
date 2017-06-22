// Shader created by FedericoArroyo //

Shader "Cloth" {
    Properties {
        _COLOR_TEX ("COLOR_TEX", 2D) = "white" {}
        _BaseCOLOR ("BaseCOLOR", Color) = (1,1,1,1)
        _FrnlEXP ("FrnlEXP", Float ) = 0
        [MaterialToggle] _USENM ("USENM", Float ) = 0
        _NM_TEX ("NM_TEX", 2D) = "bump" {}
        [MaterialToggle] _MULTBASECOLOR ("MULTBASECOLOR", Float ) = 0.4941176
        _FresnelCOLOR ("FresnelCOLOR", Color) = (1,1,1,1)
        [MaterialToggle] _TEXFRCOLFRCOL ("TEXFRCOL/FRCOL", Float ) = 1
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
            uniform float _FrnlEXP;
            uniform fixed _USENM;
            uniform sampler2D _NM_TEX; uniform float4 _NM_TEX_ST;
            uniform fixed _MULTBASECOLOR;
            uniform float4 _FresnelCOLOR;
            uniform fixed _TEXFRCOLFRCOL;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_73 = i.uv0;
                float3 normalLocal = lerp( float3(0,0,1), UnpackNormal(tex2D(_NM_TEX,TRANSFORM_TEX(node_73.rg, _NM_TEX))).rgb, _USENM );
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
////// Lighting:
////// Emissive:
                float4 node_2 = tex2D(_COLOR_TEX,TRANSFORM_TEX(node_73.rg, _COLOR_TEX));
                float3 emissive = (lerp( (node_2.rgb*_BaseCOLOR.rgb), node_2.rgb, _MULTBASECOLOR )+(lerp( _FresnelCOLOR.rgb, (node_2.rgb*_FresnelCOLOR.rgb), _TEXFRCOLFRCOL )*pow(1.0-max(0,dot(normalDirection, viewDirection)),_FrnlEXP)));
                float3 finalColor = emissive;
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
