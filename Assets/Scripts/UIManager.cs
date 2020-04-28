using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Image HealthBar;
    public Image HungerBar;
    // Start is called before the first frame update
    public HungerSystem hungerSystem;
    public HealthSystem healthSystem;
    public InventoryUI inventoryUI;
    public Image EnemyHealth;
   
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Terrain");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Terrain");
    }

    public void Home()
    {
        SceneManager.LoadScene("StartScene");
    }
}
