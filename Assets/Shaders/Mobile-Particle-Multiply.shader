// Simplified Multiply Particle shader. Differences from regular Multiply Particle one:
// - no Smooth particle support
// - no AlphaTest
// - no ColorMask

Shader "Mobile/Particles/UnusualMultiply" {
Properties {
	_Color("Color Tint", Color) = (1,1,1,1)
	_MainTex ("Particle Texture", 2D) = "white" {}

}

Category {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	//	Blend Zero SrcColor
	Blend SrcAlpha OneMinusSrcAlpha
	Cull Off Lighting Off ZWrite Off Fog { Color (1,1,1,1) }
	
	BindChannels {
		Bind "Color", color
		Bind "Vertex", vertex
		Bind "TexCoord", texcoord
	}

		SubShader {
			Pass {
				SetTexture[_MainTex] {
					constantColor[_Color]
					combine texture * constant, texture * constant
				}
			}
		}
	}
}
