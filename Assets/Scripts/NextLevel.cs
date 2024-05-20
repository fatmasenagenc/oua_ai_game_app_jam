using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private Player_Movement Player;
    
    void Start()
    {
        
        Player= GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Door")) 
        {
            LevelLoader.instance.LoadNextLevel();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            LevelLoader.instance.LoadCurrentLevel();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
