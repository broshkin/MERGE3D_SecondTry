using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TryGetComponent<AudioSource>(out AudioSource audio))
        {
            if (!audio.isPlaying)
            {
                Destroy(gameObject);
            }
        }
        if (TryGetComponent<ParticleSystem>(out ParticleSystem particle))
        {
            if (!particle.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    
    }
}
