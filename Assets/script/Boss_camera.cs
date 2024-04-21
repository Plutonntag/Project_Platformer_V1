using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Boss_camera : MonoBehaviour
{
    public Pattern_Boss Boss;
    [SerializeField] CinemachineVirtualCamera Cam_Main;
    [SerializeField] CinemachineVirtualCamera Cam_Boss;
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
        Boss.enabled = true;
        Cam_Boss.Priority = 10;
        Cam_Main.Priority = 1;
    }
}

