using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using TMPro;
public class Startup : MonoBehaviour
{
    public Image progressBar;
    public TMP_Text progressText;
    public string sceneToLoad;
    public float howMuchPrecentage;
    [SerializeField] float progress = 0.0f;
    void Start()
    {
        StartCoroutine(LoadAsyncScene());
    }
    IEnumerator LoadAsyncScene()
    {
        while (progress < 1f)
        {
            if (progressBar != null)
                progressBar.fillAmount = progress;
            if (progressText != null)
                progressText.text = (int)(progress * 100f) + "%";
            progress += howMuchPrecentage;
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene(1);
        yield return null;
    }
}
