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
    void Update() 
    {
        foreach (var item in friends)
        {
            if (item.gameObject.tag != "On") gameObject.tag = "Untagged";
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "On")
        {
            sr.sprite = online;
            foreach (var item in friends)
            {
                item.gameObject.tag = "On";
                gameObject.tag = "On";
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "On")
        {
            sr.sprite = offline;
            foreach (var item in friends)
            {
                item.gameObject.tag = "Untagged";
                gameObject.tag = "Untagged";
            }
        }
    }
}
