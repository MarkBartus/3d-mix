using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    
    AudioSource audioSource;
    public AudioClip footstep;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlaySoundEffect()
    {
        FindObjectOfType<AudioManager>().Play("footstep");
    }

}
