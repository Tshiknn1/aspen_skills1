using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float movementSpeed = 3;
    [SerializeField] float movementRange = 10;
    private float initialX;
    private bool increasing = true;

    // Start is called before the first frame update
    void Start()
    {
        initialX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (increasing)
        {
            transform.Translate(movementSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x >= initialX + movementRange)
            {
                increasing = false;
            }
        }
        else
        {
            transform.Translate(-movementSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x <= initialX - movementRange)
            {
                increasing = true;
            }
        }
    }
}
