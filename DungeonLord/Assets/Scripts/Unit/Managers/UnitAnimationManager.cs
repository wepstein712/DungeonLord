using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public class UnitAnimationManager : MonoBehaviour
    {
        [Header("References")]
        public Animator _animator;
        
        private UnitManager _unitManager;

        private bool _unitIsDead = false;

        public void TriggerAttackAnimation(UnitAttackConfiguration placeholder)
        {
            if(!_unitIsDead)
                _animator.SetTrigger("Attack");
        }

        private void SetMovementDirection(Vector2 inputDir)
        {
            if(inputDir != Vector2.zero && !_unitIsDead)
            {
                _animator.SetFloat("Horizontal", inputDir.x);
                _animator.SetFloat("Vertical", inputDir.y);
                _animator.SetFloat("MoveSpeed", 1);
            }
            else
            {
                _animator.SetFloat("MoveSpeed", 0);
            }
        }

        private void TriggerUnitDied()
        {
            _animator.SetTrigger("Die");
            _unitIsDead = true;
        }

        private void OnEnable() 
        {
            _unitManager = GetComponent<UnitManager>();
            _animator = GetComponent<Animator>();
            _unitManager.UnitMoved += SetMovementDirection;
            _unitManager.UnitAttacked += TriggerAttackAnimation;
            _unitManager.UnitDied += TriggerUnitDied;
        }

        void OnDisable()
        {
            _unitManager.UnitMoved -= SetMovementDirection;
            _unitManager.UnitAttacked -= TriggerAttackAnimation;
            _unitManager.UnitDied -= TriggerUnitDied;
        }

        public void startAttackFrame(string dir)
        {
            _unitManager.attackStart(dir);
        }
        public void endAttackFrame()
        {
            _unitManager.attackEnd();
        }

    }

}