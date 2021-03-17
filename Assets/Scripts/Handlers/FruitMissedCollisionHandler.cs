using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitMissedCollisionHandler : MonoBehaviour
{
    private GameController gameController;
    
    void Awake(){
        gameController = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Fruit"){
            gameController.FruitMissed();
        }
    }
}
