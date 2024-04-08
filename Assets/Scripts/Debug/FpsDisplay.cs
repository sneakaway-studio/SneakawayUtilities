using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

/// <summary>
/// Credit: Christian Floisand
/// https://github.com/cfloisand/BeatSynchronizer/blob/master/Assets/Scripts/FpsDisplay.cs
/// </summary>

[RequireComponent(typeof(TMP_Text))]
public class FpsDisplay : MonoBehaviour
{
    public Image background;
    public TMP_Text text;
    public float updateInterval = 0.5f;

    private int frameCount;
    private float accumTime;
    private float timeLeft;


    void Start()
    {
        if (background == null) background = GetComponentInParent<Image>();
        if (text == null) text = GetComponent<TMP_Text>();
        timeLeft = updateInterval;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        accumTime += Time.timeScale / Time.deltaTime;
        ++frameCount;

        if (timeLeft <= 0f)
        {
            float fps = accumTime / frameCount;
            string fpsDisplay = System.String.Format("{0:F2} fps", fps);
            text.text = fpsDisplay;

            if (fps < 30)
                background.color = Color.yellow;
            else if (fps < 10)
                background.color = Color.red;
            else
                background.color = Color.green;

            timeLeft = updateInterval;
            accumTime = 0f;
            frameCount = 0;
        }
    }

}