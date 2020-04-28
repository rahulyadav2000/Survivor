using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    public AudioSource Source;
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ani.SetBool("Punch", true);
            Source.Play();
        }

    }
}
