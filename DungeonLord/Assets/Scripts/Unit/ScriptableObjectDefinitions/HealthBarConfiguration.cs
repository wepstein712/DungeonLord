using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName="UnitConfigurations/HealthBar")]
public class HealthBarConfiguration : ScriptableObject
{
    public Gradient HealthGradient;
    public Image Fill;
}
