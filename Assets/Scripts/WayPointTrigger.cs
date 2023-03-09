using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WayPointTrigger : MonoBehaviour
{
    public GameObject StartTrigger;
    public GameObject HalfTrigger;
    public GameObject FinishTrigger;
    public GameObject LapMinBox;
    public GameObject LapSecBox;
    public GameObject LapMillBox;
    private int BestMin;
    private int BestSec;
    private float BestMill;
    public static bool sign;
    public static bool complete;
    private string sMin, sSec, sMill;

    private void Start() {
        AssignScoreKey();
        GetScore();
        sign = false;
        complete = false;
    }

    private void GetScore(){
        BestMin = PlayerPrefs.GetInt(sMin);
        BestSec = PlayerPrefs.GetInt(sSec);
        BestMill = PlayerPrefs.GetFloat(sMill);
        DisplayScore();
    }

    private void AssignScoreKey()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1){
            sMin = "Min1";
            sSec = "Sec1";
            sMill = "Mill1";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2){
            sMin = "Min2";
            sSec = "Sec2";
            sMill = "Mill2";
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3){
            sMin = "Min3";
            sSec = "Sec3";
            sMill = "Mill3";
        }
    }

    private void SaveScore(int min, int sec, float mill)
    {          
        PlayerPrefs.SetInt(sMin, min);
        PlayerPrefs.SetInt(sSec, sec);
        PlayerPrefs.SetFloat(sMill, mill);      
    }

    private void DisplayScore()
    {
        if (this.BestSec <= 9)
            this.LapSecBox.GetComponent<Text>().text = "0" + this.BestSec + ".";
        else
            this.LapSecBox.GetComponent<Text>().text = "" + this.BestSec + ".";

        if (this.BestMin <= 9)
            this.LapMinBox.GetComponent<Text>().text = "0" + this.BestMin + ":";
        else
            this.LapMinBox.GetComponent<Text>().text = "" + this.BestMin + ":";

        this.LapMillBox.GetComponent<Text>().text = "" + this.BestMill;
    }

    private void CompareAndDisplay(int min, int sec, float mill){
        if (this.BestMin > min){
            this.BestMin = min;
            this.BestSec = sec;
            this.BestMill = mill;
            SaveScore(min, sec, mill);
        }
        else if (this.BestMin == min){
            if (this.BestSec > sec){
                this.BestSec = sec;
                this.BestMill = mill;
                SaveScore(min, sec, mill);
            }
            else if (this.BestSec == sec){
                if (this.BestMill > mill)
                    this.BestMill = mill;
                    SaveScore(min, sec, mill);
            }
        }
        DisplayScore();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "StartPointTrigger"){
            sign = true;          
            StartTrigger.SetActive(false);
            HalfTrigger.SetActive(true);
        }
        else if (other.gameObject.name == "HalfPointTrigger"){
            FinishTrigger.SetActive(true);
            HalfTrigger.SetActive(false);
        }
        else if (other.gameObject.name == "FinishPointTrigger"){
            complete = true;
            if (sign == true){
                this.BestMill = TimeScorer.TimeCount;
                this.BestSec = TimeScorer.SecCount;
                this.BestMin = TimeScorer.MinCount;
            }
            CompareAndDisplay(TimeScorer.MinCount,TimeScorer.SecCount, TimeScorer.TimeCount);
            TimeScorer.TimeCount = 0;
            TimeScorer.MinCount = 0;
            TimeScorer.SecCount = 0;
        }

    }
}
