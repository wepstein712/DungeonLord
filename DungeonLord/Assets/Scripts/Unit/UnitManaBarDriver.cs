using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unit;

public class UnitManaBarDriver : MonoBehaviour
{
    public GameObject _myUnit;
    public Slider _manaBar;
    public Image _fill;
    public IResource _manaScript;
    public StatBarConfiguration _manaBarStyling;

    // Called before OnEnable
    void Awake()
    {
        if(_manaBar == null)
            _manaBar = GetComponent<Slider>();
        
        if(_manaScript == null && _myUnit != null)
            _manaScript = _myUnit.GetComponent<IMana>() as IResource;
    }

    //Should be subscribed to health change event unless there is a better way of doing it I guess
    void UpdateHealthBar()
    {
        //Apply gradient fill based on percentage from IHealth script
        var currentPercentage = _manaScript.CurrentPercentOfMax;
        Color fillColor;
        if(_manaBarStyling == null)
            fillColor = Color.red;
        else
            fillColor = _manaBarStyling.FillGradient.Evaluate(currentPercentage);

        _fill.color = fillColor;
        _manaBar.value = currentPercentage;
    }

    void OnEnable()
    {
        if(_manaScript != null)
            _manaScript.ResourceChanged += UpdateHealthBar;
    }

    void OnDisable()
    {
        if(_manaScript != null)
            _manaScript.ResourceChanged -= UpdateHealthBar;
    }
}
