using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake() {
        if(GameObject.FindObjectsOfType<MusicPlayer>().Length > 1) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
