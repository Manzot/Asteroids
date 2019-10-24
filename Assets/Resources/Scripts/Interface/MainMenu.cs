using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public List<AudioSource> audioSources;

    public void StartButtonPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SoundButtonPressed()
    {
       if( AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }
  

    public void QuitButtonPressed() {
        Application.Quit();
    }
}
