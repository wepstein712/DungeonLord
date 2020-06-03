using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public class PlayerUnitManager : UnitManager
    {
        //Events are driven by player input
        public InputMaster _playerInputs;
        public GameObject _lHB, _rHB, _uHB, _dHB;
        private HitboxDetector lDetect, rDetect, uDetect, dDetect;
        public void Awake()
        {
            lDetect = _lHB.GetComponent<HitboxDetector>();
            rDetect = _rHB.GetComponent<HitboxDetector>();
            uDetect = _uHB.GetComponent<HitboxDetector>();
            dDetect = _dHB.GetComponent<HitboxDetector>();
        }

        public override void attackStart(string direction)
        {
            UnityEngine.Debug.Log("ATTACK START   " + direction);

            if (System.String.Compare(direction, "up") == 0)
            {
                uDetect.isOn = true;

            }
            else if (System.String.Compare(direction, "down") == 0)
            {
                dDetect.isOn = true;
            }
            else if (System.String.Compare(direction, "left") == 0)
            {
                lDetect.isOn = true;
            }
            else if (System.String.Compare(direction, "right") == 0)
            {
                rDetect.isOn = true;
            }


        }

        public override void attackEnd()
        {
            rDetect.isOn = false;
            lDetect.isOn = false;
            uDetect.isOn = false;
            dDetect.isOn = false;

        }
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
