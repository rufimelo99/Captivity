using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTeletransportation : MonoBehaviour
{
    /*private float distanceToVapourPrefab;
    [SerializeField] public GameObject fusionVapourPrefab;*/
    [SerializeField] private Animator pipe;
    [SerializeField] private Collider2D myColliderPipe;
    [SerializeField] private SpriteRenderer rendPipe;
    [SerializeField] private Transform camera1;
    [SerializeField] private Transform camera2;
    [SerializeField] private bool up;
    
    //public Collider2D roomChanger;
    public Transform nextPosition;
    
    private Vector3 move;
    

    //private float distanceToVapourPrefab;
    //private float distanceToPlayer1;

    /*
    [SerializeField] public GameObject roomChangerToMistery;
    [SerializeField] private Collider2D myCollider;
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private Animator tornado;
    [SerializeField] private Collider2D myColliderTornado;
    [SerializeField] private SpriteRenderer rendTornado;*/

    
    // Start is called before the first frame update
    void Start()
    {
        if (up){
            move = new Vector3(0, 24, 0);
        }else{
            move = new Vector3(0, -24, 0);
        }

        if(gameObject.tag == "PipeOut"){
            pipe.SetBool("PipeOut", true);
        }else{
            pipe.SetBool("PipeOut", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //distanceToVapourPrefab = (fusionTornado.transform.position - transform.position).sqrMagnitude;
        //distanceToPlayer1 = (player.transform.position - pipeGameObject.transform.position).sqrMagnitude;

        /*if(distanceToPlayer1 < 20 && pipeGameObject.tag == "PipeIn"){
            SetActive(roomChanger);
            Debug.Log(distanceToPlayer1);
        }else{
            SetInActive(roomChanger);
        }*/
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Vapor"){
            camera1.position += move;    
            camera2.position += move;
            col.gameObject.transform.position = nextPosition.position;
        }
    }
}
