using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

// Script di salvataggio dei dati
public class SaveSystem{
    // Salvataggio dei dati dei giocatori
    public static void SavePlayers(Character[] players)
    {
        // Se il file non esiste viene creato, a quel punto i dati vengono trasformati in binario e 
        // inseriti nel file 
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/characters.file";

        Debug.Log(path);

        if (File.Exists(path))
        {
            FileStream close = new FileStream(path, FileMode.Truncate);
            close.Close();
        }

        FileStream stream = File.Create(path);
        Characters data = new Characters(players);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    // Caricamento dei dati dei giocatori
    public static Characters LoadPlayers()
    {
        // Se il file esiste vengono ritornati i dati dei giocatori non serializzati (non più binari)
        string path = Application.persistentDataPath + "/characters.file";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.OpenRead(path);

            Characters players = formatter.Deserialize(stream) as Characters;
            stream.Close();
            return players;
        }
        else
        {
            return null;
        }
    }

    // Salvataggio dei punteggi (classifica Top 20)
    public static void SavePoints()
    {
        // Se il file non esiste viene creato, a quel punto i dati vengono trasformati in binario e 
        // inseriti nel file
        string path = Application.persistentDataPath + "/points.txt";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream;
        if (File.Exists(path))
        {
            stream = File.OpenWrite(path);
        }
        else
        {
            stream = File.Create(path);
        }
        Points points = formatter.Deserialize(stream) as Points;
        Characters players = LoadPlayers();
        for(int i = 0; i < players.players.Length; i++)
        {
            points.points.Add(new Point(players.players[i].characterName, players.players[i].points));
        }
        stream.Close();
    }

    // Caricamento punteggi
    public static Points LoadPoints()
    {
        // Se il file esiste vengono ritornati i dati dei punteggi non serializzati (non più binari)
        string path = Application.persistentDataPath + "/points.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.OpenWrite(path);

            Points points = formatter.Deserialize(stream) as Points;
            while(points.points.Count > 20)
            {
                Point toRemove = points.points[0];
                for(int i = 0; i < points.points.Count; i++)
                {
                    if(toRemove.getPoints() < points.points[i].getPoints())
                    {
                        toRemove = points.points[i];
                    }
                }
                points.points.Remove(toRemove);
            }
            formatter.Serialize(stream, points);
            stream.Close();
            return points;
        }
        else
        {
            return null;
        }
    }
}
