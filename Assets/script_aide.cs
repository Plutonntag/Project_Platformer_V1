using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class script_aide : MonoBehaviour
{

    public movetest Move_Player;
    [SerializeField] Canvas Canva_Image;
    [SerializeField] Canvas Canva_Text;
    public bool Out_in;
    public bool image_actif;
    // Start is called before the first frame update

    private void Awake()
    {
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
            Move_Player.enabled = false;
            image_actif = true;

        }
        else if (image_actif){

            Canva_Image.enabled = false;
            Move_Player.enabled = true;
            image_actif = false;


        }
    }
}
