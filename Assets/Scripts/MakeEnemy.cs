using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe che si occupa di creare i cactus 
public class MakeEnemy : MonoBehaviour {
    // Modello di cactus
    public GameObject cactusPrefab;
    // Tempo di creazione tra un cactus e l'altro (modificabile dalla GUI di Unity)
    public float timeToNewCactus = 1.0f;

    // Cordinate dell'area di gioco di 1 giocatore
    private Vector2 cameraBounds;

    // Giocatore (bisogna assegnarlo dalla GUI di Unity)
    public GameObject player;

    // Posizione y del cactus (bisogna dalla GUI di Unity)
    public float yPosition;

    // Terreno all'interno dell'area di gioco (bisogna assegnarlo dalla GUI di Unity)
    public GameObject terrain;

    // Numero del gioco attuale (bisogna assegnarlo dalla GUI di Unity)
    public string number; 

    // Use this for initialization
    void Start () {
        // La x corrisponde al centro del terreno meno metà della lunghezza del terreno
        // La y corrisponde alla posizione verticale (messa manualmente dalla gui di unity) del cactus 
        cameraBounds = new Vector2(terrain.transform.position.x - terrain.GetComponent<Renderer>().bounds.size.x,0);
        // Ogni tot di tempo viene creato un cactus
        StartCoroutine(CreateEnemy());
    }

    private void AddEnemy()
    {
        // Viene instanziato un nuovo GameObject cactus a partire dal cactus base
        GameObject enemy = Instantiate(cactusPrefab) as GameObject;
        // Il cactus viene posizionato all'inizio del terreno (destra)
        enemy.transform.position = new Vector2(terrain.transform.position.x + terrain.GetComponent<Renderer>().bounds.size.x /2, yPosition);
        // Il nome del cactus cossiponde al numero di gioco così da facilitarne la gestione
        enemy.name = number;
    }

    // Metodo che crea un nemico
    IEnumerator CreateEnemy()
    {
        // Se il giocatore del gioco corrente non è ancora morto
        if (!player.GetComponent<Animator>().GetBool("morto"))
        {
            while (true)
            {
                // Aspetta timeToNewCactus secondi
                yield return new WaitForSeconds(timeToNewCactus);
                // Se il giocatore del gioco corrente non è ancora morto
                if (!player.GetComponent<Animator>().GetBool("morto"))
                {
                    // Crea un nuovo cactus
                    AddEnemy();
                    // Il prossimo cactus verrà creato dopo x secondi dove x è un numero casuale tra 1 e 3
                    timeToNewCactus = Random.Range(1.0f, 3.0f);
                }
            }
        }
        
    }
}
