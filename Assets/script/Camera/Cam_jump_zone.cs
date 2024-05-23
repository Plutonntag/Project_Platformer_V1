using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_jump_zone : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera Cam_Main;
    [SerializeField] CinemachineVirtualCamera Cam_jump;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Cam_Main.Priority == 10)
        {
            Cam_jump.Priority = 10;
            Cam_Main.Priority = 1;
        }
        else if (collision.CompareTag("Player") && Cam_jump.Priority == 10)
        {
            Cam_jump.Priority = 1;
            Cam_Main.Priority = 10;

        }
    }
}