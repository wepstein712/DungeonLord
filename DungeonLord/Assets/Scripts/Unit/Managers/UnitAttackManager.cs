using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public class UnitAttackManager : MonoBehaviour
    {

        public UnitAttackConfiguration _attackConfig;

        private UnitManager _eventManager;
        private Vector2 _direction;
        private float _nextAttackTime = 0f;
        
        void OnEnable()
        {
            _eventManager = GetComponent<UnitManager>();
            _eventManager.AttackCommandGiven += AttackIfAble;
            _eventManager.UnitMoved += GetCurrentDirection;
        }

        void OnDisable()
        {
            _eventManager.AttackCommandGiven -= AttackIfAble;
            _eventManager.UnitMoved -= GetCurrentDirection;
        }

        public void AttackIfAble()
        {
            Debug.Log("Checking if able to attack in UnitAttackManager");
            if(Time.time >= _nextAttackTime)
            {
                Debug.Log("Attacking in UnitAttackManager");
                //Trigger other related attack events
                _eventManager.InvokeUnitAttacked(_attackConfig);

                //ToDo:
                //Get direction based on animation blend tree state and "Movement" and use that as key for a dictionary for direction or switch case???? This would bare minimum allow us to go with whatever direction the unit is facing no matter what
                //----------------
                //_attackConfig.Attack(this.transform, _direction);
                //----------------

                //Set next available attack time
                _nextAttackTime = Time.time + _attackConfig.Cooldown;
            }
        }

        public void TriggerActiveAttackFrames()
        {
            //Not Sure exactly how to do this but this should be the right way
            //Do we need to pass in the direction of the attack?
            _attackConfig.Attack(); //Current direction we are facing, current location
            //What the hell do we do with this
        }

        public void GetCurrentDirection(Vector2 dir)
        {
            _direction = dir;
        }
    }
}