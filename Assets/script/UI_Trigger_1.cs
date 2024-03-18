using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Trigger_1 : MonoBehaviour
{
    [SerializeField] Canvas canva;
    // Start is called before the first frame update
    void Start()
    {
         canva.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canva.enabled = true;
        }
    }
}
