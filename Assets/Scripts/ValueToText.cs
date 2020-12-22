using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Trasforma in testo e stampa il valore dello slider al suo interno, questo script è da inserire nell'handle
// di ogni slider
public class ValueToText : MonoBehaviour {
    // Formato del testo 
    private string textFormat = "{0}";

    // Testo dentro l'Handler dello slider
    private Text text;

    // slider
    private Slider slider;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        slider = GetComponentInParent<Slider>();
        // Cambia il valore dello slider nel valore iniziale
        ChangeValue(slider.value);
        // Ad ogni spostamento dello slider (cambiamento di valore) il testo viene aggiornato
        slider.onValueChanged.AddListener(ChangeValue);
	}

    private void ChangeValue(float number)
    {
        // Stampa il nuovo valore nel label 
        text.text = string.Format(textFormat, number);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
