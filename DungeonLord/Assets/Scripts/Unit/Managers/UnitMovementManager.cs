using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit {
    public class UnitMovementManager : MonoBehaviour
    {
        public float MovementSpeed = 5f;
        private UnitManager _eventManager;
        private Rigidbody2D _rb;
        private bool _isMovementDisabled = false;
        private bool _isUnitDead = false;

        private void ApplyMovement(Vector2 dir)
        {
            if(!_isMovementDisabled && !_isUnitDead)
                _rb.velocity = dir.normalized * MovementSpeed;
        }

        void OnEnable()
        {
            _eventManager = GetComponent<UnitManager>();
            _rb = GetComponent<Rigidbody2D>();
            _eventManager.UnitMoved += ApplyMovement;
            _eventManager.UnitDied += () => _isUnitDead = true;
        }

        void OnDisable()
        {
            _eventManager.UnitMoved -= ApplyMovement;
            _eventManager.UnitDied -= () => _isUnitDead = true;
        }
    }
}