using UnityEngine;

public class EverChangingColors : MonoBehaviour
{
    public void ChangeColor(string s)
    {
        string[] man = s.Split(' ');
        gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(byte.Parse(man[0]), byte.Parse(man[1]), byte.Parse(man[2]), byte.Parse(man[3]));
    }
}
