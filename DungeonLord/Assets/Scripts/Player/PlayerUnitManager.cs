using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public class PlayerUnitManager : UnitManager
    {
        //Events are driven by player input
        public PlayerInputManager _inputManager;

        void OnEnable()
        {
            _inputManager.UnitMoved += base.InvokeUnitMoved;
            _inputManager.UnitAttacked += base.InvokeUnitAttacked;
            //casted
        }

        void OnDisable()
        {
            _inputManager.UnitMoved -= base.InvokeUnitMoved;
            _inputManager.UnitAttacked -= base.InvokeUnitAttacked;
            //casted
        }
    }
}
