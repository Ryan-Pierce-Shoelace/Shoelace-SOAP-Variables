using UnityEngine;

namespace ShoelaceStudios.SOAP.Variables
{
	[CreateAssetMenu(fileName = "New Int SO", menuName = "🧩 SO Architecture/Variables/Numeric/Int", order = 1)]
	public class IntVariable : SONumericVariable<int>
	{
		protected override bool EqualityComparer(int a, int b)
		{
			return a == b;
		}

        public override float GetNormalizedValue()
        {
            if(!useMinClamp || !useMaxClamp)
			{
				if(debugging)
				{
					Debug.Log($"Cant normalize SO Variable {name} without both min and max values clamped");
				}
				return 0;
			}


			return Mathf.InverseLerp(minClamp, maxClamp,value);
        }
    }
}