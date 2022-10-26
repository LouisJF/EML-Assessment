using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSprite : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 mousePos;
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Move Sprite to mouse position and keep in front of other objects so its easy to see
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        this.transform.position = new Vector3(mousePos.x, mousePos.y, -1);
    }
}
