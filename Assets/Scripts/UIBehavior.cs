using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIBehavior : MonoBehaviour
{
    public float timeLimit = 60f;

    public Text timeLimitText;
    public Text statsScreen;
    public UnityEngine.UI.Image statsBackground;

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;

        timeLimitText.text = "Time remaining: " + timeLimit.ToString("0.0");

        if (timeLimit <= 0f && Time.timeScale > 0f)
        {
            timeLimit = 0f;
            Time.timeScale = 0f;

            statsBackground.enabled = true;
            statsScreen.enabled = true;

            CrosshairBehavior crosshair = FindObjectOfType<CrosshairBehavior>();
            int shots = crosshair.shots;
            int hits = crosshair.hits;
            string statsText = "Time's up!"
                + "\n\nShots taken: " + shots
                + "\nHits: " + hits
                + "\nAccuracy: " + ((shots == 0)
                                    ? "didn't try"
                                    : (100f * hits / shots).ToString("0.0") + "%");
            
            if (hits > shots)
            {
                statsText += "\n(Wow!)"; // double hits ftw
            }

            statsScreen.text = statsText;

            // Destroy the crosshair so the player can't shoot anymore
            Destroy(crosshair.gameObject);
        }
    }
}
