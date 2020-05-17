using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public class PlayerInputManager : MonoBehaviour
    {
        public event OnUnitMove UnitMoved;
        public event OnUnitAttack UnitAttacked;
        public event OnUnitCast UnitCasted;

        private InputMaster _playerInput;
        //private SpellManager _spellmanager;   

        void Awake()
        {
            _playerInput = new InputMaster();
            SubscribeToInputEvents();
        }

        void SubscribeToInputEvents()
        {
            _playerInput.PlayerActions.Movement.performed += performedContext => InvokeUnitMoved(performedContext.ReadValue<Vector2>());
            _playerInput.PlayerActions.Attack.performed += performedContext => InvokedUnitAttacked();
           // _playerInput.PlayerActions.Cast1.performed += performedContext => InvokedUnitAttacked();
        }

        #region InvokeEvents
        void InvokeUnitMoved(Vector2 input)
        {
            UnitMoved?.Invoke(input);
        }

        void InvokedUnitAttacked()
        {
            UnitAttacked?.Invoke();
        }

        void InvokedUnitCasted(SpellConfiguration spell)
        {
            UnitCasted?.Invoke(spell);
        }
        #endregion
    }
}
