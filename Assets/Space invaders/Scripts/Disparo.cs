using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float moveSpeed;
    public GameObject explosionPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Enemigo")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Limites")
        {  
            Destroy(gameObject);
        }

    }
}
