using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public class UnitAttackManager : MonoBehaviour, ICanAttack
    {
        public UnitAttackConfiguration _attackConfig;

        public void Attack()
        {
            Debug.Log("Attacking in UnitAttackManager");
            _attackConfig.Attack();
        }
    }
}