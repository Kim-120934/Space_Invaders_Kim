using Unity.VisualScripting;
using UnityEngine;


public class Disparo : MonoBehaviour
{
    public float moveSpeed;
    public GameObject explosionPrefab;
    private Puntuación puntuación;

    void Start()
    {
        puntuación = GameObject.Find("Puntuación").GetComponent<Puntuación>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            // Obtén el componente New_Invader del enemigo
            New_Invader invader = collision.GetComponent<New_Invader>();
            int points = 50; // Valor por defecto si no tiene el componente

            // Si el enemigo tiene el componente, obtén sus puntos
            if (invader != null)
            {
                points = invader.pointValue;
            }
            
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            puntuación.UpdateScore(points); // Usa los puntos del enemigo
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Limites")
        {
            Destroy(gameObject);
        }
    }
}

