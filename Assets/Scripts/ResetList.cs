using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

// Resett la classifica
public class ResetList : MonoBehaviour {
    // Bottone di reset (bisogna assegnarlo dalla GUI di Unity) 
    public Button button;

	// Use this for initialization
	void Start () {
        // Se il bottone viene cliccato fa un reset
        button.onClick.AddListener(Reset);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Reset()
    {
        // Nuovo formatter
        BinaryFormatter formatter = new BinaryFormatter();
        // Path del file dei punteggi
        string path = Application.persistentDataPath + "/points.txt";
        // Se il file con salvati i punteggi esiste
        if (File.Exists(path))
        {
            // Elimina il file dei punteggi
            FileStream close = new FileStream(path, FileMode.Truncate);
            close.Close();
        }
    }
}
