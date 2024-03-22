using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_dead_Plat : MonoBehaviour
{
    [SerializeField] GameObject checker;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject checker_plat;
    [SerializeField] GameObject Plat;
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
            Plat.transform.position = checker_plat.transform.position;
        }
    }
}
