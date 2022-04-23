using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{

    [SerializeField] private Vector3 startingRotation;

    [SerializeField] private float speed = 150f;

    void Start()
    {
        transform.eulerAngles = startingRotation;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
