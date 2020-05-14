using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName="UnitConfigurations/StatBar")]
public class StatBarConfiguration : ScriptableObject
{
    public Gradient FillGradient;
    public Sprite LeftSideImage;
    public Sprite StatBarOutline;
}
