using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class CounterWorks : MonoBehaviour
{
    public Image clock;
    public TMP_Text label;
    public GameObject tellIfPaused;
    [SerializeField] float secsLeft = 30f;
    void Update()
    {
        if (!tellIfPaused.activeSelf) 
        {
            secsLeft -= Time.deltaTime;
            clock.fillAmount = secsLeft / 30f;
            label.text = ((int)secsLeft).ToString();
        }
        if(secsLeft <= 0f) StartCoroutine(YouLost());
    }
    IEnumerator YouLost() 
    {
        Debug.Log("You lost... returning back to menu");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
        yield return null;
    }
}
