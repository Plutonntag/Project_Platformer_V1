using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] PlayableDirector Cinematique;
    // Start is called before the first frame update

    public void ButtonPlay()
    {
        Cinematique.Play();
         // permet de changer de sc�ne

    }
    public void ButtonQuit() {

        Application.Quit();
    
    }

}