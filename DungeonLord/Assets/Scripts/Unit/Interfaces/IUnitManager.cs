using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public interface IUnitEventManager
    {
        event OnUnitMove UnitMoved;
        event OnUnitAttack UnitAttacked;
        event OnUnitCast UnitCasted;
    }
}
