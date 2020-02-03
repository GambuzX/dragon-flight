using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform deathFXParent;
    [SerializeField] int points = 12;
    [SerializeField] int remainingHits = 3;

    private ScoreBoard scoreBoard;

    void Start() {
        scoreBoard = GameObject.FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other) {
        ProcessHit();
        if(remainingHits <= 0) KillEnemy();
    }

    void ProcessHit() {
        scoreBoard.ScoreHit(points);
        remainingHits--;
    }

    void KillEnemy() {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = deathFXParent;
        Destroy(gameObject);
    }
}
