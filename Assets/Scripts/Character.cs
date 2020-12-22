using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Classe serializzabile, cioè nel mio caso salvabile su un file binario 
[System.Serializable]
public class Character{
    // Nome del giocatore
    public string characterName;
    // (Immagine) dinosauro selezionato
    public int dino;
    // Valori con la quale verrà creato il colore del dinosauro
    public float red;
    public float blue;
    public float green;
    // Punti del giocatore
    public float points;
    // Indica se il giocatore è vivo o morto
    public bool isAlive;

    // Costruttore di un oggetto personaggio
    public Character(string name, int sprite, Color colore)
    {
        characterName = name;
        dino = sprite;
        red = colore.r;
        blue = colore.b;
        green = colore.g;
        points = 0.0f;
        isAlive = true;
    }

    //public void setName(string name)
    //{
    //    characterName = name;
    //}

    //public string getName()
    //{
    //    return characterName;
    //}

    //public void setDino(int sprite)
    //{
    //    dino = sprite;
    //}

    //public int getDino()
    //{
    //    return dino;
    //}

    //public void setColor(Color colore)
    //{
    //    red = colore.r;
    //    blue = colore.b;
    //    green = colore.g;
    //}

    //public Color getColor()
    //{
    //    return new Color(red,green,blue);
    //}

    //public void setPoints(float points)
    //{
    //    this.points = points;
    //}

    //public float getPoints()
    //{
    //    return this.points;
    //}

    //public bool getIsAlive()
    //{
    //    return this.isAlive;
    //}

    //public void die()
    //{
    //    if (isAlive)
    //    {
    //        this.isAlive = false;
    //    }
    //}
}
