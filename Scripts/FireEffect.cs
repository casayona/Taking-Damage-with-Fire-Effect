using UnityEngine;

public class FireEffect: MonoBehaviour
{
    public GameObject fireEffectPrefab; 
    private GameObject activeFireEffect; 

    public void StartFire()
    {
        if (activeFireEffect == null)
        {
            
            activeFireEffect = Instantiate(fireEffectPrefab, transform.position, Quaternion.identity, transform);
        }
    }

    public void StopFire()
    {
        if (activeFireEffect != null)
        {
            Destroy(activeFireEffect,2);
        }
    }
}
