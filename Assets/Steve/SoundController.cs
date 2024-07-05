using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource shot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        shot.Play();
    }

    public void canShoot()
    {
        GameStats.canShoot = true;
    }

    public void cannotShoot()
    {
        GameStats.canShoot = false;
    }
}
