using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform deathFXParent;
    [SerializeField] int points = 12;

    private ScoreBoard scoreBoard;

    void Start() {
        scoreBoard = GameObject.FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other) {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = deathFXParent;
        scoreBoard.ScoreHit(points);
        Destroy(gameObject);
    }
}
