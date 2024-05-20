using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject options, how_to_play;
    void Start()
    {
        if(options!=null) options.SetActive(false);
        if(how_to_play!=null) how_to_play.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void start_game() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void exit_game() 
    {
    Application.Quit();
    }

    public void enter_options()
    {
        options.SetActive(true);
    }
    public void exit_options()
    {
        options.SetActive(false);
    }
    public void enter_how_to_play()
    {
        how_to_play.SetActive(true);
    }
    public void exit_how_to_play()
    {
        how_to_play.SetActive(false);
    }
    public void restart_game() 
    {
        SceneManager.LoadScene(0);
    }
    
}
