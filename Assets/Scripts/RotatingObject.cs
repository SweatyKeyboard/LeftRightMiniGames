using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    private Vector3 _axis;
    private float _speed;

    private void Start()
    {
        _axis = new Vector3(
            Random.Range(0, 360),
            Random.Range(0, 360),
            Random.Range(0, 360));

        _speed = Random.Range(0f, 10f);
    }

    private void FixedUpdate()
    {
        transform.Rotate(_axis, _speed);
    }
}
