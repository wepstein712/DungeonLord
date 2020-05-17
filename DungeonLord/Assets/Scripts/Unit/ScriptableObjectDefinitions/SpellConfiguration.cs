using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Spells/SpellConfiguration")]
public class SpellConfiguration : ScriptableObject
{
    public string Name = "";
    public float Cooldown = 5f;
    public float CastTime = 1f;
    public float ManaCost = 25f;
    public Animation CastAnimation;
    public GameObject SpellToSpawn;
}