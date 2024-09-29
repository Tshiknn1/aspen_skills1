using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindToReferenceFrame : MonoBehaviour
{
    private GameObject currentlyBound = null;
    private Vector3 previousPosition;
    private Vector3 momentum = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentlyBound != null)
        {
            Vector3 newPosition = currentlyBound.transform.position;
            Vector3 delta = newPosition - previousPosition;
            transform.Translate(delta);
            previousPosition = newPosition;
            momentum = delta / Time.deltaTime;
        }
        else
        {
            transform.Translate(momentum * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FrameOfReference"))
        {
            currentlyBound = collision.gameObject;
            previousPosition = currentlyBound.transform.position;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        currentlyBound = null;
    }
}
