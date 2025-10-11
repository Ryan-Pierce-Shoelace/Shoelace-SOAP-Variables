using UnityEngine;

namespace ShoelaceStudios.SOAP.Variables
{
    [CreateAssetMenu(fileName = "New Bool SO", menuName = "🧩 SO Architecture/Variables/Bool", order = 10)]
    public class BoolVariable : SOVariable<bool>
    {
        public bool IsTrue() => Value;
        public bool IsFalse() => !Value;
    }
}
