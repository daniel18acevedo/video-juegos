using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private void Update()
    {
        base.transform.Rotate(0, 0, 360 * this._speed * Time.deltaTime);
    }
}
