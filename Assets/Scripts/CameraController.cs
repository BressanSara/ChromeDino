using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script che deve essere inserito all'interno della camera principale del gioco 
public class CameraController : MonoBehaviour {
    // Corrisponde al numero di giocatori
    private int numberOfPlayers;
    // Corrispondono ai riquadri di gioco di ogni giocatore (da settare a mano dalla gui di unity)
    public GameObject game1;
    public GameObject game2;
    public GameObject game3;
    public GameObject game4;

    // Corrisponde alla camera principale del gioco
    private Camera camera;

    // Use this for initialization
    void Start () {
        // Il numero di giocatori viene letto dal file salvato nel menù di gioco
        numberOfPlayers = SaveSystem.LoadPlayers().players.Length;
        // Distruzione dei riquadri di gioco in eccesso
        if(numberOfPlayers <= 4)
        {
            if(numberOfPlayers <= 3) {
                Destroy(game4);
                if (numberOfPlayers <= 2)
                {
                    Destroy(game3);
                    if(numberOfPlayers == 1)
                    {
                        Destroy(game2);
                    }
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
