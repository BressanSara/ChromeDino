using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script che si occupa di gestire le scritte durante il gioco 
public class InfoController : MonoBehaviour {
    // Array di giocatori
    private Characters players;
    // Numero di giocatori
    private int playersNum;

    // Oggetti Text da modificare (devono essere assegnati dalla GUI di Unity)
    public Text name1;
    public Text name2;
    public Text name3;
    public Text name4;

    // Use this for initialization
    void Start () {
        // Loading dei giocatori
        players = SaveSystem.LoadPlayers();
        // In base alla grandezza dell'array di giocatori viene assegnato il numero di giocatori attuali
        playersNum = players.players.Length;
        // Se il c'è un giocatore o più
        if(playersNum >= 1)
        {
            // Viene stampato il nome del primo giocatore nel label Text
            name1.text = players.players[0].characterName;
            // Se ci sono 2 o più giocatori
            if(playersNum >= 2)
            {
                // Viene stampato il nome del secondo giocatore nel label Text
                name2.text = players.players[1].characterName;
                // Se ci sono 3 o più
                if (playersNum >= 3)
                {
                    // Viene stampato il nome del terzo giocatore nel label Text
                    name3.text = players.players[2].characterName;
                    // Se ci sono 4
                    if (playersNum >= 4)
                    {
                        // Viene stampato il nome del quarto giocatore nel label Text
                        name4.text = players.players[3].characterName;
                    }
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
