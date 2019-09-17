using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiSphereSmall : Ennemi
{
    GameObject player;
    public float speed = 5;
    Rigidbody rdb;
    public int nombreEnnemieSphereApresMort = 2;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rdb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();

    }
    private void FollowPlayer()
    {
        rdb.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime));
    }
    public override void Die()
    {
        
        Destroy(gameObject);
    }
}
