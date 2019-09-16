using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
    Rigidbody rdb;
    public int lifeSpan = 3;
    public int bulletSpeed = 1;
    public int bulletDamange = 1;
    private float timeLeftToLive;
	// Use this for initialization
	void Start () {
        rdb = GetComponent<Rigidbody>();
        timeLeftToLive = lifeSpan;
	}
	
	// Update is called once per frame
	void Update () {
        rdb.MovePosition(rdb.position + transform.forward * bulletSpeed * Time.deltaTime);
        ApplyLifeSpan();

    }
    private void ApplyLifeSpan()
    {
        timeLeftToLive -= Time.deltaTime;
        if( timeLeftToLive <0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider otherObject)
    {
        Damagable damagable = otherObject.GetComponentInParent<Damagable>();
        if (damagable != null)
        {
            damagable.TakeDanage(bulletDamange);
        }
        Die();
    }
}
