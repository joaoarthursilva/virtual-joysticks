using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCharacterController : MonoBehaviour
{
    public Joystick rightJoystick;
    public Joystick leftJoystick;
    [SerializeField] private float speed;
    private Rigidbody2D _rb;
    private float vertical;
    [SerializeField] private float maxMoveSpeed = 4f;
    private Vector2 _direction;
    private Vector2 _rotation;
    private Transform transform;

    [SerializeField] private float turnSpeed = 3;

    // [SerializeField] private float linearDrag = 10f;
    [SerializeField] private GameObject leftEngine;
    [SerializeField] private GameObject rightEngine;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        transform = gameObject.transform;
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
            _rb.AddForce((vertical > 0 ? transform.up : -transform.up) * speed);
        }

        transform.rotation *= Quaternion.AngleAxis(rightJoystick.Horizontal * turnSpeed, Vector3.forward);

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