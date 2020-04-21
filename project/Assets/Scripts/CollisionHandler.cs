using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;

    [Tooltip("FX prefab on player")][SerializeField] GameObject explosion;
    
    [SerializeField] float invulnerabilityPeriod = 3f;
    private bool isInvulnerable = true;

    void Start() {
        Invoke("ToggleInvulnerability", invulnerabilityPeriod);
    }

    private void ToggleInvulnerability() {
        isInvulnerable = !isInvulnerable;
    }

    private void OnTriggerEnter(Collider other) {
        if(isInvulnerable) return;

        StartDeathSequence();
    }

    private void StartDeathSequence() {
        SendMessageUpwards("OnPlayerDeath");
        explosion.SetActive(true);     
        Invoke("ReloadScene", levelLoadDelay);   
    }

    private void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
