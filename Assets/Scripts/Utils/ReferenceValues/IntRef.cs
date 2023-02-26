using UnityEngine;

namespace Utils.ReferenceValues
{
    [CreateAssetMenu]
    public class IntRef : ScriptableObject
    {
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
            }
        }

        private int _value; 
    }
}