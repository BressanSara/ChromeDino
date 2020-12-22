using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script che si occupa di salvare e aggiornare i punteggi
public class PointsCounter : MonoBehaviour {
    // Formato base dêl testo del label
    private string textFormat = "{0}";

    // Oggeto Text nella quale è inserito questo script 
    private Text text;

    // Tempo passato
    private float timer = 0.0f;
    // Tempo attuale
    private float time;

    // Giocatori
    private Character[] players;

    // Use this for initialization
    void Start () {
        // Assegnazione del componente Text nella quale è inserito questo script
        text = GetComponent<Text>();
        // Ristampa dei punteggi
        ChangeValue(timer);
        // Salvataggio del tempo a inizio partita
        time = Time.time;
        // Loading della lista di giocatori
        players = SaveSystem.LoadPlayers().players;
    }
	
	// Update is called once per frame
	void Update () {
        // Aggiornamento del tempo
        timer = Time.time;
        // Se il tempo dall'ultimo frame è aumentato
        if(timer > time)
        {
            // Cambia i punteggi
            ChangeValue(timer);
            // Aggiorna il tempo nel tempo passato
            time = timer;
        }
	}

    // Cambia i punteggi
    private void ChangeValue(float number)
    {
        // Numero di giocatori morti
        int morti = 0;
        // Stampa nel lael i nuovi punteggi
        text.text = string.Format(textFormat, number);
        // Salva i punteggi per ogni giocatore vivo
        for(int i = 0; i < players.Length; i++)
        {
            if (players[i].isAlive)
            {
                players[i].points = number;

                SaveSystem.SavePlayers(players);
            }
            else
            {
                morti++;
            }
        }
        // Se tutti i giocatori sono morti salva i punteggi nel file
        if(morti == players.Length)
        {
            SaveSystem.SavePoints();
        }
    }
}
