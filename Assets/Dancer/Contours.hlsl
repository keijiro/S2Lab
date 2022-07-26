#include "Packages/jp.keijiro.noiseshader/Shader/SimplexNoise3D.hlsl"

void Contour_float(float3 wpos, float4 params, out float output)
{
    float p = wpos.y * params.x + _Time.y * params.y;
    float w = 1 - saturate(abs(frac(p) - 0.5) / (fwidth(p) * params.z));
    output = w * params.w;
}

void Highlight_float(float3 wpos, float4 params, out float output)
{
    float w = frac(wpos.y * params.x - _Time.y * params.y);
    output = pow(w, params.z);
}

void Grain_float(float3 wpos, float2 params, out float output)
{
    output = max(0, SimplexNoise(wpos * params.x) * params.y + 1);
}

void Sparkles_float(float3 wpos, float4 params, out float output)
{
    float3 p = wpos * params.x + float3(0, 0, _Time.y * params.y);
    float w = pow(abs(SimplexNoise(p)), params.z);
    output = w * params.w;
}
