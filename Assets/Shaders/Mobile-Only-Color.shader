Shader "Mobile/UnusualOnlyColor" {
Properties {
	_Color("Color Tint", Color) = (1,1,1,1)
}

Category {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	Cull Off Lighting Off ZWrite Off Fog { Color (0,0,0,0) }
	
	SubShader {
		Pass {
			Color[_Color]
		}
	}
}
}