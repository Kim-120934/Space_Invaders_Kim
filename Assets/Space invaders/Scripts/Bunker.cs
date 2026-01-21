using UnityEngine;

public class Bunker : MonoBehaviour
{

    public Sprite[] damageStages; // Array de sprites con diferentes niveles de daño
    public int health = 4; // Debe coincidir con el número de sprites
    public GameObject explosionPrefab;

    private SpriteRenderer spriteRenderer;
    private int currentStage = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo Disparo" || collision.gameObject.tag == "Disparo")
        {
            health--;

            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
            }

            Destroy(collision.gameObject);

            // Cambia el sprite según el daño
            if (health > 0 && currentStage < damageStages.Length)
            {
                spriteRenderer.sprite = damageStages[currentStage];
                currentStage++;
            }
            else if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    //Recursos:
    //https://docs.unity3d.com/ScriptReference/Component.GetComponent.html
    //https://www.youtube.com/watch?v=qWDQgmdUzWI

}

