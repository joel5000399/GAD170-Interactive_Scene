using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that when used while held acts as a physics based projectile instantiator
/// </summary>
public class NerfGunItem : InteractiveItem
{
    public GameObject nerfDartPrefab;
    public Transform nerfDartSpawnLocation;
    public float fireRate = 1;
    public float launchForce = 10;
    protected float fireRateCounter;

    protected void Update()
    {
        fireRateCounter += Time.deltaTime;
    }

    public override void OnUse()
    {
        base.OnUse();

        if (isHeld)
        {
            if (fireRateCounter > fireRate)
            {
                fireRateCounter = 0;
                FireNow();
            }
        }
    }
        
    public void FireNow()
    {
        GameObject NewDart = Instantiate(nerfDartPrefab, nerfDartSpawnLocation.position, nerfDartSpawnLocation.rotation);
        Rigidbody NewDartRB = NewDart.GetComponent<Rigidbody>();

        if (NewDartRB != null)
        {
            NewDartRB.AddRelativeForce(Mathf.Pow(launchForce, 2) * Vector3.forward);            
        }
    }
}
