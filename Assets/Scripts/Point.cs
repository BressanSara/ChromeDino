using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Oggetto da salvare  
public class Point : ScriptableObject
{
    // Nome del giocatore
    private string characterName;
    // Punti del giocatore
    private float points;

    // Costruttore
    public Point(string name, float points)
    {
        characterName = name;
        this.points = points;
    }

    public void setName(string name)
    {
        characterName = name;
    }

    public string getName()
    {
        return characterName;
    }

    public void setPoints(float points)
    {
        this.points = points;
    }

    public float getPoints()
    {
        return this.points;
    }
}
