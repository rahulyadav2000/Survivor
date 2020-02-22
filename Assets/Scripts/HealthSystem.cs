using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float Health = 100;

    public float GetHealth()
    {
        return Health;
    }

    public void IncreaseHealth(float factor)
    {
        Health = Mathf.Clamp(Health + factor, 0, 100);
    }

    public void decreaseHealth(float factor)
    {
        Health = Mathf.Clamp(Health - factor, 0, 100);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}
