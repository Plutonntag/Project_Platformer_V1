using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_pic : MonoBehaviour
{
    private GameObject Player;
    private Transform CheckPawn;
    // Start is called before the first frame update
    void Start()
    {
        CheckPawn = GameObject.FindWithTag("Spawn").transform;
        Player = GameObject.FindWithTag("Player");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.transform.position = CheckPawn.position;
        }
    }
}
