using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject credits;
    
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    
    public void ButtonCredits(bool set)
    {
        credits.SetActive(set);
    }
    
    public void Exit()
    {
        Application.Quit();
    }

}
