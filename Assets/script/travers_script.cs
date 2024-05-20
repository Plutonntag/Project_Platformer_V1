using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class travers_script : MonoBehaviour
{
    [SerializeField] BoxCollider2D Box_plat;
    [SerializeField] Rigidbody2D rb_Player;
    [SerializeField] LayerMask player;
    [SerializeField] LayerMask hidden;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Travers_Fonction();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") || collision.CompareTag("Hidden")){
            Debug.Log("Sortie");
            Box_plat.excludeLayers = new LayerMask();
        }
    }

    private void Travers_Fonction()
    {
        //Debug.Log("Peut traverser");
        if (rb_Player.IsTouching(Box_plat) && Input.GetKey(KeyCode.S))
        {

            Debug.Log("traverse");

            Box_plat.excludeLayers = player + hidden;
            //Box_plat.excludeLayers = hidden;
            //Physics2D.IgnoreLayerCollision(6, 8);



        }

    }
}

