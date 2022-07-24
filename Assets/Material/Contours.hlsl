#include "Packages/jp.keijiro.noiseshader/Shader/SimplexNoise3D.hlsl"

void Contour_float(float3 wpos, float3 cparams, float4 hparams, out float output)
{
    float p = wpos.y * cparams.x + _Time.y * cparams.y;
    float w = 1 - saturate(abs(frac(p) - 0.5) / (fwidth(p) * cparams.z));
    float l = frac(floor(p) * hparams.x - _Time.y * hparams.y);
    output = w * (1 + pow(l, hparams.z) * hparams.w);
}

void Grain_float(float3 wpos, float2 params, out float output)
{
    output = max(0, SimplexNoise(wpos * params.x) * params.y + 1);
}

void Sparkles_float(float3 wpos, float4 params, out float output)
{
    float3 p = wpos * params.x + float3(0, 0, _Time.y * params.y);
    float w = pow(abs(SimplexNoise(p)), params.z);
    output = 1 + w * params.w;
}
