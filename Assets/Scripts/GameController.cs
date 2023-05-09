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
    [SerializeField] private Player player;
    
    private void Start()
    {
        ManageInstances();
        ControlJoysticks();
        ControlCamera();
    }

    private void ManageInstances()
    {
        ManageSetupInstances();
        ManagePlayerInstance();
    }

    private void ManagePlayerInstance()
    {
        playerCharacterController = FindObjectOfType<PlayerCharacterController>();
        playerCharacterController.maxMoveSpeed = player.maxSpeed;
        playerCharacterController.engine = player.engine;

    }

    private void ManageSetupInstances()
    {
        cam = FindObjectOfType<CameraPos>();
        joysticks = FindObjectsOfType<Joystick>();
        
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