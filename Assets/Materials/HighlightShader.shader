Shader "Unlit/HighlightShader"
{
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			Cull Front 	//By culling the front faces of a larger unlit white cube around the unit, 
						//we can achieve a really simple highlight effect without getting into the depth buffer & full screen effects.
						//Unfortunately it still has a few issues; for example the highlight will be occluded by geometry, but in this
						//project that's never actually a problem.

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				return 1;//white (float4(1,1,1,1))
			}
			ENDCG
		}
	}
}
