using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject self;

    public float timeToDestroy = 3;
    float time = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if (time >= timeToDestroy)
        {
            Destroy(self.gameObject);
            time = 0;
        }
    }

    private void OnEnable()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<NavMeshTarget>().TakeDamage(33);
            Destroy(self.gameObject);
        }
        else
        {
            Destroy(self.gameObject);
        }
    }
}
