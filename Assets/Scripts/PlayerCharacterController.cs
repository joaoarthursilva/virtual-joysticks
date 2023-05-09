using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public Joystick rightJoystick { get; set; }
    public Joystick leftJoystick { get; set; }
    public float speed { get; set; }
    private Rigidbody2D _rb;
    private float vertical;
    public float maxMoveSpeed { get; set; }
    public Engine engine;
    private Vector2 _direction;
    private Vector2 _rotation;
    private Transform _transform;

    [SerializeField] private float turnSpeed = 3;

    // [SerializeField] private float linearDrag = 10f;
    [SerializeField] private GameObject leftEngine;
    [SerializeField] private GameObject rightEngine;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _transform = gameObject.transform;
    }

    private void Update()
    {
        if (rightJoystick.Horizontal > 0)
        {
            rightEngine.SetActive(true);
            leftEngine.SetActive(false);
        }
        else if (rightJoystick.Horizontal < 0)
        {
            rightEngine.SetActive(false);
            leftEngine.SetActive(true);
        }
        else
        {
            rightEngine.SetActive(false);
            leftEngine.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        // ApplyLinearDrag();
    }

    private void MovePlayer()
    {
        vertical = leftJoystick.Vertical;
        if (vertical != 0)
        {
            _rb.AddForce((vertical > 0 ? _transform.up : -_transform.up) * speed);
        }

        _transform.rotation *= Quaternion.AngleAxis(rightJoystick.Horizontal * turnSpeed, Vector3.forward);

        if (Mathf.Abs(_rb.velocity.x) > maxMoveSpeed)
            _rb.velocity = new Vector2(Mathf.Sign(_rb.velocity.x) * maxMoveSpeed, 0);
    }


    // private void ApplyLinearDrag()
    // {
    //     if (Mathf.Abs(horizontal) < 0.4f || Mathf.Abs(vertical) < 0.4f) //|| changingDirection)
    //     {
    //         _rb.drag = linearDrag;
    //     }
    //     else
    //     {
    //         _rb.drag = 0f;
    //     }
    // }
}