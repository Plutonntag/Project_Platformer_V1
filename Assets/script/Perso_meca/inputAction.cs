using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputAction : MonoBehaviour
{
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("Saut");
        }
        
    }

    public void Movement(InputAction.CallbackContext context)
    {
        Debug.Log("Bouge");
    }
}

