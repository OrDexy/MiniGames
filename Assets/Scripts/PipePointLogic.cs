using UnityEngine;
using System.Collections;

public class PipePointLogic : MonoBehaviour
{
    SpriteRenderer sr;

    public GameObject[] friends;
    public GameObject pipe;

    public Sprite online;
    public Sprite offline;
    
    void Start() 
    { 
        sr = pipe.GetComponent<SpriteRenderer>();
    }
    
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "On")
        {
            sr.sprite = online;
            foreach (var item in friends)
            {
                item.gameObject.tag = "On";
            }
        } else {
		      sr.sprite = offline;
            foreach (var item in friends)
            {
                item.gameObject.tag = "Untagged";
            }        
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        sr.sprite = offline;
        foreach (var item in friends)
        {
            item.gameObject.tag = "Untagged";
        }
    }
}
