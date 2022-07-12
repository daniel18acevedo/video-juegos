using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    [Header("For movement")]
    [SerializeField] private GameObject _center;
    [SerializeField] private float _speed = 100f;
    [SerializeField] private float _yLimitation = 2f;
    [SerializeField] private float _xLimitation = 2f;

    private float _radius;
    private Vector2 _rightWayPoint;
    private Vector2 _leftWayPoint;

    private void Start()
    {
        var centerPosition = this._center.transform.position;

        this._radius = Vector2.Distance(centerPosition, base.transform.position);
        this._rightWayPoint = new Vector2(centerPosition.x + this._xLimitation, centerPosition.y - this._yLimitation);
        this._leftWayPoint = new Vector2(centerPosition.x - this._xLimitation, centerPosition.y - this._yLimitation);
    }


    // Update is called once per frame
    void Update()
    {
        base.transform.RotateAround(this._center.transform.position, new Vector3(0, 0, this._radius), this._speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        var centerPosition = this._center.transform.position;

        Gizmos.DrawLine(centerPosition, new Vector3(centerPosition.x - this._xLimitation, centerPosition.y - this._yLimitation, centerPosition.z));
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(centerPosition, new Vector3(centerPosition.x + this._xLimitation, centerPosition.y - this._yLimitation, centerPosition.z));
        Gizmos.color = Color.yellow;
    }
}
