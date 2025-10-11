using UnityEngine;

namespace ShoelaceStudios.SOAP.Variables
{
	[CreateAssetMenu(fileName = "New Vector2 SO", menuName = "🧩 SO Architecture/Variables/Vector/Vector2", order = 21)]
	public class Vector2Variable : SOVariable<Vector2>
	{
		[SerializeField] private bool clampValues;
		[SerializeField] private Vector2 minValue = Vector2.negativeInfinity;
		[SerializeField] private Vector2 maxValue = Vector2.positiveInfinity;

		private const float EPSILON = 0.00001f;

		protected override bool EqualityComparer(Vector2 a, Vector2 b)
		{
			float diffX = a.x - b.x;
			float diffY = a.y - b.y;
			return (diffX * diffX + diffY * diffY) < EPSILON * EPSILON;
		}

		protected override void ValueChange(Vector2 newVal)
		{
			if (clampValues)
			{
				newVal.x = newVal.x < minValue.x ? minValue.x : (newVal.x > maxValue.x ? maxValue.x : newVal.x);
				newVal.y = newVal.y < minValue.y ? minValue.y : (newVal.y > maxValue.y ? maxValue.y : newVal.y);
			}

			base.ValueChange(newVal);
		}
	}
}