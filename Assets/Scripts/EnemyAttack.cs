using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if (time > 1.5f)
            {
                time = 0f;
                collision.gameObject.GetComponent<HealthSystem>().TakeDamage(20);
            }
        }
    }
}
