using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cam_panorama : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera Cam_pano;
    [SerializeField] CinemachineVirtualCamera Cam_main;
    private bool D_touch;
    private CapsuleCollider2D rb_player;
    private BoxCollider2D bc;
    IEnumerator coroutine;


    private void Start()
    {
        rb_player = GameObject.Find("character").GetComponent<CapsuleCollider2D>();
        bc = GetComponent<BoxCollider2D>();
        D_touch = false;
    }
    public void Cam_action(InputAction.CallbackContext context)
    {
        
        if (rb_player.IsTouching(bc))
        {

            if (D_touch == false)
            {
                D_touch = true;
                StartCoroutine(Time_Cam());
            }
        }
    }

    IEnumerator Time_Cam()
    {

        Cam_pano.Priority = 10;
        Cam_main.Priority = 1;
        yield return new WaitForSeconds(1.5f);
        Cam_main.Priority = 10;
        Cam_pano.Priority = 1;
        D_touch = false;
    }
}
