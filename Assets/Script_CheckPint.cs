using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_CheckPint : MonoBehaviour
{
    private Transform CheckPoint;

    // Start is called before the first frame update
    void Start()
    {
        CheckPoint = GameObject.FindWithTag("Spawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CheckPoint.position = transform.position;
            Debug.Log("new point");
        }
    }
}
