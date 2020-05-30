using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    [CreateAssetMenu(menuName="Attacks/MeleeAttack")]
    public class UnitMeleeAttack : UnitAttackConfiguration
    {
        [HideInInspector]
        new readonly public AttackType TypeOfAttack = AttackType.Melee;

        public override void Attack()
        {
            //Implement Melee Attack
            //Take direction and transform?
        }
    }
}
