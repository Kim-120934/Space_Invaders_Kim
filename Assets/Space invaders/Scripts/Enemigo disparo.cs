using UnityEngine;

public class Enemigodisparo : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down*speed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Limites")
        {
            Destroy(gameObject);
        }
    }
}
