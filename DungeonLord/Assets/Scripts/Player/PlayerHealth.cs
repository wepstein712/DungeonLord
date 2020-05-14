using System.Collections;
using System.Collections.Generic;
using Unit;
using UnityEngine;
using UnityEngine.UI;

namespace Unit
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        [Header("Stats")]
        [SerializeField]
        private float _currentHealth = 100;
        [SerializeField]
        private float _maxHealth = 100;

        public float CurrentHealth { get { return _currentHealth; } }

        public float MaxHealth { get { return _maxHealth; } }

        public float CurrentHealthPercent { get { return _currentHealth / _maxHealth; } }

        private void ChangeCurrentHealth(float newValue)
        {
            _currentHealth = newValue;
            //This is where we would do event checks like death checks and such perhaps.

            if(_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;

            if(_currentHealth < 0)
                _currentHealth = 0;

            HealthChanged?.Invoke();
        }

        public void SetNewMaxHealth(float newValue)
        {
            _maxHealth = newValue;

            if(_currentHealth > _maxHealth)
                ChangeCurrentHealth(_maxHealth);
        }

        public float HealAmount(float amount)
        {
            ChangeCurrentHealth(_currentHealth + amount);
            
            return _currentHealth;
        }

        public float TakeDamage(float damageAmount)
        {
            ChangeCurrentHealth(_currentHealth - damageAmount);

            return _currentHealth;
        }

        public float SetPercentHealth(float newPercent)
        {
            float modifiedNewPercent = newPercent;

            if(modifiedNewPercent < 0 )
                modifiedNewPercent = 0f;
            else if (modifiedNewPercent > 100)
                modifiedNewPercent = 100f;

            var targetValue = _maxHealth * modifiedNewPercent;
            _currentHealth = targetValue;
            return _currentHealth;
        }

        public float TakePercentDamage(float percentToTake)
        {
            var valueToTake = _maxHealth * percentToTake;

            ChangeCurrentHealth(_currentHealth);

            return _currentHealth;
        }

        //Events
        public event OnHealthChange HealthChanged;
    }
}
