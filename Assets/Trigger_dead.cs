using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_dead : MonoBehaviour
{
    [SerializeField] GameObject checker;
    [SerializeField] GameObject Player;
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
        if (collision.CompareTag("Player"))
        {
            Player.transform.position = checker.transform.position;
        }
    }
}
