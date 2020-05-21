using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public class PlayerUnitManager : UnitManager
    {
        //Events are driven by player input
        public InputMaster _playerInputs;

        void OnEnable()
        {
            _playerInputs = new InputMaster();
            _playerInputs.Enable();
            _playerInputs.PlayerActions.Movement.performed += performedContext => base.InvokeUnitMoved(performedContext.ReadValue<Vector2>());
            _playerInputs.PlayerActions.Movement.canceled += performedContext => base.InvokeUnitMoved(Vector2.zero);
            _playerInputs.PlayerActions.Attack.performed += performedContext => base.InvokeAttackCommandGiven();
            //casted
        }

        void OnDisable()
        {
            _playerInputs.PlayerActions.Movement.performed -= performedContext => base.InvokeUnitMoved(performedContext.ReadValue<Vector2>());
            _playerInputs.PlayerActions.Attack.performed -= performedContext => base.InvokeAttackCommandGiven();
            _playerInputs.Disable();
            //casted
        }
    }
}
