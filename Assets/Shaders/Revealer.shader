Shader "Chanko/Revealer"
{
    Properties
    {
    }
    SubShader
    {
        Tags {"Queue" = "Geometry-1" }
        LOD 200

        ColorMask 0
        ZWrite off
        Stencil
        {
            Ref 1
            Comp always
            Pass replace
        }

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard



        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };



        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
