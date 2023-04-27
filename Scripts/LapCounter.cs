using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapCounter : MonoBehaviour
{
    public static int currentLap = 0;
    public TextMeshProUGUI LapCounterNumber;

    private void Update()
    {
        LapCounterNumber.text = "Lap " + currentLap.ToString() + "/" + FindObjectOfType<LapTimeManager>().MaxLaps.ToString();
    }

    public static void ResetLapCounter() 
    {
        currentLap = 0;
    }
}
