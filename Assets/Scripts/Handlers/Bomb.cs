using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public AudioSource bombAudioSource;
    public AudioClip bombExplosionSFX;
    public GameObject bombVFXPrefab;
    MeshRenderer bombMeshRenderer = null;
    [SerializeField] GameObject bombFuseVFXObject = null;

    void Awake(){
        bombMeshRenderer = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        BladeController blade = collision.GetComponent<BladeController>();
        GameController gameController = FindObjectOfType<GameController>();
        
        if(!blade){
            return;
        }

        bombMeshRenderer.enabled = false;
        bombFuseVFXObject.SetActive(false);

        bombAudioSource.PlayOneShot(bombExplosionSFX);
        FruitSlicedVFX();
        StartCoroutine(gameController.EndGame());
        //Destroy(this.gameObject, 6f);
    }

    void FruitSlicedVFX(){
        GameObject bombVFXInstance = (GameObject)Instantiate(bombVFXPrefab, transform.position, transform.rotation);
        Destroy(bombVFXInstance, 2f);
    }

    // void BombExplosion(){
    //     GameController gameController = FindObjectOfType<GameController>();

    //     bombAudioSource.PlayOneShot(bombExplosionSFX);
    //     FruitSlicedVFX();
    //     StartCoroutine(gameController.EndGame());
    //     Destroy(this.gameObject, 5f);
    // }
}
