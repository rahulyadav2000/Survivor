using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private InventoryObject inventory;
    public HungerSystem hungerSystem;
    private HealthSystem healthSystem;
    private Animator ani;
    private Vector3 movePosition = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController charactercontroller;
    public float speed=12f;
    public float jumpspeed=150f;
    public Image healthbar, hungerbar;
    public GameObject inventoryUI;
    public GameObject sidepanel;
    public UIManager UIManager;

    // Start is called before the first frame update
    void Awake()
    {
        ani = GetComponent<Animator>();
        charactercontroller = GetComponent<CharacterController>();
        healthSystem = GetComponent<HealthSystem>();
        hungerSystem = GetComponent<HungerSystem>();
        // hungerSystem.SetHealthSystem(healthSystem);
        inventory = GetComponent<InventoryObject>();
    }
    public void Consume(Item item)
    {
        var foodData = item.item as FoodObject;
        Debug.Log(foodData);
        if (foodData != null)
        {
            healthSystem.IncreaseHealth(foodData.HealthValue);
            hungerSystem.DecreaseHungerLevel(foodData.Hungervalue);
        }
    }
    public void Drop(GameObject dropped)
    {
        var go = Instantiate(dropped) as GameObject;
        var spawnPoint = transform.position + (transform.forward * 10);
        spawnPoint.y += 1000;
        var ray = new Ray(spawnPoint, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.point);
            spawnPoint.y = hit.point.y + go.transform.localScale.y * 0.5f;
        }
        go.transform.position = spawnPoint;
    }

    private void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            sidepanel.SetActive(!sidepanel.activeSelf);
            inventoryUI.GetComponent<InventoryUI>().Refresh();

                }
        healthSystem.Health= hungerSystem.UpdateHungerLevel(healthSystem.Health);
        healthbar.fillAmount = healthSystem.Health/100;
        hungerbar.fillAmount = hungerSystem.HungerLevel/100;
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
           
            ani.SetBool("canRun", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            ani.SetBool("canRun", false);
        }

        if(charactercontroller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpspeed;
                ani.SetBool("Jump", true);
            }
           
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ani.SetBool("Jump", false);
        }
        transform.Rotate(0, Input.GetAxis("Mouse X") *60*Time.deltaTime,0);
        
        moveDirection.y -= 7.1f;
        charactercontroller.Move(moveDirection * speed * Time.deltaTime);
        var magnitude = new Vector2(charactercontroller.velocity.x, charactercontroller.velocity.z).magnitude;
        ani.SetFloat("Speed", magnitude);

        // transform.Rotate(0, Input.GetAxis("Horizontal") *)
       
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var food = hit.gameObject.GetComponent<Food>();
        var item = hit.gameObject.GetComponent<Item>();
        if (Input.GetKeyDown(KeyCode.E) && food && item)
        {
            healthSystem.IncreaseHealth(food.Health);
            hungerSystem.HungerLevel = food.Hunger;
            inventory.AddItem(hit.gameObject);
            
            Destroy(hit.gameObject);
        }

        var obs = hit.gameObject.GetComponent<Obstacles>();
         if(obs)
        {
          
            healthSystem.decreaseHealth(obs.Health);
            Destroy(hit.gameObject);
        }

    }

   /* public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if(item)
        {
            
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }*/
}

