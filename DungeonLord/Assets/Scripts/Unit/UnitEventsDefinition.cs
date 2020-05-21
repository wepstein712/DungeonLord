using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unit
{
    public delegate void OnHealthChange();
    public delegate void OnResourceChange();
    public delegate void OnUnitMove(Vector2 direction);
    public delegate void OnUnitAttack(UnitAttackConfiguration attack);
    public delegate void OnUnitCast(SpellConfiguration spell);
    public delegate void OnUnitAttemptToAttack();
}
