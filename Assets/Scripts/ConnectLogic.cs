using UnityEngine;

public class ConnectLogic : MonoBehaviour
{
    public LayerMask layer;
    public string brandName;
    LineRenderer lr;

    Camera playerCamera;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetWidth(.2f, .2f);
        playerCamera = Camera.main;
    }

    void OnMouseDown()
    {
        lr.SetPosition(0, transform.position);
    }
    void OnMouseDrag()
    {
        lr.SetPosition(1, playerCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10)));
    }
    void OnMouseUp()
    {
        Vector3 ladno = playerCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10));
        Collider2D neigh = Physics2D.OverlapCircle(ladno, 0.1f, layer);
        if(neigh != null && neigh.gameObject != this.gameObject)
        {
            lr.SetPosition(1, neigh.transform.position);
            if(neigh.gameObject.name == brandName)
                Debug.Log("W");
        }
        else
            lr.SetPosition(1, transform.position);
    }
}
