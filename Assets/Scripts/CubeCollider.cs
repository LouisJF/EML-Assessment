using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 0;
    bool randomized = false;
    bool colliding = false;
    public CubeController controller;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (colliding)
        {
            timer += Time.deltaTime;
            if (timer >= 3 && !randomized)
            {
                controller.randomizeCubesColor(this.gameObject);
                randomized = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliding = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;
        timer = 0;
        randomized = false;
    }

}
