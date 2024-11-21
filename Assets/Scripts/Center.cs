using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : MonoBehaviour
{
    public Transform head;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            float x = head.position.x;
            float z = head.position.z;
            float y = transform.position.y;

            transform.position = new Vector3(x, y, z);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0.0f, 0.5f * Time.deltaTime, 0.0f));
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0.0f, -0.5f * Time.deltaTime, 0.0f));
        }
    }
}
