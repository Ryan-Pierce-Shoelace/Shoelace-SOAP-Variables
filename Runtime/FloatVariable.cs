using UnityEngine;

namespace ShoelaceStudios.SOAP.Variables
{
	[CreateAssetMenu(fileName = "New Float SO", menuName = "🧩 SO Architecture/Variable/Numeric/Float", order = 0)]
	public class FloatVariable : SONumericVariable<float>
	{
		private const float EPSILON = 0.00001f;

        public override float GetNormalizedValue()
        {
            if (!useMinClamp || !useMaxClamp)
            {
                if (debugging)
                {
                    Debug.Log($"Cant normalize SO Variable {name} without both min and max values clamped");
                }
                return 0;
            }

            return Mathf.InverseLerp(minClamp, maxClamp, value);
        }

        protected override bool EqualityComparer(float a, float b)
		{
			return Mathf.Abs(a - b) < EPSILON;
		}
	}
}