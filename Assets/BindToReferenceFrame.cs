using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindToReferenceFrame : MonoBehaviour
{
    GameObject currentlyBound = null;
    Vector3 previousPosition;

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
            transform.Translate(newPosition - previousPosition);
            previousPosition = newPosition;
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
}
