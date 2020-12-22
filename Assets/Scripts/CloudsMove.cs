using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script per la gestione del movimento delle nuvole (applicato a entrambi gli sfondi in parallasse) 
public class CloudsMove : MonoBehaviour {
    // Velocità dello sfondo modificabile dalla GUI di Unity
    public float velocita;

    // Renderizzazionde dello sprite delle nuovole
    private Renderer oggetto;

    // Use this for initialization
    void Start()
    {
        // Questo script deve essere applicato al GameObject di uno degli sfondi in parallasse
        oggetto = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Con il passare del tempo lo sfondo si sposta orizzontalmente
        Vector2 offset = new Vector2((-1)*Time.time * velocita, 0);
        oggetto.material.mainTextureOffset = offset;

    }
}
