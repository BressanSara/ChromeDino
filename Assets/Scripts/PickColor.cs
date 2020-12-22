using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Color Picker
public class PickColor : MonoBehaviour { 
    // Immagine di esempio del menù
    private Image image;

    // DropDown di selezione del dinosauro
    public Dropdown dinoSelect;

    // Immagini dei dinosauri (devono essere assegnate dalla GUI di Unity)
    public Sprite dino1;
    public Sprite dino2;
    public Sprite dino3;

    // Slider di selezione del colore (devono essere assegnate dalla GUI di Unity)
    public Slider red;
    public Slider green;
    public Slider blue;

    // Valori degli slider
    private float redValue;
    private float greenValue;
    private float blueValue;

	// Use this for initialization
	void Start () {
        // Image corrisponde all'Image del componente all'interno della quale è presente questo script
        image = GetComponent<Image>();

        // Assegna i valori dei colori iniziali
        // Nel caso in cui il valore sia modificato vengono richiamati ChangeRedValue(),ChangeBlueValue() 
        // o ChangeGreenValue()
        ChangeRedValue(red.value);
        red.onValueChanged.AddListener(ChangeRedValue);
        ChangeGreenValue(green.value);
        green.onValueChanged.AddListener(ChangeGreenValue);
        ChangeBlueValue(blue.value);
        blue.onValueChanged.AddListener(ChangeBlueValue);

        SelectDino(dinoSelect.value);
        dinoSelect.onValueChanged.AddListener(SelectDino);
    }

    // Update is called once per frame
    void Update () {

    }
    // Cambia il colore dell'immagine ad ogni cambiamento dello slider rosso
    private void ChangeRedValue(float value)
    {
        redValue = value;
        image.color = new Color(redValue/255F, greenValue / 255F, blueValue / 255F);
    }

    // Cambia il colore dell'immagine ad ogni cambiamento dello slider verde
    private void ChangeGreenValue(float value)
    {
        greenValue = value;
        image.color = new Color(redValue / 255F, greenValue / 255F, blueValue / 255F);
    }

    // Cambia il colore dell'immagine ad ogni cambiamento dello slider vlu
    private void ChangeBlueValue(float value)
    {
        blueValue = value;
        image.color = new Color(redValue / 255F, greenValue / 255F, blueValue / 255F);
    }

    // Seleziona il dinosauro (e comabia immahine) a seconda le impostazioni inserite dal giocatore nel menù
    private void SelectDino(int value)
    {
        if(value == 0)
        {
            image.sprite = dino1;
        }
        else if(value == 1)
        {
            image.sprite = dino2;
        }
        else
        {
            image.sprite = dino3;
        }
    }


}
