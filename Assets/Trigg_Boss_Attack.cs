using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Trigg_Boss_Attack : MonoBehaviour
{
    public Mov_Boss hit;
    public Trigg_Boss_Attack trigg_boss;
    public Pattern_Boss Pattern;
    [SerializeField] BoxCollider2D Box_Boss;
    [SerializeField] CinemachineVirtualCamera Main_cam;
    [SerializeField] CinemachineVirtualCamera Boss_cam;
    [SerializeField] Animator boss_animation;
    public bool istrigg;
    IEnumerator coroutine;
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
            Debug.Log("Voit");
            istrigg = true;
            hit.canHit = true;
            boss_animation.SetBool("attack", true);
            boss_animation.SetBool("marche", false);
            boss_animation.SetBool("idle", false);
            boss_animation.SetBool("attack_true", true);
            StartCoroutine(Hit());



        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("voit plus");
            istrigg = false;
            boss_animation.SetBool("attack", true);
            boss_animation.SetBool("marche", true);
            boss_animation.SetBool("idle", false);
            boss_animation.SetBool("attack_true", false) ;
            StopAllCoroutines();
            StartCoroutine(TheWait());

        }
    }


    IEnumerator Hit()
    {
        while (hit.canHit)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("Hit");
            Death_Effect.instance.Death_Player();
            Pattern.fight = false;
            Box_Boss.enabled = false;
            Main_cam.Priority = 10;
            Boss_cam.Priority = 1;
            Pattern.number_attack = 0;
            Pattern.number_boo = 0;


        }

    }

    IEnumerator TheWait()
    {
        yield return new WaitForSeconds(2);
        hit.canHit = false;
    }


}
