using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScorer : MonoBehaviour
{
    public GameObject LapMinBox;
    public GameObject LapSecBox;
    public GameObject LapMillBox;
    public static float TimeCount;
    public static int MinCount, SecCount;
    public static string MillDisplay;

    private void Start() {
        TimeCount = 0;
        MinCount = 0;
        SecCount = 0;
        MillDisplay = "";
    }

    private void Update() {
        if (WayPointTrigger.sign == false)
            return;
        TimeCount += Time.deltaTime*10;
        MillDisplay = TimeCount.ToString("F0");
        LapMillBox.GetComponent<Text>().text = "" + MillDisplay;

        if (TimeCount >= 10){
            TimeCount = 0;
            SecCount += 1;
        }

        if (SecCount <= 9)
            LapSecBox.GetComponent<Text>().text = "0" + SecCount + ".";
        else
            LapSecBox.GetComponent<Text>().text = "" + SecCount + ".";

        if (SecCount >= 60){
            SecCount = 0;
            MinCount += 1;
        }

        if (MinCount <= 9)
            LapMinBox.GetComponent<Text>().text = "0" + MinCount + ":";
        else
            LapMinBox.GetComponent<Text>().text = "" + MinCount + ":";
    }

}
