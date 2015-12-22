using UnityEngine;
using System.Collections;
using System;

public class TomatoController : Prank, Prank.IPrankable
{

    public GameObject splat;

    public void Trigger()
    {
        isActive = true;
        return;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Player" && isActive)
        {
            Destroy(gameObject);

            foreach (ContactPoint contact in col.contacts)
            {
                Vector3 projPosition = contact.point + contact.normal;
                Quaternion projRotation = Quaternion.LookRotation(-1 * contact.normal, Vector3.up);
                Instantiate(splat, projPosition, projRotation);
            }

        }
    }
}