using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Script di gestione del MainMenù
public class MenuController : MonoBehaviour { 
    // GameObject contenente questo script
    private GameObject menu;

    // Slider che controlla il numero di giocatori (bisogna assegnarlo dalla GUI di Unity)
    public Slider slider;
    // Il numero di giocatori
    private int numberOfPlayers = 1;

    // Lista dei giocatori da salvare
    private List<Character> players;

    // L'immagine che si trova all'interno del canvas e nella quale verrà mostrato il dinosauro in modifica
    // (bisogna assegnarla dalla GUI di Unity)
    public Image playerImage;
    // La Dropdown di selezione del dinosauro (bisogna assegnarlo dalla GUI di Unity)
    public Dropdown playerMode;
    // Valori con la quale verrà creato il colore del dinosauro (bisogna assegnarli dalla GUI di Unity)
    public Slider red;
    public Slider green;
    public Slider blue;
    // Immagini dei dinosauri (bisogna assegnarle dalla GUI di Unity)
    public Sprite dino1;
    public Sprite dino2;
    public Sprite dino3;

    // Dropdown di selezione del giocatore da modificare (bisogna assegnarlo dalla GUI di Unity)
    public Dropdown playerSelect;
    // Lista dei nomi dei giocatori
    private List<string> playerNames = new List<string> { };
    // Nomi di default dei giocatori
    private List<string> playerDefaultNames = new List<string> { "Player 1", "Player 2", "Player 3", "Player 4" };
    // Giocatore selezionato
    private int selectedName = 0;

    // Input per l'immissione del nome del giocatore (bisogna assegnarlo dalla GUI di Unity)
    public InputField input;

    // Bottone che fa partire il gioco (bisogna assegnarlo dalla GUI di Unity)
    public Button startButton;


    // Use this for initialization
    void Start () {
        // Il menu corrisponde al GameObject corrente
        menu = GetComponent<GameObject>();

        // Creazione della lista contenente i 4 giocatori di default
        Character c1 = new Character(playerDefaultNames[0], playerMode.value, playerImage.color);
        Character c2 = new Character(playerDefaultNames[0], playerMode.value, playerImage.color);
        Character c3 = new Character(playerDefaultNames[0], playerMode.value, playerImage.color);
        Character c4 = new Character(playerDefaultNames[0], playerMode.value, playerImage.color);
        players = new List<Character> {
            c1,
            c2,
            c3,
            c4
        };

        // Di default si può scegliere un giocatore
        playerNames.Add(playerDefaultNames[0]);
        playerSelect.AddOptions(playerNames);

        // Viene cambiato il numero di giocatori
        slider.onValueChanged.AddListener(ChangeNumberOfPlayers);

        // Quando viene selezionato un'altro giocatore viene richiamato change name
        playerSelect.onValueChanged.AddListener(ChangeName);

        // Quando viene cambiato il nome del giocatore viene richiamato il metodo rename
        input.onValueChanged.AddListener(Rename);

        // Quando viene cambiato il dinosauro viene richiamato il metodo CreatePlayer
        playerMode.onValueChanged.AddListener(ChangePlayerMode);

        // Quando il colore viene cambiato viene richiamato il metodo ChangeColor
        red.onValueChanged.AddListener(ChangeColor);
        green.onValueChanged.AddListener(ChangeColor);
        blue.onValueChanged.AddListener(ChangeColor);

        // Quando viene cliccato il bottone di start parte il gioco
        startButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update () {
        // Se viene prmuto il tasto "esc" si esce dal gioco
        if (Input.GetKey("escape"))
        {
            // Uscita dal gioco
            Application.Quit();
        }
    }

    // Il numero di giocatori cambîa secondo il vaolore dello slider
    private void ChangeNumberOfPlayers(float value)
    {
        ChangeName(0);
        ChangeValue(value);
    }

    // Cambia il menù a tendina decondo il numero di giocatori value
    private void ChangeValue(float value)
    {
        // Il numero di giocatori viene cambiato
        numberOfPlayers = (int)value;
        // Tutte le opzioni del menù a tendina vengono cancellate
        playerSelect.ClearOptions();
        // La lista temporanea dei nomi dei giocatori viene cancellata
        playerNames.Clear();
        for(int i = 0; i < numberOfPlayers; i++)
        {
            // Per il numero di giocatori viene aggiunto il nome di default alla lista dei giocatori temporanea
            playerNames.Add(playerDefaultNames[i]);
        }
        // Vengono aggiunti le opzioni contenenti il nome dei giocatori della lista temporanea
        playerSelect.AddOptions(playerNames);
    }

    // Creazione di un giocatore
    private void CreatePlayer(int value)
    {
        // Al giocatore selezionato viene assegnato il nome corrente
        players[selectedName].characterName = playerNames[selectedName];
        // Assegnazione del colore 
        players[selectedName].red = playerImage.color.r;
        players[selectedName].blue = playerImage.color.b;
        players[selectedName].green = playerImage.color.g;
        // Assegnazionde del dinosauro
        players[selectedName].dino = playerMode.value;
    }

    // Cambia giocatore selezionato
    private void ChangeName(int name)
    {
        // Cambia il giocatore selezionato secondo il valore name (dato dal menù a tendina)
        selectedName = name;
        // Mette l'immagine del dinosauro secondo le impostazioni messe in precedenza dal giocatore corrente
        playerImage.color = new Color(players[selectedName].red, players[selectedName].green, players[selectedName].blue);
        // Nell'input di tetso mette il nome attuale del giocatore selezionato
        input.text = players[selectedName].characterName;
        // Cambia l'immagine secondo quella del giocatore corrente
        playerMode.value = players[selectedName].dino;
        // Mostra l'immagine secondo le caratteristiche preimpostate dal giocatore attivo
        SelectDino(players[selectedName].dino);
    }

    // Rinomina il giocatore
    private void Rename(string name)
    {
        // Cambia il nome salvato del giocatore atttuale
        playerDefaultNames[selectedName] = name;
        // Cambia i valori aggiornandoli
        CreatePlayer(selectedName);
        // Aggiorna il menù a tendina
        ChangeValue(playerNames.Count);
    }

    // Cambia il colore dei dinosauri
    private void ChangeColor(float arg)
    {
        CreatePlayer(selectedName);
    }

    // Seleziona l'immagine del dinosauro giusto
    private void SelectDino(int value)
    {
        // Mostra a schermo il dinosauro secondo il valore value
        if (value == 0)
        {
            playerImage.sprite = dino1;
        }
        else if (value == 1)
        {
            playerImage.sprite = dino2;
        }
        else
        {
            playerImage.sprite = dino3;
        }
    }

    // Cambia il dinosauro
    private void ChangePlayerMode(int value)
    {
        CreatePlayer(selectedName);
    }

    // Crea la lista definitiva dei giocatori
    private void CreateDefinitive()
    {
        // Elimina i giocatori in eccesso
        if(slider.value == 3)
        {
            players.RemoveAt(3);
            if(slider.value == 2)
            {
                players.RemoveAt(2);
                if (slider.value == 1)
                {
                    players.RemoveAt(1);
                }
            }
        }
    }

    // Fa partire il gioco
    private void StartGame()
    {
        // Crea la lista di giocatori definitiva
        CreateDefinitive();
        // Array di giocatori da serializzare
        Character[] characters = new Character[players.Count];
        for(int i = 0; i < players.Count; i++)
        {
            // Assegnazionde dei valori
            characters[i] = players[i];
        }
        // Salvataggio dei dati dei giocatori su un file
        SaveSystem.SavePlayers(characters);
        // Loading della scena di gioco
        SceneManager.LoadScene("1");
    }
}

