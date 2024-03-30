using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide_bush : MonoBehaviour
{
    [SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Player.layer = LayerMask.NameToLayer("Hidden");
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hidden") || (collision.CompareTag("Player")))
        {
            Player.layer = LayerMask.NameToLayer("Player");

        }
    }
}
