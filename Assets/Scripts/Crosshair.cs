using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private RectTransform crosshair;
    public Rigidbody rigi;

    public float restingSize;
    public float maxSize;
    public float speed;
    public float currentSize;

    public bool isMoving;

    private void Start()
    {
        crosshair = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (isMoving)
        {
            currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * speed);
        }
        else
        {
            currentSize = Mathf.Lerp(currentSize, restingSize, Time.deltaTime * speed * 2);
        }

        crosshair.sizeDelta = new Vector2(currentSize, currentSize);

        

        if(
            Input.GetAxis("Horizontal") != 0 ||
            Input.GetAxis("Vertical") != 0)
            {
                isMoving = true;
            }
        else
        {
            isMoving = false;
        }
    }

    
}
