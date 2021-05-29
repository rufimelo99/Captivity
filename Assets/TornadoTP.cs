using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoTP : MonoBehaviour
{

    [SerializeField] private Collider2D myColliderTornadoTP;
    [SerializeField] private SpriteRenderer rendTornadoTp;
    [SerializeField] private Transform camera1;
    [SerializeField] private Transform camera2;
    [SerializeField] private bool up;
    [SerializeField] private bool down;
    [SerializeField] private bool right;
    [SerializeField] private bool left;
    [SerializeField] private bool upright;
    [SerializeField] private bool upleft;
    [SerializeField] private bool downright;
    [SerializeField] private bool downleft;    
    //public Collider2D roomChanger;
    public Transform nextPosition;
    
    private Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        if (up){
            move = new Vector3(0, 24.0f, 0);
        }
        if (down){
            move = new Vector3(0, -24.0f, 0);
        }
        if (right){
            move = new Vector3(27.0f, 0, 0);
        }
        if (left){
            move = new Vector3(-27.0f, 24.0f, 0);
        }
        if (upright){
            move = new Vector3(27.0f, 24.0f, 0);
        }
        if (upleft){
            move = new Vector3(-27.0f, 24.0f, 0);
        }
        if (downright){
            move = new Vector3(27.0f, -24.0f, 0);
        }
        if (downleft){
            move = new Vector3(-27.0f, -24.0f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            camera1.position += move;
            col.gameObject.transform.position = nextPosition.position + new Vector3(0,0,29.7f- 0.344532f);
        }
        if(col.gameObject.tag == "Player2"){  
            camera2.position += move;
            col.gameObject.transform.position = nextPosition.position + new Vector3(0, 0, 29.7f - 0.344532f);
        }
    }
}
