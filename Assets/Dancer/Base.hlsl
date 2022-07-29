#include "Packages/jp.keijiro.noiseshader/Shader/SimplexNoise3D.hlsl"

float3 _DancerDisplacement;

void VertexOffset_float(float3 pos, float3 nrm, out float3 output)
{
    float3 dp = pos * 10 - float3(0, _Time.y * 10, 0);
    float d1 = SimplexNoise(dp    );
    float d2 = SimplexNoise(dp * 2);
    float d3 = SimplexNoise(dp * 4);
    output = nrm * dot(float3(d1, d2, d3), _DancerDisplacement);
}
