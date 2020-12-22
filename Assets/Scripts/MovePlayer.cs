using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gestisce il giocatore (questo script deve essere inserito nel Player di ogni gioco)
public class MovePlayer : MonoBehaviour { 
    // Animazione del dinosauro attuale
    private Animator animazione;
    // Ridgidbody del gioco attuale
    private Rigidbody2D player;

    // Stato del dinosauro (immagine: dino normale, dino che saluta o pigiosauro)
    private int state = 0;
    // Velocità di salto (quanto salta in alto, modificamile dalla GUI di Unity)
    public float jSpeed = 2f;
    // Indica se il dinosauro sta saltando
    private int jump = 0;
    // Nome del cactus che corrisponde anche al numero di gioco (bisogna assegnarlo dalla GUI di Unity)
    public string cactusName;

    // Lista di Character, cioè la lista dei giocatori
    private Characters players;

    // Giocatore attuale
    private Character character;

    // Numero di giocatori
    private int playersNumber;

    // Indica se esiste o no nel gioco (ad esempio se si vuole 3 giocatori il 4 viene eliminato ed è quindi inesistente)
    private bool notExists;
    

	// Use this for initialization
	void Start () {
        // Assegnazione della Animator
        animazione = this.GetComponent<Animator>();
        // Assegnazionde del player
        player = GetComponent<Rigidbody2D>();
        // Seleziona l'animazione (il dinosauro) e la mostra
        animazione.SetInteger("selectDinosaur", state);
        // Caricamento dei dati dei giocatori
        players = SaveSystem.LoadPlayers();
        // Numero di giocatori secondo il numero di giocatori salvati nel file
        playersNumber = players.players.Length;
        // Il gioco selezionato è di troppo è come se non esistesse
        if(playersNumber < int.Parse(cactusName))
        {
            // Assegnazione delle impostazioni salvate per questo giocatore
            character = players.players[int.Parse(cactusName) - 1];
            // Setting del colore del dinosauro
            SetColor();
        }
        else
        {
            notExists = true;
        }
    }

    // Update is called once per frame
    void Update () {
        // Se viene cliccato il tasto "esc" il gioco (.exe) viene chiuso
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        // Se il gioco attuale esiste
        if (!notExists)
        {
            // Selezione del dinosauro
            state = animazione.GetInteger("selectDinosaur");

            // Se il giocatore è ancora vivo
            if (character.isAlive)
            {
                // Viene selezionato il dinosauro a seconda delle impostazioni inserite dal giocatore nel menu
                if (character.dino == 0)
                {
                    state = 0;
                    animazione.SetInteger("selectDinosaur", state);
                }
                else if (character.dino == 0)
                {
                    state = 1;
                    animazione.SetInteger("selectDinosaur", state);
                }
                else if (character.dino == 0)
                {
                    state = 2;
                    animazione.SetInteger("selectDinosaur", state);
                }

                // A seconda del numero di gioco ogni giocatore ha un tasto assegnato, se quel tasto
                // viene cliccato il dinosauro salta
                if(int.Parse(cactusName) == 1)
                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        JumpPlayer();
                    }
                }
                else if (int.Parse(cactusName) == 2)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        JumpPlayer();
                    }
                }
                else if (int.Parse(cactusName) == 3)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        JumpPlayer();
                    }
                }
                else if (int.Parse(cactusName) == 4)
                {
                    if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        JumpPlayer();
                    }
                }


                // Una volta atterrato cambia l'animazione del dinosauro 
                if (animazione.GetBool("jump"))
                {
                    animazione.SetBool("jump", false);
                }
            };
        }
    }

    // Setta il colore del dinosauro secondo le impostazioni selezionate dal giocatore nel main menu
    private void SetColor()
    {
        GetComponent<Renderer>().material.color = new Color(character.red, character.green, character.blue);
    }

    // Il dinosauro salta
    private void JumpPlayer()
    {
        // Se il dinosauro non sta saltando
        if (animazione.GetBool("jump") == false)
        {
            // Il dinosauro salta (sale verticalmente, poi la gravità del rigidbody lo riporta a terra)
            jump = 0;
            animazione.SetBool("jump", true);
            player.velocity = new Vector2(0, jSpeed);
        }
    }

    // Ascoltatore di collisioni
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se il dinosauro si scontra con un cactus del suo stesso gioco
        if(collision.collider.name == cactusName)
        {
            // Il dinosauro muore
            animazione.SetBool("morto", true);
            character.isAlive = false;
        }
    } 
}
