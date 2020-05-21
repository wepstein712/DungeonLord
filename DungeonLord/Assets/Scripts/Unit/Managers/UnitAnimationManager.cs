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

        public void TriggerAttackAnimation(UnitAttackConfiguration placeholder)
        {
            _animator.SetTrigger("Attack");
        }

        private void SetMovementDirection(Vector2 inputDir)
        {
            if(inputDir != Vector2.zero)
            {
                _animator.SetFloat("Horizontal", inputDir.x);
                _animator.SetFloat("Vertical", inputDir.y);
            }
        }

        private void OnEnable() 
        {
            _unitManager = GetComponent<UnitManager>();
            _animator = GetComponent<Animator>();
            _unitManager.UnitMoved += SetMovementDirection;
            _unitManager.UnitAttacked += TriggerAttackAnimation;
        }

        void OnDisable()
        {
            _unitManager.UnitMoved -= SetMovementDirection;
            _unitManager.UnitAttacked -= TriggerAttackAnimation;
        }
    }

}