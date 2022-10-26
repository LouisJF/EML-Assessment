using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCollision : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> gameObjects = new List<GameObject>();
    public bool brightenColorsOnCircle = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float r = 0, g = 0, b = 0;
        if (gameObjects.Count > 0)
        {
            foreach (GameObject go in gameObjects)
            {
                Color c = go.GetComponent<SpriteRenderer>().color;
                
                r += c.r * c.r;
                g += c.g * c.g;
                b += c.b * c.b;
                
            }

            r = Mathf.Sqrt(r / gameObjects.Count);
            g = Mathf.Sqrt(g / gameObjects.Count);
            b = Mathf.Sqrt(b / gameObjects.Count);
        }
        if (brightenColorsOnCircle)
        {
            this.GetComponent<SpriteRenderer>().color = brightenColor(new Color(r, g, b));
        }
        else { 
            this.GetComponent<SpriteRenderer>().color = new Color(r, g, b);
        }
    }

    Color brightenColor(Color c)
    {
        float highest = 0.9f;
        if (c.r >= c.g && c.r >= c.b)
        {
            highest = c.r;
        }
        else if (c.g >= c.r && c.g >= c.b)
        {
            highest = c.g;
        }
        else if (c.b >= c.g && c.b >= c.r)
        {
            highest = c.b;
        }
        Color color = new Color(c.r / highest, c.g / highest, c.b / highest);
        return color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponents<SpriteRenderer>() != null)
        {
            gameObjects.Add(collision.gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponents<SpriteRenderer>() != null)
        {
            gameObjects.Remove(collision.gameObject);
        }
    }
    
}
