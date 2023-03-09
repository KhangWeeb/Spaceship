using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject lv1Box;
    public GameObject lv2Box;
    public GameObject lv3Box;
    public GameObject MainMenu;
    public GameObject LevelMenu;
    public GameObject ScoreBoard;
    public Button lv2;
    public Button lv3;

    public void MainButton(GameObject a)
    {
        MainMenu.SetActive(false);
        if (a.name == "ScoreMenu")
            GetAndDisplayScore();
        a.SetActive(true);
    }

    public void LevelButton(int a)
    {
        SceneManager.LoadSceneAsync(a);
    }

    public void BackToMenu(){
        if (LevelMenu.gameObject.activeInHierarchy == true){
            LevelMenu.SetActive(false);
        }
        else if (ScoreBoard.gameObject.activeInHierarchy == true){
            ScoreBoard.SetActive(false);
        }
        MainMenu.SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();
    }

    private void GetAndDisplayScore()
    {
        lv1Box.GetComponent<Text>().text = PlayerPrefs.GetInt("Min1").ToString()+"."+PlayerPrefs.GetInt("Sec1").ToString()+":"+PlayerPrefs.GetFloat("Mill1").ToString();
        lv2Box.GetComponent<Text>().text = PlayerPrefs.GetInt("Min2").ToString()+"."+PlayerPrefs.GetInt("Sec2").ToString()+":"+PlayerPrefs.GetFloat("Mill2").ToString();
        lv3Box.GetComponent<Text>().text = PlayerPrefs.GetInt("Min3").ToString()+"."+PlayerPrefs.GetInt("Sec3").ToString()+":"+PlayerPrefs.GetFloat("Mill3").ToString();
    }
    
    private void InitializeScore()
    {
        PlayerPrefs.SetInt("Min1", 0);
        PlayerPrefs.SetInt("Min2", 0);
        PlayerPrefs.SetInt("Min3", 0);
        PlayerPrefs.SetInt("Sec1", 0);
        PlayerPrefs.SetInt("Sec2", 0);
        PlayerPrefs.SetInt("Sec3", 0);
        PlayerPrefs.SetFloat("Mill1", 0f);
        PlayerPrefs.SetFloat("Mill2", 0f);
        PlayerPrefs.SetFloat("Mill3", 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeScore();
        MainMenu.SetActive(true);
        
        if (PlayerPrefs.GetInt("Min2")+PlayerPrefs.GetInt("Sec2")>0 || PlayerPrefs.GetInt("Mill2")>0f){
            lv2.interactable = true;
        }
        if (PlayerPrefs.GetInt("Min3")+PlayerPrefs.GetInt("Sec3")>0 || PlayerPrefs.GetInt("Mill3")>0f){
            lv3.interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
