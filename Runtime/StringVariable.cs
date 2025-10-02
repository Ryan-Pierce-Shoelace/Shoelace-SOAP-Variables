using UnityEngine;

namespace Shoelace.SOVariables
{
    [CreateAssetMenu(fileName = "New String SO", menuName = "🧩 SO Architecture/Variable/String", order = 11)]

    public class StringVariable : SOVariable<string>
    {
        [SerializeField] private bool trimWhitespace = false;
        [SerializeField] private int maxLength = -1; //Negative for infitite size
        
        protected override bool EqualityComparer(string a, string b)
        {
            return string.CompareOrdinal(a, b) == 0;
        }
        
        protected override void ValueChange(string newVal)
        {
            if (newVal != null)
            {
                if (trimWhitespace)
                {
                    newVal = newVal.Trim();
                }
                
                if (maxLength > 0 && newVal.Length > maxLength)
                {
                    newVal = newVal.Substring(0, maxLength);
                    
                    #if UNITY_EDITOR
                    if (debugging)
                    {
                        Debug.Log(myName + " was trimmed to maximum length of " + maxLength);
                    }
                    #endif
                }
            }
            
            base.ValueChange(newVal);
        }
        
        public bool Contains(string subString)
        {
            return value != null && subString != null && value.IndexOf(subString, System.StringComparison.Ordinal) >= 0;
        }
        
        public string Concat(string other)
        {
            if (value == null) return other;
            if (other == null) return value;
            
            System.Text.StringBuilder sb = new System.Text.StringBuilder(value.Length + other.Length);
            sb.Append(value);
            sb.Append(other);
            return sb.ToString();
        }
    }
}