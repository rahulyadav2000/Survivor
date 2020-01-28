using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerSystem : MonoBehaviour
{
    public float HungerLevel = 0;
    private float ElapsedTime=0f,FixedTime=3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
   

    public float UpdateHungerLevel(float Health)
    {
        Mathf.Clamp(HungerLevel, 0, 100);
        if (ElapsedTime > FixedTime)
        {
            HungerLevel += 10;
            if (HungerLevel >= 80)
            {
                Health -= 10f;
            }
            ElapsedTime = 0f;
        }
        else
        {
            ElapsedTime += Time.deltaTime; 
        }
        return Health;
    }
    public void DecreaseHungerLevel(float factor)
    {
        HungerLevel = Mathf.Clamp(HungerLevel - factor, 0, 100);
    }
}
