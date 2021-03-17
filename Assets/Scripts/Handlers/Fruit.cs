using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruit;
    private SoundController soundManager;
    public GameObject fruitSliceVFXPrefab;
    private GameController gameController;

    void Awake(){
        soundManager = FindObjectOfType<SoundController>();
        gameController = FindObjectOfType<GameController>();
    }

    void SlicingSound(){
        switch(this.gameObject.name){
            case "Orange(Clone)":
                soundManager.fruitSFXController.PlayOneShot(soundManager.fruitSliceSounds[0]);
                break;
            case "Apple(Clone)":
                soundManager.fruitSFXController.PlayOneShot(soundManager.fruitSliceSounds[1]);
                break;
            case "Banana(Clone)":
                soundManager.fruitSFXController.PlayOneShot(soundManager.fruitSliceSounds[2]);
                break;
            case "PearCompound(Clone)":
                soundManager.fruitSFXController.PlayOneShot(soundManager.fruitSliceSounds[0]);
                break;
            default:
                break;
        }
    }

    void CreateSlicedFruit(){
        GameObject fruitInstance = (GameObject)Instantiate(slicedFruit, transform.position, transform.rotation);
        Destroy(this.gameObject);

        Rigidbody[] rbsSlicedParts = fruitInstance.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody r in rbsSlicedParts){
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(1000, 1400), transform.position, 5f);
        }

        Destroy(fruitInstance, 5f);
    }

    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("Acertei uma: " + this.gameObject.name);
        BladeController blade = collision.GetComponent<BladeController>();

        if(!blade){
            return;
        }
        
        gameController.AddScore(1);

        SlicingSound();
        FruitSlicedVFX();
        CreateSlicedFruit();
    }
    
    void FruitSlicedVFX(){
        GameObject fruitVFXInstance = (GameObject)Instantiate(fruitSliceVFXPrefab, transform.position, transform.rotation);
        Destroy(fruitVFXInstance, 2f);
    }
}
