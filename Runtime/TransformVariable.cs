using UnityEngine;

namespace ShoelaceStudios.SOAP.Variables
{
	[CreateAssetMenu(fileName = "New Transform SO", menuName = "🧩 SO Architecture/Variables/Reference/Transform", order = 40)]
	public class TransformVariable : SOVariable<Transform>
	{
		protected override bool EqualityComparer(Transform a, Transform b)
		{
			return ReferenceEquals(a, b);
		}


		protected override void ValueChange(Transform newVal)
		{
			if (this.value == null && newVal == null)
			{
				return;
			}

			base.ValueChange(newVal);
		}
	}
}