using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMagneticCube : MonoBehaviour
{
    public float DashSpeedRatio;
    public float DashDurationRatio;
    public LayerMask DashStopLayer;
    private bool _dashing;
    private float _timeStartedDash;
    private Vector3 _dashDirection = Vector3.zero;
    private float _dashDuration;
    private float _dashSpeed;
    private RaycastHit _dashHit;
    private Rigidbody _rigidBody;
    private float _dashSlowdownTimer;
    private float _dashSlowdownDuration = 0.2f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _dashSlowdownTimer = _dashSlowdownDuration;
    }
    private void FixedUpdate()
    {
        HandleDash();
    }
    private void HandleDash()
    {
        if (_dashing)
        {
            if (Time.time >= _timeStartedDash + _dashDuration || Physics.Raycast(transform.position, _dashDirection, out _dashHit, 1, DashStopLayer))
            {
                // print(Physics.Raycast(transform.position, _dashDirection, out _dashHit, 1, DashStopLayer));
                _dashing = false;
                _dashSlowdownTimer = 0;

                // _dashDirection = Vector3.zero;
                // _rigidBody.velocity = Vector3.zero;
            }
        }
        else
        {
            if (_dashSlowdownTimer < _dashSlowdownDuration)
            {
                _dashSlowdownTimer += Time.fixedDeltaTime;
                _dashDirection = Vector3.Lerp(_dashDirection, Vector3.zero, _dashSlowdownTimer / _dashSlowdownDuration);
            }
        }
    }
    public void ExecuteDash(Vector3 direction, float dashDuration, float dashSpeed)
    {
        _dashDirection = direction;
        _dashDuration = dashDuration * DashDurationRatio;
        _dashSpeed = dashSpeed * DashSpeedRatio;

        _dashDirection.y = 0;
        _rigidBody.velocity = _dashSpeed * _dashDirection;

        _dashing = true;
        _timeStartedDash = Time.time;
    }
}
