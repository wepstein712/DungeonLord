using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public abstract class UnitAttackConfiguration : ScriptableObject, ICanAttack
    {
        public AttackType TypeOfAttack;
        public enum AttackType { Melee, Ranged };

        public float Cooldown = 2f;
        public float Damage = 15f;

        public virtual void Attack()
        {
            Debug.Log("Doing the attack From base of UnitAttackConfiguration");
        }
    }
}