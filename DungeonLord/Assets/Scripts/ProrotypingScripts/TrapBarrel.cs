using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unit;

public class TrapBarrel : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.gameObject.CompareTag("Unit"))
        {
            var healthScript = other.gameObject.GetComponent<IHealth>() as IResource;
            if(healthScript != null)
            {
                healthScript.SubtractAmount(10);
            }

            var manaScript = other.gameObject.GetComponent<IMana>() as IResource;
            if(manaScript != null)
            {
                manaScript.SubtractAmount(30);
            }
        }
    }
}
