using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [Header("For movement")]
    [SerializeField] private GameObject[] _wayPoints;
    [SerializeField] private float _speed = 2f;
    private int _currentWaypointIndex = 0;
    protected bool _changeDirection = false;

    protected virtual void Start() { }

    protected virtual void Update()
    {
        this.Move();
    }

    protected virtual void Move()
    {
        if (Vector2.Distance(this._wayPoints[this._currentWaypointIndex].transform.position, base.transform.position) < .1f)
        {
            this._currentWaypointIndex++;
            if (this._currentWaypointIndex >= this._wayPoints.Length)
            {
                this._currentWaypointIndex = 0;
            }
            this._changeDirection = true;
        }

        base.transform.position = Vector2.MoveTowards(base.transform.position, this._wayPoints[this._currentWaypointIndex].transform.position, Time.deltaTime * this._speed);
    }
}
