using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class NavMeshTarget : MonoBehaviour
{
    public NavMeshAgent selfNav;
    public GameObject self;

    float MaxHealth;
    public float health = 100;

    public GameObject player;

    //the distance the enemy is from the player
    [Header("Distance To Player")]
    public float distancetoTarget;

    //this bit means that the enemies won't attack EVERY frame.
    [Header("Enemy Damage Settings")]
    [SerializeField] float timeDelay;
    public float timeForDelay = 0;

    [Header("Damage Settings")]
    public float damageToGive;

    void Start()
    {
        MaxHealth = 100;
        health = MaxHealth;
    }

    void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        selfNav = GetComponent<NavMeshAgent>();

        MaxHealth = 100;
        health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        timeForDelay += Time.deltaTime;

        distancetoTarget = Vector3.Distance(player.transform.position, self.transform.position);
        selfNav.SetDestination(player.transform.position);

        if(health <= 0)
        {
            Destroy(self);
        }

        if ((distancetoTarget < 3) && (timeForDelay >= timeDelay))
        {
            player.GetComponent<Health>().health -= damageToGive;
            timeForDelay = 0;
        }

        }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
            if (collision.gameObject.GetComponent<PlayerMovement>().sliding)
            {
                if((collision.gameObject.GetComponent<Rigidbody>().velocity.x >= 5) || (collision.gameObject.GetComponent<Rigidbody>().velocity.z >= 5))
                {
                    TakeDamage(15);
                    self.GetComponent<Rigidbody>().AddForce(1, 0, 1);
                }
            }
        }
    }
}
