using UnityEngine;

namespace Shoelace.SOVariables
{
	[CreateAssetMenu(fileName = "New Int SO", menuName = "SO Architecture/Variable/Numeric/Int")]
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