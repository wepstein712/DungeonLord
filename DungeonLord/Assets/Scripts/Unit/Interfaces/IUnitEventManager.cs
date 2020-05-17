using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public interface IUnitManager
    {
        event OnUnitMove UnitMoved;
        event OnUnitAttack UnitAttacked;
    }
}
