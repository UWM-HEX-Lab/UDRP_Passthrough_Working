using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThruFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camera;

    private float startY;
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(camera.transform.position.x, 0.0f, camera.transform.position.z);
    }
}
