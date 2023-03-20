using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForward : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _speed;

    private Vector3 _camDistance;

    private void Start()
    {
        _camDistance = _player.position - _camera.position;
    }

    private void Update()
    {
        _player.transform.Translate(Vector3.forward * _speed, Space.World);

        _camera.transform.Translate(new Vector3(
           _player.position.x - _camera.position.x - _camDistance.x,
            _player.position.y - _camera.position.y - _camDistance.y,
            _player.position.z - _camera.position.z - _camDistance.z),
            Space.World);
    }
}
