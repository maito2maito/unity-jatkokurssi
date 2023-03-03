using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float timeUntilExplode = 5f;
    public float radius = 5f;
    public float force = 500f;
    public float upwardModifier = 100f;

    private void Start()
    {
        Invoke("Explode", timeUntilExplode);
    }

    void Explode()
    {
        Collider[] cols = Physics.OverlapSphere(this.transform.position, radius);

        foreach (Collider collider in cols)
        {
            if (collider.GetComponent<Rigidbody>())
            {
                collider.GetComponent<Rigidbody>().AddExplosionForce(force, this.transform.position, radius, upwardModifier);
            }
        }

        Destroy(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
