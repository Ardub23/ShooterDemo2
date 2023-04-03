using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderMovement : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float maxForce = 500f;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = RandomDirection() * Random.Range(0f, maxSpeed / 4);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 force = RandomDirection() * Random.Range(maxForce / 2, maxForce);

        // If already going fast, add an opposing force
        if (Random.value < Mathf.Pow(rb.velocity.magnitude / maxSpeed, 2))
        {
            force -= 0.5f * maxForce * rb.velocity.normalized;
        }
        // If far away from viewport, tend to move closer
        Vector2 vecToCamera = (Vector2)Camera.main.transform.position - rb.position;
        if (vecToCamera.magnitude > 500f)
        {
            force += 0.3f * maxForce * vecToCamera.normalized;
        }

        // Clamp to max force
        if (force.magnitude > maxForce)
        {
            force = force.normalized * maxForce;
        }

        rb.AddForce(force * Time.deltaTime, ForceMode2D.Force);
    }

    private static Vector2 RandomDirection()
    {
        // Create a unit-length vector in a random direction
        float angle = Random.Range(0, 360f);
        Vector2 force = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        return force;
    }
}
