using System.Collections;
using System.Collections.Generic;
using Unit;
using UnityEngine;

public class HitboxDetector : MonoBehaviour
{
    public bool isOn = false;

    private bool _hit = false;
    private bool _hasHit = false;
    private Collider2D _otherCollider;
    private UnitAttackManager _uam;

    void Awake()
    {
        Debug.Log(">>");
        GameObject playerParent = gameObject.transform.parent.parent.gameObject;
        _uam = playerParent.GetComponent<UnitAttackManager>();
        if (_uam == null)
        {
            Debug.LogError("There should be a unit attack manager attacked to the component 2 levels higher");
        }

    }


    void Update()
    {
        //Debug.Log(gameObject.transform); 
        if (isOn && _hit && !_hasHit)
        {
            _hasHit = true;
            _uam.doDamage(_otherCollider);
        }
        else if (_hasHit && !isOn && !_hit)
        {
            _hasHit = false;
        }
        else
        {

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Unit")
        {
            _hit = true;
            _otherCollider = col;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Unit" && _hit == true)
        {
            _hit = false;
            _otherCollider = null;
        }
    }

}