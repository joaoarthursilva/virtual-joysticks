using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Joystick[] joysticks;
    private PlayerCharacterController playerCharacterController;

    private void Awake()
    {
        joysticks = FindObjectsOfType<Joystick>();
        playerCharacterController = FindObjectOfType<PlayerCharacterController>();
        
        foreach (var joystick in joysticks)
        {
            Debug.Log(joystick);
            if (joystick.gameObject.name.StartsWith("Left"))
                playerCharacterController.leftJoystick = joystick;
            else if (joystick.gameObject.name.StartsWith("Right"))
                playerCharacterController.rightJoystick = joystick;
        }
    }
}