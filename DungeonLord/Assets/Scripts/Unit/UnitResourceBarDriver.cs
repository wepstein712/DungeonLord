// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using Unit;

// public class UnitResourceBarDriver : MonoBehaviour
// {
//     public GameObject _myUnit;
//     public Slider _resourceBar;
//     public Image _fill;
//     public IUnitResourceManager _resourceScript;
//     public StatBarConfiguration _resourceBarStyling;

//     // Called before OnEnable
//     void Awake()
//     {
//         if(_resourceBar == null)
//             _resourceBar = GetComponent<Slider>();
        
        
//     }

//     //Should be subscribed to health change event unless there is a better way of doing it I guess
//     void UpdateResourceBar()
//     {
//         //Apply gradient fill based on percentage from IHealth script
//         var currentPercentage = _resourceScript.CurrentResourcePercent;
//         Color fillColor;
//         if(_resourceBarStyling == null)
//             fillColor = Color.red;
//         else
//             fillColor = _resourceBarStyling.FillGradient.Evaluate(currentPercentage);

//         _fill.color = fillColor;
//         _resourceBar.value = currentPercentage;
//     }

//     void OnEnable()
//     {
//         if(_resourceScript != null)
//             _resourceScript.ResourceChanged += UpdateResourceBar;
//     }

//     void OnDisable()
//     {
//         if(_resourceScript != null)
//             _resourceScript.ResourceChanged -= UpdateResourceBar;
//     }
// }
