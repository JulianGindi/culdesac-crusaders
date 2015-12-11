using UnityEngine;
using System.Collections;

public class TomatoController : MonoBehaviour
{

    public GameObject splat;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Player")
        {
            Destroy(gameObject);

            foreach (ContactPoint contact in col.contacts)
            {
                Vector3 projPosition = contact.point + contact.normal;
                Quaternion projRotation = Quaternion.LookRotation(-1 * contact.normal, Vector3.up);
                GameObject thrownProjectile = Instantiate(splat, projPosition, projRotation) as GameObject;
            }

        }
    }
}