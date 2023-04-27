using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LapComplete : MonoBehaviour {

    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public LapTimeManager lapTimeManager;
    
    public TextMeshProUGUI MinDisplayBest;
    public TextMeshProUGUI SecDisplayBest;
    public TextMeshProUGUI MilliDisplayBest;
    public TextMeshProUGUI LapCounterNumber;
    public TextMeshProUGUI MinuteDisplay;
    public TextMeshProUGUI SecondDisplay;
    public TextMeshProUGUI MilliDisplay;
    
    public GameObject LapTimeBox;

    

    void OnTriggerEnter() {

        float lapTime = LapTimeManager.MinuteCount * 60f + LapTimeManager.SecondCount + LapTimeManager.MilliCount / 1000f;

        // Check if this is the new best lap time
        if (lapTime < LapTimeManager.BestLapTime || LapTimeManager.BestLapTime == 0f) {
        LapTimeManager.BestLapTime = lapTime;
        LapTimeManager.BestMinuteCount = LapTimeManager.MinuteCount;
        LapTimeManager.BestSecondCount = LapTimeManager.SecondCount;
        LapTimeManager.BestMilliCount = LapTimeManager.MilliCount;

        // Update the best lap time display
        MinDisplayBest.text = LapTimeManager.BestMinuteCount.ToString("00") + ":";
        SecDisplayBest.text = LapTimeManager.BestSecondCount.ToString("00") + ".";
        MilliDisplayBest.text = LapTimeManager.BestMilliCount.ToString("F0");
        }


        // Update the lap time display
        if (LapTimeManager.SecondCount <= 9) {
            SecondDisplay.text = "0" + LapTimeManager.SecondCount + ".";
        } else {
            SecondDisplay.text = "" + LapTimeManager.SecondCount + ".";
        }

        if (LapTimeManager.MinuteCount <= 9) {
            MinuteDisplay.text = "0" + LapTimeManager.MinuteCount + ".";
        } else {
            MinuteDisplay.text = "" + LapTimeManager.MinuteCount + ".";
        }

            
        // Increment lap counter
        LapCounter.currentLap++;



        // Check if the player has completed the required number of laps
        if (LapCounter.currentLap >= lapTimeManager.MaxLaps) { // Use 'lapTimeManager.MaxLaps' instead of 'LapTimeManager.MaxLaps'
        // The player wins, load the victory scene
        SceneManager.LoadScene("WinScene");
    }

       

        MilliDisplay.text = "" + LapTimeManager.MilliCount;

        // Reset lap time counters
        LapTimeManager.MinuteCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MilliCount = 0;

        HalfLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);
    }
}