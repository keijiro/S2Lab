using UnityEngine;

namespace S2Lab {

sealed class TriggerToDancerParams : MonoBehaviour
{
    [SerializeField] Transform _trigger1 = null;
    [SerializeField] Transform _trigger2 = null;
    [SerializeField] Vector2 _multiplier = Vector2.one;

    void Update()
    {
        var p = _trigger1.localPosition.x * _multiplier.x +
                _trigger2.localPosition.x * _multiplier.y;
        Shader.SetGlobalFloat("_DancerDisplacement", p);
    }
}

} // namespace S2Lab
