using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int StartingGold = 150;
    [SerializeField] int currentGold;
    public int CurrentGold { get { return currentGold;}}
    TextMeshPro label;

    [SerializeField] TextMeshProUGUI displayGold;
    
    void Awake() 
    {
     currentGold = StartingGold;
     UpdateDisplayGold();
    }
    
    public void Deposit(int amount)
    {
        currentGold += Mathf.Abs(amount);
        UpdateDisplayGold();
    }
    
    public void Withdraw(int amount)
    {
        currentGold -= Mathf.Abs(amount);
        UpdateDisplayGold();
        if (currentGold < 0)
        {
            SceneManager.LoadScene(0); // Scene currenScene = SceneManager.GetActiveScene()
                                       // Scenemmanager.LoadScene(currentScene)
        }
        
    }
   
    void UpdateDisplayGold()
    {
        displayGold.text = "Gold:" + currentGold;
    }
}
