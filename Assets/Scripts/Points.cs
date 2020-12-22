using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Oggetto serializzabile, che verrà salvato nel file dei punteggi (trasformabile in dati binari)
[System.Serializable]
public class Points
{
    // Lista dei punteggi (andrà a contenere la classifica Top 20 dei migliori giocatori)
    public List<Point> points;

    public Points(List<Point> points)
    {
        this.points = points;
    } 
}
