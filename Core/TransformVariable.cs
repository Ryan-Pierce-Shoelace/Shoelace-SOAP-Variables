using UnityEngine;

namespace Shoelace.SOVariables
{
	[CreateAssetMenu(fileName = "New Transform SO", menuName = "SO Architecture/Variable/Transform")]
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