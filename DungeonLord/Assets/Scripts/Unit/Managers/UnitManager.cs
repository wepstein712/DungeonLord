using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public abstract class UnitManager : MonoBehaviour, IUnitEventManager
    {
        //Events are driven by player input
        public UnitAnimationManager _animationManager;
        
        public event OnUnitMove UnitMoved;
        public event OnUnitAttack UnitAttacked;
        public event OnUnitCast UnitCasted; //Implement this

        protected void InvokeUnitMoved(Vector2 dir)
        {
            UnitMoved?.Invoke(dir);
        }

        protected void InvokeUnitAttacked()
        {
            UnitAttacked?.Invoke();
        }

        protected void InvokeUnitCasted(SpellConfiguration spell)
        {
            UnitCasted?.Invoke(spell);
        }
    }
}