using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public class UnitAttackConfiguration : ScriptableObject, ICanAttack
    {
        public float Cooldown = 2f;
        public float Damage = 15f;
        //public float HitBox = ??

        public void Attack()
        {
            Debug.Log("Doing the attack From");
        }
    }
}