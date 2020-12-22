using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe Serializzabile, quindi salvabile su un file binario 
[System.Serializable]
public class Characters{
    // Array contenente i giocatori
    public Character[] players;

    // Costruttore 
    public Characters(Character[] players)
    {
        this.players = players;
    }
}
