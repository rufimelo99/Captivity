using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTeletransportation : MonoBehaviour
{
    /*private float distanceToVapourPrefab;
    [SerializeField] public GameObject fusionVapourPrefab;*/
    [SerializeField]
    private Player player;
    [SerializeField] private Animator pipe;
    [SerializeField] private Collider2D myColliderPipe;
    [SerializeField] private SpriteRenderer rendPipe;
    
    
    public Collider2D roomChanger;

    public GameObject pipeGameObject;

    //public GameObject fusionTornado;

    //private float distanceToVapourPrefab;
    private float distanceToPlayer1;

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
        if(pipeGameObject.tag == "PipeOut"){
            pipe.SetBool("PipeOut", true);
        }else{
            pipe.SetBool("PipeOut", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //distanceToVapourPrefab = (fusionTornado.transform.position - transform.position).sqrMagnitude;
        distanceToPlayer1 = (player.transform.position - pipeGameObject.transform.position).sqrMagnitude;

        if(distanceToPlayer1 < 20 && pipeGameObject.tag == "PipeIn"){
            SetActive(roomChanger);
            Debug.Log(distanceToPlayer1);
        }else{
            SetInActive(roomChanger);
        }
    }

    //turn off
    void SetInActive (Collider2D col) {
        col.enabled = false;
    } 
 
    //turn on
    void SetActive (Collider2D col) {
         col.enabled = true;
    }
}
