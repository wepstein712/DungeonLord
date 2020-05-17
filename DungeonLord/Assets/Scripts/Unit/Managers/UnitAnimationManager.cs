using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public class UnitAnimationManager : MonoBehaviour
    {
        public Animator _animator;
        //public PlayerInputManager //This hard reference is no good, needs something like IUnitManager or some shit. Perhaps a player manager has a Unit Manager - Or a PlayerUnitManager: IUnitManager and an AiUnitManager
        // Start is called before the first frame update
        
        private IUnitManager _unitManager;

        private void OnEnable() 
        {
            
        }

        private void OnDisable()
        {

        }
    }

}