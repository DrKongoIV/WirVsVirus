Shader "Somian/Unlit/Transparent" {

	Properties{
		_Color("Main Color (A=Opacity)", Color) = (1,1,1,1)
	}

		Category{
			Tags {"Queue" = "Transparent" "IgnoreProjector" = "True"}
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

			SubShader {Pass {
				GLSLPROGRAM
				varying mediump vec2 uv;

				#ifdef VERTEX
				uniform mediump vec4 _MainTex_ST;
				void main() {
					gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
				}
				#endif

				#ifdef FRAGMENT
				uniform lowp sampler2D _MainTex;
				uniform lowp vec4 _Color;
				void main() {
					gl_FragColor = _Color;
				}
				#endif     
				ENDGLSL
			}}

			SubShader {Pass {
				SetTexture[_MainTex] {ConstantColor[_Color]}
			}}
	}

}
