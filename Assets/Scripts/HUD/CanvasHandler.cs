using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CanvasHandler : MonoBehaviour
{
    public IEnumerator StartScene(string sceneName){
        yield return null; //new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneName);
    }
    
    public void ChangeScene(string sceneName){
        StartCoroutine(StartScene(sceneName));
    }
}
