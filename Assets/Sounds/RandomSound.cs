using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{

    public AudioSource sound;
    public bool sound3D = true;
    public float randomMin;
    public float randomMax;
    public float firstPlay;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlaySound", firstPlay);
    }

    void PlaySound()
    {
        GameObject newSound = new GameObject(); // this gives you a new game object in your hierarchy
        AudioSource newAS = newSound.AddComponent<AudioSource>();
        newAS.clip = sound.clip;
        if (sound3D)
        {
            newAS.spatialBlend = 1;
            newAS.maxDistance = sound.maxDistance;
            newSound.transform.SetParent(this.transform);
            newSound.transform.localPosition = Vector3.zero;
        }
        newAS.Play();        
        Invoke("PlaySound", Random.Range(randomMin, randomMax));
        Destroy(newSound, sound.clip.length);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
