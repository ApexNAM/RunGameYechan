using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    public float speed = 10f;
    void Update()
    {
        if(!GameManager.instance.isGameOver)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
