using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredWaypointFollower : MonoBehaviour
{
    [Header("For movement")]
    [SerializeField] private GameObject _finishWayPoint;
    [SerializeField] private float _speed = 2f;

    private bool _isTriggered;

    private void Update()
    {
        if (this._isTriggered)
        {
            if (Vector2.Distance(this._finishWayPoint.transform.position, base.transform.position) < .1f)
            {
                this._isTriggered = false;
            }

            base.transform.position = Vector2.MoveTowards(base.transform.position, this._finishWayPoint.transform.position, Time.deltaTime * this._speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            this._isTriggered = true;
        }
    }
}
