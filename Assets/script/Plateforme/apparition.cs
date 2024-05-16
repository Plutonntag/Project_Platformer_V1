using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/*      Code permettant de faire réapparaitre la plateforme et de l'envoyer en avant
 * 
 */




public class apparition : MonoBehaviour
{
    public disparition script;
    public movetest chara;
    [SerializeField] Rigidbody2D plat_rb;
    [SerializeField] GameObject Player;
    [SerializeField] SpriteRenderer image;
    [SerializeField] BoxCollider2D touch;
    [SerializeField] BoxCollider2D touch_trigger;
    [SerializeField] int powar_plat = 5;
    [SerializeField] SpriteRenderer SP_Player;
    private float XPlayer;
    private float YPlayer;
    private bool TimeOff;
    private bool TimeOn;
    IEnumerator coroutine;

    void Update()
    {
        position();
        ejection();  
    }



    private void ejection() // Fonction permettant de faire réapparaitre et d'envoyer
    {
        if (chara.plat_absorb == true)
        {
            if ((script.absorbed == true) && (TimeOff == false && TimeOn == false))
            {
                TimeOn = true;
                StartCoroutine(Thewait()); // Coroutine pour le cooldown de la réapparition

            }
            else if ((Input.GetKey(KeyCode.F)) && (TimeOff == true))// si activer la touche et le cooldown terminé, le code ce lance
            {

                StartCoroutine(TheFly());

            }
            else if ((Input.GetKey(KeyCode.C)) && (TimeOff == true))
            {
                StartCoroutine(ThePlat());
            }
        }
    }

    private void position()
    {
        XPlayer = Player.transform.position.x;
        YPlayer = Player.transform.position.y;
        
    }


    IEnumerator Thewait() // Coroutine du cooldown
    {
        yield return new WaitForSeconds(1);
        TimeOff = true;
        Debug.Log(" cooldown");
        
    }

    IEnumerator TheFly() // Coroutine de l'apparaition et de l'envoie 
    {

        Debug.Log(" rejet");
        if (SP_Player.flipX == true)
        {
            transform.position = new Vector3(XPlayer - 2, YPlayer, 0f);
        }
        else
        {
            transform.position = new Vector3(XPlayer + 2, YPlayer, 0f);
        }
                                                                                    // met la plateforme au même niveau que le personnage
        TimeOn = false;
        TimeOff = false;
        script.absorbed = false;
        image.enabled = true; // apparition de la plateforme
        float originalGravity = plat_rb.gravityScale; // mouvement de la plateforme
        plat_rb.gravityScale = 0f;
 
        plat_rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        plat_rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        if (SP_Player.flipX == true)
        {
            plat_rb.AddForce(Vector2.left * 120 * powar_plat);
        }
        else
        {
            plat_rb.AddForce(Vector2.right * 120 * powar_plat);
        }
        touch.enabled = true;
        yield return new WaitForSeconds(0.12f) ; // Temps de la distance parcouru par la plateforme
        //touch.enabled = true;
        touch_trigger.enabled = true;
        plat_rb.gravityScale = originalGravity;
        plat_rb.constraints = RigidbodyConstraints2D.FreezeAll;
        chara.plat_absorb = false;

    }

    IEnumerator ThePlat()
    {
        Debug.Log(" plateforme");
        transform.position = new Vector3(XPlayer, YPlayer, 0f);// met la plateforme au même niveau que le personnage
        TimeOn = false;
        TimeOff = false;
        script.absorbed = false;
        image.enabled = true; // apparition de la plateforme
        float originalGravity = plat_rb.gravityScale; // mouvement de la plateforme
        plat_rb.gravityScale = 0f;
        plat_rb.constraints = RigidbodyConstraints2D.None;
        plat_rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        plat_rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        plat_rb.AddForce(Vector2.down * 120 * powar_plat);// Place la plateforme en dessous du perso

        yield return new WaitForSeconds(0.1f); // Temps de la distance parcouru par la plateforme
        touch.enabled = true;
        touch_trigger.enabled = true;
        plat_rb.gravityScale = originalGravity;
        plat_rb.constraints = RigidbodyConstraints2D.FreezeAll;
        chara.plat_absorb = false;
    }


}
