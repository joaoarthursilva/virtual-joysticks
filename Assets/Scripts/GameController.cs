using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Joystick[] joysticks;
    private PlayerCharacterController playerCharacterController;
    private CameraPos cam;

    private void Awake()
    {
        ManageInstances();
        ControlJoysticks();
        ControlCamera();
    }

    private void ManageInstances()
    {
        cam = FindObjectOfType<CameraPos>();
        joysticks = FindObjectsOfType<Joystick>();
        playerCharacterController = FindObjectOfType<PlayerCharacterController>();
    }

    private void ControlJoysticks()
    {
        foreach (var joystick in joysticks)
        {
            if (joystick.gameObject.name.StartsWith("Left"))
                playerCharacterController.leftJoystick = joystick;
            else if (joystick.gameObject.name.StartsWith("Right"))
                playerCharacterController.rightJoystick = joystick;
        }
    }

    private void ControlCamera()
    {
        cam.player = playerCharacterController.transform;
    }
}