using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    public AudioSource MusicaFundo;
    public AudioClip Musica1;

    // Start is called before the first frame update
    void Start()
    {
        MusicaFundo.clip = Musica1; 
        MusicaFundo.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
