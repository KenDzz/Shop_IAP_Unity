using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownButton : MonoBehaviour
{
    public float countdownTime = 1800; // The countdown time in seconds
    private float currentTime = 0f; // The current time left
    private bool isCountingDown = false; // Flag to indicate if the countdown is active
    private Button button; // The UI button component
    public TextMeshProUGUI buttonAdstext;


    void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("TimeLeft", currentTime);
        PlayerPrefs.SetInt("isCountingDown", isCountingDown ? 1 : 0);
        PlayerPrefs.Save();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            PlayerPrefs.SetFloat("TimeLeft", currentTime);
            PlayerPrefs.SetInt("isCountingDown", isCountingDown ? 1 : 0);
            PlayerPrefs.Save();
        }
        else
        {
            currentTime = PlayerPrefs.GetFloat("TimeLeft", currentTime);
            isCountingDown = Convert.ToBoolean(PlayerPrefs.GetInt("isCountingDown"));

        }
    }

    private void Start()
    {
        currentTime = PlayerPrefs.GetFloat("TimeLeft", currentTime);
        isCountingDown = Convert.ToBoolean(PlayerPrefs.GetInt("isCountingDown"));
        button = GetComponent<Button>(); // Get the UI button component
        button.onClick.AddListener(StartCountdown); // Add a listener to the button's onClick event
    }

    private void Update()
    {
        if (isCountingDown)
        {
            button.interactable = false;
            currentTime -= Time.deltaTime; // Subtract the time that has passed
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            buttonAdstext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            if (currentTime <= 0)
            {
                button.interactable = true;
                buttonAdstext.text = "Watch Ads"; // Reset the button text
                isCountingDown = false; // Set the flag to false
            }
        }
    }

    private void StartCountdown()
    {
        if (!isCountingDown)
        {
            currentTime = countdownTime; // Set the current time to the countdown time
            isCountingDown = true; // Set the flag to true
        }
    }
}
