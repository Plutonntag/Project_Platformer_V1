using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class script_aide : MonoBehaviour
{

    private Rigidbody2D rb_player;
    [SerializeField] Canvas Canva_Image;
    [SerializeField] Canvas Canva_Text;
    public bool Out_in;
    public bool image_actif;
    // Start is called before the first frame update

    private void Awake()
    {
        rb_player = GameObject.Find("character").GetComponent<Rigidbody2D>();
        Canva_Image.enabled = false;
        Out_in = false;
        Canva_Text.enabled = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Canva_Text.enabled = true;
            Out_in = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Canva_Text.enabled = false;
            Out_in = false;

        }
    }



    public void Out ( InputAction.CallbackContext context){
        if (Out_in && !image_actif)
        {

            Canva_Image.enabled = true;
            image_actif = true;;
            rb_player.constraints = RigidbodyConstraints2D.FreezeAll;

        }
        else if (image_actif){

            Canva_Image.enabled = false;
            image_actif = false;
            rb_player.constraints = RigidbodyConstraints2D.None;
            rb_player.constraints = RigidbodyConstraints2D.FreezeRotation;



        }
    }
}
