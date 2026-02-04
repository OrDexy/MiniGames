using UnityEngine;
using UnityEngine.U2D;
public class PartOfPicture : MonoBehaviour
{
    public Color32 cl;

    GameObject par;

    SpriteRenderer sr;
    SpriteShapeRenderer ssr;
    SpriteRenderer srpar;

    bool isIt = false;

    void Start()
    {
        cl = new Color32(255,255,0,255);
        par = transform.parent.gameObject;
        sr = gameObject.GetComponent<SpriteRenderer>();
        if(sr == null)
        {
            ssr = gameObject.GetComponent<SpriteShapeRenderer>();
            isIt = true;
        }
        srpar = par.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        cl = srpar.material.color;
    }
    void OnMouseDrag()
    {
        if(!isIt)
            sr.material.color = cl;
        else
            ssr.material.color = cl;
    }
}
