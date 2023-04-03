using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    private bool targeted = false;

    private void Update()
    {
        if (targeted && Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<CrosshairBehavior>().Hit();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        targeted = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        targeted = false;
    }
}
