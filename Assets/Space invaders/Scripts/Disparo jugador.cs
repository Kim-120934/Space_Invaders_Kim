using UnityEngine;

public class Disparojugador : MonoBehaviour
{
    public GameObject disparoPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) 

        {
            Instantiate(disparoPrefab, transform.position, Quaternion.identity) ;
        }
    }
}
