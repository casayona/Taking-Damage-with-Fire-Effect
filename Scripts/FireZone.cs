using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZone : MonoBehaviour
{
    public int fireDamage = 10;
    public float damageInterval = 1f;
    private float nextDamageTime;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ThirdPersonController thirdPersonController = other.GetComponent<ThirdPersonController>();
            FireEffect fireEffect = other.GetComponent<FireEffect>();
            if (thirdPersonController != null && Time.time >= nextDamageTime)
            {
                thirdPersonController.TakeDamage(fireDamage);
                nextDamageTime = Time.time + damageInterval;

                if (fireEffect != null)
                {
                    fireEffect.StartFire();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FireEffect fireEffect = other.GetComponent <FireEffect>();
        if (fireEffect != null)
        {
            fireEffect.StopFire();
        }
    }
}
