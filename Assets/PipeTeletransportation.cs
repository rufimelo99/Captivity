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

    [SerializeField] public GameObject pipeGameObject;
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
        /*distanceToVapourPrefab = (pipe.transform.position - tornado.transform.position).sqrMagnitude;
        if(distanceToVapourPrefab < 3 && tornado.transform.position == roomChangerToMistery.transform.position){
            roomChangerToMistery.transform.position = roomChangerToMistery.transform.position+new Vector3(0,0,1f);
        }*/
    }
}
