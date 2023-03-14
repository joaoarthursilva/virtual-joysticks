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
    private float horizontal;
    private float vertical;
    private Vector2 _movementSpeed;
    private Vector2 _direction;
    private Vector2 _rotation;
    private Transform transform;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        transform = gameObject.transform;
    }

    private void Update()
    {
        horizontal = leftJoystick.Horizontal;
        vertical = leftJoystick.Vertical;

        _movementSpeed = new Vector2(horizontal, vertical) * speed;

        _rb.velocity = _movementSpeed;
        _direction = rightJoystick.Direction;
    }
}