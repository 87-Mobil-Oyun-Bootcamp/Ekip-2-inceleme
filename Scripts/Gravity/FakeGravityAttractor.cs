using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGravityAttractor : MonoBehaviour
{
    public float gravity = -10;
    public float radiusGravity = 35;

    public Color gizmosColor = Color.red;

    // Sahte Yer Çekimi
    public void Attract(Transform body)
    {
        float distance = Vector3.Distance(transform.position, body.position);
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        float gravityRadius = radiusGravity;

        if (distance < gravityRadius)
        {
            body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);
            Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
            body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
        }       
    }
    void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;
        Gizmos.DrawWireSphere(transform.position, radiusGravity);
    }

}
