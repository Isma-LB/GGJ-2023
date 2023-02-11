using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Pathfinding;

public class PlayerDie : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
   {
        Debug.Log("collide with " + other.name);
        if(other.TryGetComponent<Seeker>(out Seeker s)){
            FindObjectOfType<GameManager>().gameOver();
        }
   }
}
