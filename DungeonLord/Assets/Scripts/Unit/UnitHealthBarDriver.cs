using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHealthBarDriver : MonoBehaviour
{
    public GameObject _myUnit;
    public Slider _healthBar;
    public IHealth _healthScript;
    public HealthBarConfiguration _healthBarStyling;

    // Start is called before the first frame update
    void Awake()
    {
        if(_healthBar == null)
            _healthBar = GetComponent<Slider>();
        
        if(_healthScript == null && _myUnit != null)
            _healthScript = _myUnit.GetComponent<IHealth>();

        //Subscribe to some event by reference
        //ToDo
    }

    //Should be subscribed to health change event unless there is a better way of doing it I guess
    void UpdateHealthBar()
    {
        //Apply gradient fill based on percentage from IHealth script
        var currentPrecentage = _healthScript.CurrentHealthPercent;

        //if(_healthBarStyling == null)
            
    }
}
