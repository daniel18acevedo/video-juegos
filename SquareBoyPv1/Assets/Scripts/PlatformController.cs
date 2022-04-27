using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Transform transformA;

    [SerializeField] private Transform transformB;

    private Vector3 currentTarget;

    void Start()
    {
        transform.position = transformA.position;
    }

    void FixedUpdate()
    {
        var step = speed * Time.deltaTime;

        if (transform.position == transformA.position)
        {
            currentTarget = transformB.position;
        }
        if (transform.position == transformB.position)
        {
            currentTarget = transformA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);
    }
}
