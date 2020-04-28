using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    public bool IsPlayer;
    private float energy;


    // Start is called before the first frame update

    private void Awake()
    {
        energy = 100f;
    }
    void Start()
    {
        InvokeRepeating("EnergyInc", 10f , 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncreaseEnergy(float factor)
    {
        energy = Mathf.Clamp(energy + factor, 0, 100);
    }

    void DecreaseEnergy(float factor)
    {
        energy = Mathf.Clamp(energy - factor, 0, 100);
    }

    public float ReturnEnergy()
    {
        return energy;
    }

    void EnergyInc()
    {
        if(IsPlayer == true)
        {
            energy = Mathf.Clamp(energy + 15, 0, 100);
        }
    }
}
