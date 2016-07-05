Shader "Sprites/Kalo"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)
		_GlowTex("Glow Texture", 2D) = "white" {}
		_GlowColor("Glow Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
	}

	SubShader
	{
	Tags
	{
		"Queue" = "Transparent"
		"IgnoreProjector" = "True"
		"RenderType" = "Transparent"
		"PreviewType" = "Plane"
		"CanUseSpriteAtlas" = "True"
	}

	Cull Off
	Lighting Off
	ZWrite Off
	Blend One OneMinusSrcAlpha

	CGPROGRAM
#pragma surface surf Lambert vertex:vert nofog keepalpha
#pragma multi_compile _ PIXELSNAP_ON

	sampler2D _MainTex;
	fixed4 _Color;
	sampler2D _AlphaTex;
	float _AlphaSplitEnabled;
	fixed4 _GlowColor;
	sampler2D _GlowTex;


	struct Input
	{
		float2 uv_MainTex;
		fixed4 color;
	};

	void vert(inout appdata_full v, out Input o)
	{
#if defined(PIXELSNAP_ON)
		v.vertex = UnityPixelSnap(v.vertex);
#endif

		UNITY_INITIALIZE_OUTPUT(Input, o);
		o.color = v.color * _Color;
	}

	fixed4 SampleSpriteTexture(sampler2D tex, float2 uv)
	{
		fixed4 color = tex2D(tex, uv);

#if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
		if (_AlphaSplitEnabled)
			color.a = tex2D(_AlphaTex, uv).r;
#endif //UNITY_TEXTURE_ALPHASPLIT_ALLOWED

		return color;
	}

	float rand(float2 co) {
		return frac(_Time[0] * sin(dot(co, float2(12.9898, 78.233))) * 43758.5453);
	}

	void surf(Input IN, inout SurfaceOutput o)
	{
		fixed4 c = SampleSpriteTexture(_MainTex, IN.uv_MainTex) * IN.color;
		fixed4 g = SampleSpriteTexture(_GlowTex, IN.uv_MainTex) * _GlowColor;
		o.Albedo = c.rgb * c.a + g.rgb * g.a * rand(IN.uv_MainTex);
		o.Alpha = c.a;
	}
	ENDCG
	}

	Fallback "Transparent/VertexLit"
}