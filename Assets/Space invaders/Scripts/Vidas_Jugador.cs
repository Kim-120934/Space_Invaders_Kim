using UnityEngine;
using UnityEngine.UI;

public class Vidas_Jugador : MonoBehaviour
{
    public int lives = 3;
    public Image[]livesUI;
    public GameObject explosionPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag =="Enemigo")
        {
            Destroy(collision.collider.gameObject);
            Instantiate(explosionPrefab,transform.position, Quaternion.identity);
            lives -= 1;
            for (int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true;
                }
                else
                {
                    livesUI[i].enabled = false;
                }

                if (lives <= 0)
                {
                    Destroy(gameObject);

                }
            }
        }
    
     }
}
