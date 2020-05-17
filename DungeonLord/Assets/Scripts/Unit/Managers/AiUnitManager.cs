using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public class AiUnitManager : UnitManager
    {
        // Start is called before the first frame update
        //Some kind of AI that looks at shit and makes decisions on when to activate events

        //On enable, or awake, whatever works for the AI - used OnEnable/Disable for playerInput since some setup happens in Awake for the PlayerInputManager
        void OnEnable()
        {
            // _inputManager.UnitMoved += base.InvokeUnitMoved;
            // _inputManager.UnitAttacked += base.InvokeUnitAttacked;
        }

        void OnDisable()
        {
            // _inputManager.UnitMoved -= base.InvokeUnitMoved;
            // _inputManager.UnitAttacked -= base.InvokeUnitAttacked;
        }
    }
}
