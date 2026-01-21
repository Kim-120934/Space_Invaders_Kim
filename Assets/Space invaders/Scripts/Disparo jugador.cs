using UnityEngine;

public class Disparojugador : MonoBehaviour
{
    public GameObject disparoPrefab;
    public AudioClip sonidoDisparo;
    private AudioSource audioSource;
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) 

        {
            Instantiate(disparoPrefab, transform.position, Quaternion.identity) ;
            audioSource.PlayOneShot(sonidoDisparo);
        }
    }
}
//Recursos:
//https://docs.unity3d.com/ScriptReference/Quaternion-identity.html
//https://www.youtube.com/watch?v=ZX5g1ZXt2e8
