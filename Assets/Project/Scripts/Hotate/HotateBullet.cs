using Hotate.Damage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotateBullet : Damage
{
    // SE
    [SerializeField] AudioClip sound1;
    AudioSource audioSource;

    // bullet prefab
    [SerializeField] GameObject bullet;

    float existTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke(nameof(DestroyBullet), existTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        DestroyBullet();
    }

    void DestroyBullet()
    {
        Destroy(bullet);
    }
}
