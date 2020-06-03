using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public abstract class UnitManager : MonoBehaviour, IUnitEventManager
    {
        //Events are driven by player input
        // public UnitAnimationManager _animationManager;
        
        public event OnUnitMove UnitMoved;
        public event OnUnitAttack UnitAttacked;
        public event OnUnitAttemptToAttack AttackCommandGiven;
        public event OnUnitDie UnitDied;
        public event OnUnitCast UnitCasted; //Implement this

        public void InvokeUnitMoved(Vector2 dir)
        {
            UnitMoved?.Invoke(dir);
        }

        public void InvokeAttackCommandGiven()
        {
            AttackCommandGiven?.Invoke();
        }

        public void InvokeUnitAttacked(UnitAttackConfiguration attack)
        {
            UnitAttacked?.Invoke(attack);
        }

        public void InvokeUnitDied()
        {
            UnitDied?.Invoke();
        }

        public void InvokeUnitCasted(SpellConfiguration spell)
        {
            UnitCasted?.Invoke(spell);
        }

        public void DestroyThisUnit()
        {
            Destroy(this.gameObject);
        }

        public virtual void attackStart(string direction)
        {
            UnityEngine.Debug.Log("THIS SHOULD NOT BE CALLED :: attackStart UnitManager");
        }

        public virtual void attackEnd()
        {
            UnityEngine.Debug.Log("THIS SHOULD NOT BE CALLED :: attackEnd UnitManager");

        }
    }
}