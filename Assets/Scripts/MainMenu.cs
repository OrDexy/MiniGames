using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void TPtoAGame(int id)
    {
        if(id == null) id = 0;
        SceneManager.LoadScene(id);
    }
}
