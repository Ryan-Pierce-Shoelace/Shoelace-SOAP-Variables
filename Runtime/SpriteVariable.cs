using UnityEngine;

namespace ShoelaceStudios.SOAP.Variables
{
    [CreateAssetMenu(fileName = "New Transform SO", menuName = "🧩 SO Architecture/Variables/Reference/Sprite", order = 41)]
    public class SpriteVariable : SOVariable<Sprite>
    {
        public override Sprite Value
        {
            get
            {
                if (debugging)
                {
                    Debug.Log($"Getting {this.name} value - {value}");
                }

                return value;
            }
            set
            {
                if (readOnly)
                {
                    if (debugging)
                    {
                        Debug.Log($"{this.name} is set to read only. Value will not be changed");
                    }

                    return;
                }

                if (AreEqual(this.value, value))
                {
                    return;
                }

                PreValueChange(this.value);
                ValueChange(value);
                PostValueChange(value);
            }
        }

        private bool AreEqual(Sprite current, Sprite newValue)
        {
            if (current == null && newValue == null)
                return true;

            if (current == null || newValue == null)
                return false;
            return current.Equals(newValue);
        }
    }
}