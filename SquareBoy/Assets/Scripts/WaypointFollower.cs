using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] _wayPoints;
    private int _currentWaypointIndex = 0;
    [SerializeField] private float _speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(this._wayPoints[this._currentWaypointIndex].transform.position, base.transform.position) < .1f)
        {
            this._currentWaypointIndex++;
            if(this._currentWaypointIndex >= this._wayPoints.Length)
            {
                this._currentWaypointIndex = 0;
            }
        }


        base.transform.position = Vector2.MoveTowards(base.transform.position, this._wayPoints[this._currentWaypointIndex].transform.position, Time.deltaTime * this._speed);
    }
}
