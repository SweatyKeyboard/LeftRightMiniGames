using UnityEngine;

public class SkateMover : MonoBehaviour
{
    [SerializeField] private Transform _deck;
    [SerializeField] private Transform[] _wheels;


    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private float _rotationValue = 20f;
    private float _zDistanceromCam;

    private Rigidbody _rigidbody;

    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _zDistanceromCam = Camera.main.transform.position.z - _deck.transform.position.z;
    }
    private void Update()
    {
        float direction = 0;
        if (InputSystem.GetClick() == InputSystem.InputType.Left)
        {
            direction = -1;
        }
        else if (InputSystem.GetClick() == InputSystem.InputType.Right)
        {
            direction = 1;
        }
        else if (InputSystem.GetClick() == InputSystem.InputType.Both)
        {
            Jump();
        }



        transform.Translate(new Vector3(
                       direction * (_speed + Time.timeSinceLevelLoad / 500f),
                       0,
                       0), Space.World);

        transform.Rotate(new Vector3(0, 1, 0), direction * (_speed * _rotationValue / 5f + Time.timeSinceLevelLoad / 500f));
        _deck.transform.Rotate(new Vector3(0, 1, 0), direction * (_speed * _rotationValue / 2.5f + Time.timeSinceLevelLoad / 500f));

        if (Mathf.Abs(transform.rotation.y) > 0.01 && _isGrounded)
        {
            transform.Rotate(
                new Vector3(0, -1, 0),
                Mathf.Sign(transform.rotation.y) * _speed * _rotationValue / 5 + Time.timeSinceLevelLoad / 500f);
        }

        if (Mathf.Abs(transform.rotation.x) > 0.01 && !_isGrounded)
        {
            transform.Rotate(
                new Vector3(-1, 0, 0),
                Mathf.Sign(transform.rotation.x) * _speed * _rotationValue / 15 + Time.timeSinceLevelLoad / 500f);
        }

    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rigidbody.AddForce(new Vector3(0, 1, 0) * _jumpForce, ForceMode.Impulse);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}
