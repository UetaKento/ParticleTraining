using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private Transform _muzzle;
    [SerializeField]
    private Transform _base;
    [SerializeField]
    private float _amplifier = 2.5f;
    [SerializeField]
    private GameObject _projectile;
    [SerializeField]
    private float _projectionSpeed;


    private void Update()
    {
        UpdateAngle();
    }

    private void UpdateAngle()
    {

        var yAngle = _camera.transform.rotation.eulerAngles.y - _base.rotation.eulerAngles.y;
        yAngle = yAngle * _amplifier + _base.rotation.eulerAngles.y;

        Vector3 muzzleAngle = new Vector3(
            transform.rotation.eulerAngles.x,
            yAngle,
            transform.rotation.eulerAngles.z);

        transform.rotation = Quaternion.Euler(muzzleAngle);
    }

    public void Fire()
    {
        var projectile = Instantiate(_projectile, _muzzle.position, _muzzle.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(_muzzle.transform.up * _projectionSpeed);
    }
}
