using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PasswordG : MonoBehaviour
{
    public RectTransform box;
    public TMP_Text boxText;
    string answer;

    public TMP_InputField inp;
    void Start()
    {
        answer = Random.Range(100000, 999999).ToString();
        boxText.text = answer;
        box.anchoredPosition = new Vector2(Random.Range(-60, 61), Random.Range(-170, 171));
    }
    public void NumClck(string number) 
    {
        if (number == "x") inp.text = "";
        else if (number == "y") 
        {
            if (inp.text == answer) Debug.Log("Good");
            else Debug.Log("Bad");
        }
        else inp.text += number;
    }
}
