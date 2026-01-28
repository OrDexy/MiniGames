using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalButton : MonoBehaviour
{
    public Slider musicS;
    public Slider soundS;
    private void Start()
    {
        Debug.Log("Loaded Music Volume: " + PlayerPrefs.GetFloat("MusicVolume", -1f));
        Debug.Log("Loaded Sound Volume: " + PlayerPrefs.GetFloat("SoundVolume", -1f));
    }
    public void SaveSettings() 
    {
        PlayerPrefs.SetFloat("MusicVolume", musicS.value);
        PlayerPrefs.SetFloat("SoundVolume", soundS.value);
    }
    public void ExitGame() 
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) 
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
