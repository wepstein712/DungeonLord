using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public class UnitAnimationManager : MonoBehaviour
    {
        [Header("References")]
        public Animator _animator;
        
        private IUnitManager _unitManager;

        public void TriggerAttackAnimation()
        {
            _animator.SetTrigger("Attack");
        }

        public void SetMovementDirection(Vector2 inputDir)
        {
            if(inputDir != Vector2.zero)
            {
                _animator.SetFloat("Horizontal", inputDir.x);
                _animator.SetFloat("Vertical", inputDir.y);
            }
        }

        private void OnEnable() 
        {
            _animator = GetComponent<Animator>();
        }
    }

}