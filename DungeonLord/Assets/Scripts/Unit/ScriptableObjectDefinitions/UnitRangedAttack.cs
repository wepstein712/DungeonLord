using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    [CreateAssetMenu(menuName="Attacks/RangedAttack")]
    public class UnitRangedAttack : UnitAttackConfiguration
    {
        [HideInInspector]
        new readonly public AttackType TypeOfAttack = AttackType.Ranged;

        public GameObject ProjectileToSpawn;

        public override void Attack()
        {
            //Implement Ranged Attack
            //Take direction and transform?
        }
    }
}
