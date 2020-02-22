using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
    public Image EnemyHealth;
    public Image EnemyH;
    public EnemyHealth enemyhealth;
    Animator anim;
    public Transform Destination;
    public bool isStood, isWalking;
    private NavMeshAgent navAgent;
    public Player player;
    public float Dist;
    public GameObject hand;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        EnemyH.gameObject.SetActive(false);
        enemyhealth = GetComponent<EnemyHealth>();
        anim = gameObject.GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        hand.GetComponent<SphereCollider>().enabled = false;
        time = 0f;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            if (!isStood)
            {
                isStood = true;
                anim.SetBool("isStanding", true);
                EnemyH.gameObject.SetActive(true);
            }
            Invoke("OnStandUp", 5F);
        }

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (isWalking)
        {
            if (Dist > 13.5)
            {
                EnemyHealth.fillAmount = enemyhealth.health / 100;
                isWalking = true;
                anim.SetBool("isWalking", true);
                navAgent.SetDestination(Destination.position);
                anim.SetBool("IsHitting", false);
                hand.GetComponent<SphereCollider>().enabled = false;
            }
            else
            {
                anim.SetBool("IsHitting", true);
                hand.GetComponent<SphereCollider>().enabled = true;
            }

        }
    }

    void OnStandUp()
    {
        isWalking = true;
    }
}
