using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Script che fa ripartire il gioco va messo nel bottone "restartGame" tramite la GUI di Unity
public class RestartGame : MonoBehaviour {
     
	// Use this for initialization
	void Start () {
        // Se il bottone di restart viene cliccato fa un restart del gioco
        this.GetComponent<Button>().onClick.AddListener(Restart);
	}
	
	// Update is called once per frame
	void Update () {
        // Se viene cliccato il tasto "esc" il gioco viene chiuso
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    // Funzione di restart del gioco
    private void Restart()
    {
        // Viene caricata la scena del MainMenu facendo ripartire il gioco
        SceneManager.LoadScene("Menu");
    }
}
