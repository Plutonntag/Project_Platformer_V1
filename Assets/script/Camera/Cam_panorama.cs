using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cam_panorama : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera Cam_pano;
    [SerializeField] CinemachineVirtualCamera Cam_main;
    private bool D_touch;
    IEnumerator coroutine;


    private void Start()
    {
        D_touch = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {


            if (Input.GetKey(KeyCode.E) && D_touch == false)
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
