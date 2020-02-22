using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   public float health = 100f;
    public Animator anim;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            anim.SetBool("IsDead", true);
            Invoke("IsDeadCompleted", 2.517f);
            Destroy(enemy.gameObject, 2.6f); 
        }
        
    }

    void IsDeadCompleted()
    {
        anim.SetBool("IsDead", false);
    }
   
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
    }
}
