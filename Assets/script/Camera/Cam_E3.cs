using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_E3 : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera Cam_Main;
    [SerializeField] CinemachineVirtualCamera Cam_enigme_3;
    private bool AlEnter;
    // Start is called before the first frame update
    void Start()
    {
        AlEnter = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && AlEnter == false)
        {
            Cam_enigme_3.Priority = 10;
            Cam_Main.Priority = 1;
            AlEnter = true;
        }
        else if (collision.CompareTag("Player") && AlEnter == true)
        {
            Cam_enigme_3.Priority = 1;
            Cam_Main.Priority = 10;
            AlEnter = false;

        }
    }
}
