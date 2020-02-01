using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadNextLevel", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadNextLevel() {
        SceneManager.LoadScene(1);
    }
}
