using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script per lo scorrimento del terreno da inserire nel GameObject del terreno
public class TerrenoMove : MonoBehaviour {
    // Velocità orizzontale da settare dalla GUI di Unity
    public float velocita;

    // Animazione del Dinosauro presente sul terreno attuale (bisogna assegnarla dalla GUI di Unity) 
    public Animator player; 

    // Render del terreno 
    private Renderer oggetto;

    // Use this for initialization
    void Start()
    {
        oggetto = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Se il dinosauro è vivo il terreno si muove orizzontalmente verso sinistra
        if (player.GetBool("morto") == false)
        {
            Vector2 offset = new Vector2((-1) * Time.time * velocita, 0);
            oggetto.material.mainTextureOffset = offset;
        }
    }
}
