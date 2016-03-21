// Simplified Multiply Particle shader. Differences from regular Multiply Particle one:
// - no Smooth particle support
// - no AlphaTest
// - no ColorMask

Shader "Mobile/Particles/UnusualSprite" {
Properties {
	_Color("Color Tint", Color) = (1,1,1,1)
	_MainTex ("Particle Texture", 2D) = "white" {}


	_StencilComp("Stencil Comparison", Float) = 8
	_Stencil("Stencil ID", Float) = 0
	_StencilOp("Stencil Operation", Float) = 0
	_StencilWriteMask("Stencil Write Mask", Float) = 255
	_StencilReadMask("Stencil Read Mask", Float) = 255

	_ColorMask("Color Mask", Float) = 15


}

Category {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }

	Stencil
	{
		Ref[_Stencil]
		Comp[_StencilComp]
		Pass[_StencilOp]
		ReadMask[_StencilReadMask]
		WriteMask[_StencilWriteMask]
	}
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
