using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addText : MonoBehaviour {
    // Animazione che viene utilizzate per vedere se il dinosauro risulta morto
    public Animator Player;

    // Label nella quale viene inserito il nome dei giocatore quando esso muore
    private Text testo;

	// Use this for initialization
	void Start () {
        // il testo corrisponde al GameObject<Text> nella quale è contenuto questo script
        testo = GetComponent<Text>(); 
	}
	
	// Update is called once per frame
	void Update () {
        // Se l'animazione del dinosauro indica la sua morte
        if (Player.GetBool("morto"))
        {
            // Stampa nel label il testo "Sei morto {nome del giocatore} !!!"
            testo.text = "Sei morto " + Player.name + "!!!";
        }
    }
}
