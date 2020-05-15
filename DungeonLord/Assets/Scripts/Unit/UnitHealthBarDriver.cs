using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unit;

public class UnitHealthBarDriver : MonoBehaviour
{
    public GameObject _myUnit;
    public Slider _healthBar;
    public Image _fill;
    public IResource _healthScript;
    public StatBarConfiguration _healthBarStyling;

    // Called before OnEnable
    void Awake()
    {
        if(_healthBar == null)
            _healthBar = GetComponent<Slider>();
        
        if(_healthScript == null && _myUnit != null)
            _healthScript = _myUnit.GetComponent<IHealth>() as IResource;
    }

    //Should be subscribed to health change event unless there is a better way of doing it I guess
    void UpdateHealthBar()
    {
        //Apply gradient fill based on percentage from IHealth script
        var currentPercentage = _healthScript.CurrentPercentOfMax;
        Color fillColor;
        if(_healthBarStyling == null)
            fillColor = Color.red;
        else
            fillColor = _healthBarStyling.FillGradient.Evaluate(currentPercentage);

        _fill.color = fillColor;
        _healthBar.value = currentPercentage;
    }

    void OnEnable()
    {
        if(_healthScript != null)
            _healthScript.ResourceChanged += UpdateHealthBar;
    }

    void OnDisable()
    {
        if(_healthScript != null)
            _healthScript.ResourceChanged -= UpdateHealthBar;
    }
}
