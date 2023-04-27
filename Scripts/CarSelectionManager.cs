using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelectionManager : MonoBehaviour
{
    public GameObject[] cars;
    public int currentCar;
    public bool inGameplayScene = false;
    public Image[] mapImages;

    void Start()
    {
        int selectedCar = PlayerPrefs.GetInt("SelectedCarID");
        
        if (inGameplayScene == true) {
            cars[selectedCar].SetActive(true);
            currentCar = selectedCar;
        }
        else 
        {
            UpdateMapImage();
        }

    }


    public void Right() {
        if (currentCar < cars.Length - 1) {
            currentCar += 1;
            for (int i = 0; i < cars.Length; i++)
            {
                if (currentCar < cars.Length) {
                    cars[i].gameObject.SetActive(false);
                    cars[currentCar].SetActive(true);
                }
            }
        }
        UpdateMapImage();
    }


    public void Left()
    {
        if (currentCar > 0)
        {
            currentCar -= 1;
            for (int i = 0; i < cars.Length; i++)
            {
                if (currentCar < cars.Length)
                {
                    cars[i].gameObject.SetActive(false);
                    cars[currentCar].SetActive(true);
                }
            }
        }
        UpdateMapImage();
    }

    public void Select() 
    {
    string sceneName = "Track" + (currentCar + 1).ToString();
    PlayerPrefs.SetInt("SelectedCarID", currentCar);
    SceneManager.LoadScene(sceneName);
    }

    private void UpdateMapImage() 
    {
        for (int i = 0; i < mapImages.Length; i++)
        {
            if (i == currentCar) 
            {
                mapImages[i].gameObject.SetActive(true);
            }
            else
            {
                mapImages[i].gameObject.SetActive(false);
            }

        }

    }

}
