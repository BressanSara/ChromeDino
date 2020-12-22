using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Script di gestione dei punteggi
public class ScoreController : MonoBehaviour {
    // Lista dei punteggi
    private Points scores; 
    // Numdero del classificato (riga della tabella di punteggi nella quale è inserito questo script)
    // Si deve assegnare manualmente dalla GUI di Unity
    public int number;
    // Label contenente il numero in classifica (Si deve assegnare manualmente dalla GUI di Unity)
    public Text textNumber;
    // Label che conterrà il nome del giocatore (Si deve assegnare manualmente dalla GUI di Unity)
    public Text name;
    // Label che conterrà il punteggio del giocatore (Si deve assegnare manualmente dalla GUI di Unity)
    public Text score;

    public Button reset;
	// Use this for initialization
	void Start () {
        // Caricamento dei punteggi
        scores = SaveSystem.LoadPoints();
        // Se la lista nnn è vuota
        if(scores != null)
        {
            // I punteggi vengono messi in ordine
            scores.points.Sort();
            // Se il classificato attuale figura nella lista vengono riempiti i label con il punteggio e
            // il nome del giocatore, altrimenti i label vengono azzerati
            if (number <= scores.points.Count)
            {
                int num = number - 1;
                name.text = scores.points[num].getName();
                score.text = scores.points[num].getPoints().ToString();
            }
            else
            {
                name.text = "";
                score.text = "";
            }
        }
        else
        {
            // I Label vengono svuotati
            name.text = "";
            score.text = "";
        }
        // Il numero del classificato viene stampato nel label "textNumber"
        textNumber.text = number.ToString() + ".";

        // Se il bottone di reset viene cliccato il label del nome e quello dei punti vengono resettati
        reset.onClick.AddListener(Reset);
    }

    private void Reset()
    {
        // I Label vengono svuotati
        name.text = "";
        score.text = "";
    }

    // Update is called once per frame
    void Update () {
		
	}
}
