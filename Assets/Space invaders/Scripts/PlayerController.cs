using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int vidas = 3;
    private Vector3 posicionInicial;

    void Start()
    {
        // Guardar la posición inicial del jugador
        posicionInicial = transform.position;
    }

    public void PerderVida()
    {
        vidas--;

        // Volver al centro de la pantalla
        transform.position = posicionInicial;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        if (vidas <= 0)
        {
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo") || collision.CompareTag("Enemigo Disparo"))
        {
            PerderVida();
            Destroy(collision.gameObject);
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
    }
}
