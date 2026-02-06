using UnityEngine;
using System.Collections.Generic;

public class Pipe : MonoBehaviour
{
    public LayerMask pipeLayer;
    
    public Sprite online;
    public Sprite offline;
    SpriteRenderer sr;
    
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(gameObject.tag == "Untagged")
        {
            sr.sprite = offline;
        } else {
            sr.sprite = online;
        }
        if(gameObject.tag == "Source")
        {
            SpreadPower("On");
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag != "Untagged")
        {
            SpreadPower("On");
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.CompareTag("Source"))
        {
            SpreadPower("On");
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.tag != "Untagged")
        {
            SpreadPower("Untagged");
        }
    }
    public void SpreadPower(string tage)
    {

        gameObject.tag = tage;
        Collider2D neighborCollider = Physics2D.OverlapCircle(transform.position, 0.1f, pipeLayer);
        if(neighborCollider != null && neighborCollider.gameObject != this.gameObject)
        {
            Pipe neighbor = neighborCollider.GetComponent<Pipe>();
            if(neighbor != null)
                neighbor.SpreadPower(tage);
        }
    }
}
