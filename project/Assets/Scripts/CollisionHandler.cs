using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;

    [Tooltip("FX prefab on player")][SerializeField] GameObject explosion;
    
    private void OnTriggerEnter(Collider other) {
        StartDeathSequence();
    }

    private void StartDeathSequence() {
        SendMessage("OnPlayerDeath");
        explosion.SetActive(true);     
        Invoke("ReloadScene", levelLoadDelay);   
    }

    private void ReloadScene() {
        SceneManager.LoadScene(1);
    }
}
