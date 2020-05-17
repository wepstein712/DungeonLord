using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unit;

namespace Unit 
{
    public interface IResource
    {
        float CurrentValue {get;}
        
        float MaxValue {get;}
        
        float CurrentPercentOfMax {get;}

        void SetNewMaxValue(float newValue);
        
        ///Returns the new health value
        float SubtractAmount(float amount);

        ///Returns the new health value
        float RestoreAmount(float amount);

        ///Returns the new health value
        float SubtractPercentOfMax(float percentToSubtract);

        ///Returns the new health value
        float SetCurrentPercentOfMax(float newPercent);

        //Events
        event OnResourceChange ResourceChanged;
    }
}