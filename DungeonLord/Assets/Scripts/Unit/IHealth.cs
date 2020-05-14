using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unit;

namespace Unit 
{
    public interface IHealth
    {
        float CurrentHealth {get;}
        
        float MaxHealth {get;}
        
        float CurrentHealthPercent {get;}

        void SetNewMaxHealth(float newValue);
        
        ///Returns the new health value
        float TakeDamage(float damageAmount);

        ///Returns the new health value
        float HealAmount(float amount);

        ///Returns the new health value
        float TakePercentDamage(float percentToTake);

        ///Returns the new health value
        float SetPercentHealth(float newPercent);

        //Events
        event OnHealthChange HealthChanged;
    }
}