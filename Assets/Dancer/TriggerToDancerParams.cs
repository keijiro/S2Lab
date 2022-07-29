using UnityEngine;

namespace S2Lab {

sealed class TriggerToDancerParams : MonoBehaviour
{
    [SerializeField] Transform _trigger1 = null;
    [SerializeField] Transform _trigger2 = null;
    [SerializeField] Transform _trigger3 = null;
    [SerializeField] Vector3 _multiplier = Vector3.one;

    void Update()
    {
        var x = _trigger1.localPosition.x * _multiplier.x;
        var y = _trigger2.localPosition.x * _multiplier.y;
        var z = _trigger3.localPosition.x * _multiplier.z;
        Shader.SetGlobalVector("_DancerDisplacement", new Vector3(x, y, z));
    }
}

} // namespace S2Lab
