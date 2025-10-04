using System;
using UnityEngine;

namespace ShoelaceStudios.SOAP.Variables
{
    public abstract class SONumericVariable<TNumber> : SOVariable<TNumber> where TNumber : struct, IComparable<TNumber>
    {
        [Header("Clamp Settings")]
        public bool useMinClamp;
        public TNumber minClamp;

        public bool useMaxClamp;
        public TNumber maxClamp;

        public event Action ValueHitMin;
        public event Action ValueHitMax;

        public override TNumber Value
        {
            get => base.Value;
            set
            {
                if (readOnly) return;

                TNumber clamped = ClampValue(value);
                base.Value = clamped;
            }
        }

        protected virtual TNumber ClampValue(TNumber value)
        {
            if (useMinClamp && value.CompareTo(minClamp) < 0)
            {
               
                value = minClamp;
                ValueHitMin?.Invoke();
                if (debugging)
                {
                    Debug.Log($"{this.name} was set below the minimum value of {minClamp}. Value returned to minimum");
                }
            }
            if (useMaxClamp && value.CompareTo(maxClamp) > 0)
            {
                value = maxClamp;
                ValueHitMax?.Invoke();
                if (debugging)
                {
                    Debug.Log($"{this.name} was set above the maximum value of {maxClamp}. Value returned to maximum");
                }
            }

            return value;
        }

        public abstract float GetNormalizedValue();
    }
}
