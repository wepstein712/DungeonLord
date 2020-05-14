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
            var healthScript = other.gameObject.GetComponent<IHealth>();
            if(healthScript != null)
            {
                healthScript.TakeDamage(10);
            }
        }
    }
}
