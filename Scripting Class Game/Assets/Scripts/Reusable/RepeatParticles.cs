using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatParticles : MonoBehaviour
{
    private float counter;
    private ParticleSystem particleEffect;
    [SerializeField]
    private GameObject flash;

    private void Start()
    {
        counter = Random.Range(1f, 10f);
        particleEffect = gameObject.GetComponent<ParticleSystem>();
    }//End Start

    private void Update()
    {
        counter -= Time.deltaTime;
        if(counter <= 0)
        {
            particleEffect.Play();
            Instantiate(flash, transform);
            counter = Random.Range(1f, 10f);
        }//End if
    }
}
