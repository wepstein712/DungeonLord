using System.Collections;
using System.Collections.Generic;
using Unit;
using UnityEngine;
using UnityEngine.UI;

namespace Unit
{
    public class UnitMana : MonoBehaviour, IMana, IResource
    {
        [Header("Stats")]
        [SerializeField]
        private float _currentMana = 100;
        [SerializeField]
        private float _maxMana = 100;

        public float CurrentValue { get { return _currentMana; } }

        public float MaxValue { get { return _maxMana; } }

        public float CurrentPercentOfMax { get { return _currentMana / _maxMana; } }

        private void ChangeCurrentMana(float newValue)
        {
            _currentMana = newValue;
            //This is where we would do event checks like death checks and such perhaps.

            if(_currentMana > _maxMana)
                _currentMana = _maxMana;

            if(_currentMana < 0)
                _currentMana = 0;

            ResourceChanged?.Invoke();
        }

        public void SetNewMaxValue(float newValue)
        {
            _maxMana = newValue;

            if(_currentMana > _maxMana)
                ChangeCurrentMana(_maxMana);
        }

        public float SubtractAmount(float damageAmount)
        {
            ChangeCurrentMana(_currentMana - damageAmount);

            return _currentMana;
        }

        public float RestoreAmount(float amount)
        {
            ChangeCurrentMana(_currentMana + amount);
            
            return _currentMana;
        }

        public float SubtractPercentOfMax(float percentToTake)
        {
            var valueToTake = _maxMana * percentToTake;

            ChangeCurrentMana(_currentMana);

            return _currentMana;
        }

        public float SetCurrentPercentOfMax(float newPercent)
        {
            float modifiedNewPercent = newPercent;

            if(modifiedNewPercent < 0 )
                modifiedNewPercent = 0f;
            else if (modifiedNewPercent > 100)
                modifiedNewPercent = 100f;

            var targetValue = _maxMana * modifiedNewPercent;
            _currentMana = targetValue;
            return _currentMana;
        }

        //Events
        public event OnResourceChange ResourceChanged;
    }
}
