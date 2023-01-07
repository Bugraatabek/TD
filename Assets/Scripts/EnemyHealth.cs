using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [Tooltip("Adds amount to maxHealth when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    int currentHealth = 0;

    Enemy enemy;
      void OnEnable()
      {
        currentHealth = maxHealth;
      }
      void Start()
      {
        enemy = GetComponent<Enemy>();
      }

     void OnParticleCollision(GameObject other) 
     {
      ProcessHit();
     }
     public void ProcessHit()
    {
          currentHealth = currentHealth - 1;
          if (currentHealth <= 0)
          {

           gameObject.SetActive(false);
           maxHealth += difficultyRamp;
           enemy.RewardGold();
          }
        }
        
        
    
 }
