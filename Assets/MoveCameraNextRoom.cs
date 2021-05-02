using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraNextRoom : MonoBehaviour
{

    [SerializeField]
    private Transform camera;
    [SerializeField]
    private Transform camera2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector3 roomMover = new Vector3(27, -1, 0);
            camera.position += roomMover;
        }
        if (collision.tag == "Player2")
        {
            Vector3 roomMover = new Vector3(27, -1, 0);
            camera2.position += roomMover;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
