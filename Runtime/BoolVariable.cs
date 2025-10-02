using UnityEngine;

namespace Shoelace.SOVariables
{
    [CreateAssetMenu(fileName = "New Bool SO", menuName = "SO Architecture/Variable/Bool")]
    public class BoolVariable : SOVariable<bool>
    {
        public bool IsTrue() => Value;
        public bool IsFalse() => !Value;
    }
}
