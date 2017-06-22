// Shader created by FedericoArroyo //

Shader "IBL_Standard" {
    Properties {
        _CUBEMAP_TEX ("CUBEMAP_TEX", Cube) = "_Skybox" {}
        _NM_TEX ("NM_TEX", 2D) = "bump" {}
        [MaterialToggle] _USENM ("USENM", Float ) = 0
        _FresEXP ("FresEXP", Float ) = 0
        _SPEC_TEX ("SPEC_TEX", 2D) = "black" {}
        [MaterialToggle] _USESPEC ("USESPEC", Float ) = 1
        _COLOR_TEX ("COLOR_TEX", 2D) = "black" {}
        [MaterialToggle] _USECOLORTEX ("USECOLORTEX", Float ) = 0
        _COLOR ("COLOR", Color) = (0,0,0,0)
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
            uniform samplerCUBE _CUBEMAP_TEX;
            uniform sampler2D _NM_TEX; uniform float4 _NM_TEX_ST;
            uniform fixed _USENM;
            uniform float _FresEXP;
            uniform sampler2D _SPEC_TEX; uniform float4 _SPEC_TEX_ST;
            uniform fixed _USESPEC;
            uniform sampler2D _COLOR_TEX; uniform float4 _COLOR_TEX_ST;
            uniform fixed _USECOLORTEX;
            uniform float4 _COLOR;
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
                float2 node_126 = i.uv0;
                float3 normalLocal = lerp( float3(0,0,1), UnpackNormal(tex2D(_NM_TEX,TRANSFORM_TEX(node_126.rg, _NM_TEX))).rgb, _USENM );
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float4 node_92 = tex2D(_COLOR_TEX,TRANSFORM_TEX(node_126.rg, _COLOR_TEX));
                float3 emissive = (((pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresEXP)*(reflect(texCUBE(_CUBEMAP_TEX,viewReflectDirection).rgb,float3(0,0,0))+float3(0,0,0)))*lerp( 1.0, tex2D(_SPEC_TEX,TRANSFORM_TEX(node_126.rg, _SPEC_TEX)).r, _USESPEC ))+lerp( (_COLOR.rgb*node_92.rgb), node_92.rgb, _USECOLORTEX ));
                float3 finalColor = emissive;
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}