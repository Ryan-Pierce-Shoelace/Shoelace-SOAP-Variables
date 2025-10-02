using UnityEngine;

namespace Shoelace.SOVariables
{
    [CreateAssetMenu(fileName = "New Quaternion SO", menuName = "SO Architecture/Variable/Quaternion")]
    public class QuaternionVariable : SOVariable<Quaternion>
    {
        [SerializeField] private bool lockX, lockY, lockZ;
        private const float ANGLE_EPSILON = 0.01f;
		
        public Vector3 EulerAngles
        {
            get => Value.eulerAngles;
            set => Value = Quaternion.Euler(value);
        }
		
        protected override void ValueChange(Quaternion newVal)
        {
            if (lockX || lockY || lockZ)
            {
                Vector3 euler = newVal.eulerAngles;
                if (lockX) euler.x = Value.eulerAngles.x;
                if (lockY) euler.y = Value.eulerAngles.y;
                if (lockZ) euler.z = Value.eulerAngles.z;
                newVal = Quaternion.Euler(euler);
            }

            base.ValueChange(newVal);
        }
        protected override bool EqualityComparer(Quaternion a, Quaternion b)
        {
            return Quaternion.Angle(a, b) < ANGLE_EPSILON;
        }
        public void LerpTo(Quaternion target, float t) => Value = Quaternion.Lerp(Value, target, t);
        public void SlerpTo(Quaternion target, float t) => Value = Quaternion.Slerp(Value, target, t);
    }
}