using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Passage_ouvert : MonoBehaviour
{

    [SerializeField] GameObject Boule_3;
    [SerializeField] CinemachineVirtualCamera Cam_Perso;
    [SerializeField] GameObject Porte;
    [SerializeField] GameObject Personnage;
    private bool One;
    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        One = true;
    }

    // Update is called once per frame
    void Update()
    {


         if( Boule_3.activeSelf == false && One == true) {

            One = false;
            StartCoroutine(Porte_baisse());
        
         }
    }

    IEnumerator Porte_baisse()
    {
        Cam_Perso.Priority = 11;
        Cam_Perso.Follow = Porte.transform;
        yield return new WaitForSeconds(2);
        Cam_Perso.Priority = 10;
        Cam_Perso.Follow = Personnage.transform;
        Porte.SetActive(false);

    }
}
