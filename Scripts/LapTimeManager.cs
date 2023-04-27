using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapTimeManager : MonoBehaviour {

    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;
    public static string MilliDisplay;

    public static float BestLapTime = 0f;
    public static int BestMinuteCount;
    public static int BestSecondCount;
    public static float BestMilliCount;

    [SerializeField] //Attribute to make the field adjustable in the Unity Editor
    public int MaxLaps = 3;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;

    void Update() {
        MilliCount += Time.deltaTime * 10;
        MilliDisplay = MilliCount.ToString("F0");
        MilliBox.GetComponent<TextMeshProUGUI>().text = "" + MilliDisplay;

        if (MilliCount >= 10) {
            MilliCount = 0;
            SecondCount += 1;
        }

        if (SecondCount <= 9) {
            SecondBox.GetComponent<TextMeshProUGUI>().text = "0" + SecondCount + ".";
        } else {
            SecondBox.GetComponent<TextMeshProUGUI>().text = "" + SecondCount + ".";
        }

        if (SecondCount >= 60) {
            SecondCount = 0;
            MinuteCount += 1;
        }

        if (MinuteCount <= 9) {
            MinuteBox.GetComponent<TextMeshProUGUI>().text = "0" + MinuteCount + ":";
        } else {
            MinuteBox.GetComponent<TextMeshProUGUI>().text = "" + MinuteCount + ":";
        }
    }
}
