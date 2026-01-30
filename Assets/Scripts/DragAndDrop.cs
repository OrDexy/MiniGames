using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 screenPoint;
    Vector3 offset;
    [SerializeField] Camera playerCamera;
    void Start()
    {
        playerCamera = Camera.main;
    }
    void OnMouseDown()
    {
        offset = gameObject.transform.position - playerCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x,Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = playerCamera.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        Pipe nei = gameObject.GetComponent<Pipe>();
        if(nei != null) nei.UpdateConnections();
    }
}