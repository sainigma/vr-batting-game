using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitcher : MonoBehaviour
{
    private float timer = 0;
    public GameObject ball;
    void Start() {
        
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer > 5f) {
            timer = 0;
            GameObject newBall = Instantiate(ball, this.transform.position, Quaternion.identity);
            newBall.GetComponent<Ball>().setVelocity(new Vector3(0, 6, 0));
        }
    }
}
