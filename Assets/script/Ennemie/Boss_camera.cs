using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Boss_camera : MonoBehaviour
{
    public Pattern_Boss Boss;
    public Trigg_Boss_Attack Trigg_Boss;
    public Mov_Boss Movement_Boss;
    [SerializeField] CinemachineVirtualCamera Cam_Main;
    [SerializeField] CinemachineVirtualCamera Cam_Boss;
    [SerializeField] BoxCollider2D Box_Boss;
    // Start is called before the first frame update
    void Start()
    {
        Box_Boss.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {         
            Boss.enabled = true;
            Cam_Boss.Priority = 10;
            Cam_Main.Priority = 1;
            Box_Boss.enabled = true;
            Trigg_Boss.enabled =true;
            Movement_Boss.enabled = true;

        }   
    }
}

