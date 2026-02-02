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
    public float secsLeft = 30f;
    bool didIt = false;
    
    public GameObject lossPlay;    
    
    void Update()
    {
        if (!tellIfPaused.activeSelf) 
        {
            secsLeft -= Time.deltaTime;
            clock.fillAmount = secsLeft / 30f;
            label.text = ((int)secsLeft).ToString();
        }
        if(secsLeft <= 0f && didIt == false) 
		  {        
            StartCoroutine(YouLost());
            didIt = !didIt;
        }
    }
    IEnumerator YouLost() 
    {
        lossPlay.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
        yield return null;
    }
}
