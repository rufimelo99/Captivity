using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate_v2 : MonoBehaviour
{

    private SpriteRenderer PressurePlate1_sr;
    private SpriteRenderer Door_sr;
    [SerializeField]
    private Sprite PressurePlateNonActivated_Sprite;
    [SerializeField]
    private Sprite PressurePlateActivated_Sprite;
    [SerializeField]
    private GameObject DoorToBeOpened;
    // Start is called before the first frame update
    void Start()
    {
        PressurePlate1_sr = gameObject.GetComponent<SpriteRenderer>();
        Door_sr = DoorToBeOpened.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        Debug.Log("ola");
        PressurePlate1_sr.sprite = PressurePlateActivated_Sprite;

        DoorToBeOpened.GetComponent<BoxCollider2D>().enabled = false;
        Door_sr.sprite = null;
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        Debug.Log("ulala");
        PressurePlate1_sr.sprite = PressurePlateActivated_Sprite;

        DoorToBeOpened.GetComponent<BoxCollider2D>().enabled = false;
        Door_sr.sprite = null;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("bye");
        PressurePlate1_sr.sprite = PressurePlateNonActivated_Sprite;
    }
}
