using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cactus utilizzato per la creazione di un CactusPrefab, cioè il cacuts base che verrà ripetuto nel  gioco
public class Cactus : MonoBehaviour {
    // Velocità di scorrimento laterale del cactus
    public float speed = 10.0f;
    // Rigidbody del cactus 
    private Rigidbody2D rigidBody;
    // Corrisponde al vettore contenente le cordinate del cactus basate sul terreno e serve a 
    // indicare il punto di creazione e  distruzione dei cactus
    private Vector2 cameraBounds;

    // inutilizzato
    //private int randomCactus;

    // Corrisponde alle immagini dei cactus
    private Sprite sprites;

    // Corrisponde al terreno nella quale deve esserci il cactus (per esempio per il dinosauro 1 il terreno 1)
    private GameObject terrain;

    // Corrisponde al dinosauro
    private GameObject player;

	// Use this for initialization
	void Start () {
        // Loading delle immagini di cactus
        sprites = Resources.Load<Sprite>("Sprites/Enemies");
        // rigidBody corrisponde al Rigidbody2d di questo componente (cactus)
        rigidBody = this.GetComponent<Rigidbody2D>();
        // Impostazione di una velocità fissa laterale per il cactus, speed è negativo così che
        // il cactus scorre verso sinistra (cambia la posizione x del cactus ad ogni frame)
        rigidBody.velocity = new Vector2(-speed, 0);
        // metodo di inizializzazione dei componenti
        InitComponents();
    }
	
	// Update is called once per frame
	void Update () {
        // Se il cactus arriva alla fine (a sinistra) del terreno viene eliminato siccome non più utile
        if (transform.position.x < cameraBounds.x)
        {
            // Distruzione del cactus
            Destroy(this.gameObject);
        }
        // Se il dinosauro muore il cactus, se in movimento, si ferma
        if (player.GetComponent<Animator>().GetBool("morto"))
        {
            // La velocità del cactus viene settata a 0 così da fermare il cactus
            rigidBody.velocity = new Vector2(0, 0);
        }
	}

    // Metodod per inizializzare i componenti
    private void InitComponents()
    {
        // Ricerca del terreno secondo il nome del cactus, per esempio il cactus 1 verrà creato nel Terreno1
        terrain = GameObject.Find("Terrain" + this.name);
        // Ricerca del terreno secondo il nome del cactus, ad esempio il cactus 4 si fermerà se il Player4 muore
        player = GameObject.Find("Player" + this.name);
        // La x corrisponde al centro del terreno meno metà della lunghezza del terreno
        // La y corrisponde alla posizione verticale (messa manualmente dalla gui di unity) del cactus 
        cameraBounds = new Vector2(terrain.transform.position.x - terrain.GetComponent<Renderer>().bounds.size.x / 2, this.gameObject.transform.position.y);
    }
}
