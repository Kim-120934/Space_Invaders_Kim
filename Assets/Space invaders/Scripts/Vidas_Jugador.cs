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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo Disparo" || collision.gameObject.tag == "Enemigo")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
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
            }
            if (lives <= 0)
            {
                Destroy(gameObject);
                
            }
        }
    }
    //Recursos:
    //https://docs.unity3d.com/ScriptReference/Component.CompareTag.html
    //https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
    //https://www.youtube.com/watch?v=ZX5g1ZXt2e8&list=PLSR2vNOypvs5jmv1YIP_IVtlPnU5yEunL
}
