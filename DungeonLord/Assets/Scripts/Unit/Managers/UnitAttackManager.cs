using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public class UnitAttackManager : MonoBehaviour
    {

        public UnitAttackConfiguration _attackConfig;
        //public Animator _animator;
        public UnitAnimationManager _animator;

        private IUnitEventManager _eventManager;

        private float _nextAttackTime = 0f;
        
        void OnEnable()
        {
            _eventManager = GetComponent<IUnitEventManager>();
            _eventManager.UnitAttacked += AttackIfAble;
        }

        void OnDisable()
        {
            _eventManager.UnitAttacked -= AttackIfAble;
        }

        public void AttackIfAble()
        {
            Debug.Log("Checking if able to attack in UnitAttackManager");
            if(Time.time >= _nextAttackTime)
            {
                Debug.Log("Attacking in UnitAttackManager");
                //Attack
                //StartAttackAnimation
                

                //Set next available attack time
                _nextAttackTime = Time.time + _attackConfig.Cooldown;
            }
        }

        public void TriggerActiveAttackFrames()
        {
            //Not Sure exactly how to do this but this should be the right way
            //Do we need to pass in the direction of the attack?
            _attackConfig.Attack();
        }
    }
}