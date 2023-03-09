using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class EventManager : MonoBehaviour
{
    public GameObject pausedMenu;
    public GameObject nextLevelMenu;
    public GameObject player;
    private bool isPaused = false;

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if (nextScene == 4){
            nextScene = 1;
        }
        SceneManager.LoadScene(nextScene);
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    private IEnumerator GameOver(int a)
    {
        player.GetComponent<RocketMover>().enabled = false; 
        
        if (a == 0){
            yield return new WaitForSecondsRealtime(2);
            Time.timeScale = 0;
            pausedMenu.gameObject.SetActive(true);
        }
        else if (a == 1){
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezePosition;
            yield return new WaitForSecondsRealtime(2);
            Time.timeScale = 0;
            nextLevelMenu.gameObject.SetActive(true);
        }
    }

    public void PauseGame()
    {

        if (isPaused){
            Time.timeScale = 0;
            pausedMenu.gameObject.SetActive(true);
        }
        else{
            Time.timeScale = 1;
            pausedMenu.gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Awake() {
        InputSystem.EnableDevice(Keyboard.current);
        Time.timeScale = 1;
    }   

    // Update is called once per frame
    void Update()
    {   
        if (HitWall.isCrash == true){
            StartCoroutine(GameOver(0));
        }

        if (WayPointTrigger.complete == true){
            StartCoroutine(GameOver(1));
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
            isPaused = !isPaused;
            PauseGame();
        }
    }
}
