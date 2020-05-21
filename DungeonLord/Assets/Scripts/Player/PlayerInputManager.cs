using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public class PlayerInputManager : MonoBehaviour
    {
        private InputMaster _playerInput;
        //private SpellManager _spellmanager;   

        void Awake()
        {
            _playerInput = new InputMaster();
            _playerInput.Enable();
            SubscribeToInputEvents();
        }

        void SubscribeToInputEvents()
        {
            _playerInput.PlayerActions.Movement.performed += performedContext => CheckUnitMoved(performedContext.ReadValue<Vector2>());
            //_playerInput.PlayerActions.Attack.performed += performedContext => InvokeUnitAttacked();
           // _playerInput.PlayerActions.Cast1.performed += performedContext => InvokedUnitAttacked();
        }

        void CheckUnitMoved(Vector2 check)
        {
            Debug.Log("made it into this shit bare minumum");
        }

        #region InvokeEvents

        #endregion
    }
}
