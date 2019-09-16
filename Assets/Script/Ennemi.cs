using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public abstract class Ennemi : MonoBehaviour, Damagable
{
   public int lifeTotal = 10;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TakeDanage(int damage)
    {
        lifeTotal -= damage;
        if (lifeTotal <=0)
        {
            Die();
        }
    }
    public abstract void Die();
    
    protected void setLife(int new_lifeTotal)
    {
        lifeTotal = new_lifeTotal;
    }
}
