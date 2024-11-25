using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThruStatic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-1.0f, 0.0f, 0.0f) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, -1.0f) * Time.deltaTime);
        }
    }
}
