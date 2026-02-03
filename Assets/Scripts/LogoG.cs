using UnityEngine;

public class LogoG : MonoBehaviour
{
    public string whichTag;
    public int limit;
    [SerializeField] int countOfDoings = 1;
    public GameObject shape;//dud
    static bool isQuitting = false;
    bool yesToSpawn = true;
    
    void Update()
    {
        if(yesToSpawn == true && countOfDoings < limit)
        {
            yesToSpawn = false;
            countOfDoings++;
            Instantiate(shape, transform.position, Quaternion.identity);
        }
    }
    
    void OnApplicationQuit() { isQuitting = true; }
    
    void OnTriggerExit2D(Collider2D collision)//broimlagging
    {
        if(collision.gameObject.tag == whichTag && isQuitting == false)
            yesToSpawn = true;
    }
}
