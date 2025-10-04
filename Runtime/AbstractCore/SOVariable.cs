using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShoelaceStudios.SOAP.Variables
{
	public abstract class SOVariable<TValue> : ScriptableObject
	{
		[Header("VARIABLE")]
		[SerializeField] protected TValue value;
		[Header("Settings")]
		[SerializeField] protected bool readOnly;
		[SerializeField] protected bool debugging;

		public event Action<TValue> BeforeValueChange;
		public event Action<TValue> AfterValueChange;

		protected string myName;

		private void OnEnable()
		{
			myName = name;
		}


		public virtual TValue Value
		{
			get
			{
				if (debugging)
				{
					Debug.Log("Getting " + myName + " value - " + value);
				}

				return value;
			}
			set
			{
				if (readOnly)
				{
					if (debugging)
					{
						Debug.Log(myName + " is set to read only. Value will not be changed");
					}

					return;
				}

				if (EqualityComparer(this.value, value))
				{
					return;
				}

				TValue oldValue = this.value;

				PreValueChange(oldValue);
				ValueChange(value);
				PostValueChange(this.value);
			}
		}

		protected virtual void PreValueChange(TValue oldValue) => BeforeValueChange?.Invoke(oldValue);

		protected virtual void ValueChange(TValue newVal)
		{
			if (debugging)
			{
				#if UNITY_EDITOR
				LogValueChange(this.value, newVal);
				#endif
			}

			value = newVal;
		}

		protected virtual void PostValueChange(TValue newValue) => AfterValueChange?.Invoke(newValue);

		protected virtual bool EqualityComparer(TValue a, TValue b)
		{
			return EqualityComparer<TValue>.Default.Equals(a, b);
		}

		#if UNITY_EDITOR || DEVELOPMENT_BUILD

		private void LogValueChange(TValue oldVal, TValue newVal)
		{
			if (typeof(TValue) == typeof(string))
			{
				Debug.Log("Setting " + myName + " from '" + oldVal + "' to '" + newVal + "'");
			}
			else
			{
				Debug.Log("Setting " + myName + " from " + oldVal + " to " + newVal);
			}
		}
		#endif
	}
}