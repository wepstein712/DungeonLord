using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public class UnitAttackConfiguration : ScriptableObject, ICanAttack
    {


        public void Attack()
        {
            Debug.Log("Doing the attack From");
        }
    }
}