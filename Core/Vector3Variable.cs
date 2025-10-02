using UnityEngine;

namespace Shoelace.SOVariables
{
	[CreateAssetMenu(fileName = "New Vector3 SO", menuName = "SO Architecture/Variable/Vector3")]
	public class Vector3Variable : SOVariable<Vector3>
	{
		[SerializeField] private bool clampValues;
		[SerializeField] private Vector3 minValue = Vector3.negativeInfinity;
		[SerializeField] private Vector3 maxValue = Vector3.positiveInfinity;

		private const float EPSILON = 0.00001f;

		protected override bool EqualityComparer(Vector3 a, Vector3 b)
		{
			float diffX = a.x - b.x;
			float diffY = a.y - b.y;
			float diffZ = a.z - b.z;
			return (diffX * diffX + diffY * diffY + diffZ * diffZ) < EPSILON * EPSILON;
		}

		protected override void ValueChange(Vector3 newVal)
		{
			if (clampValues)
			{
				newVal.x = newVal.x < minValue.x ? minValue.x : (newVal.x > maxValue.x ? maxValue.x : newVal.x);
				newVal.y = newVal.y < minValue.y ? minValue.y : (newVal.y > maxValue.y ? maxValue.y : newVal.y);
				newVal.z = newVal.z < minValue.z ? minValue.z : (newVal.z > maxValue.z ? maxValue.z : newVal.z);
			}

			base.ValueChange(newVal);
		}
	}
}