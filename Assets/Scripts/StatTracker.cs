using UnityEngine;
using UnityEngine.UI;

public class StatTracker : MonoBehaviour
{
    public int score;
    public float time;
    public Text scoreText;
    public Text timeText;

    public void addScore()
    {
        score += 100;
        scoreText.text = score.ToString();
    }

    public void subtractScore()
    {
        score -= 50;
        scoreText.text = score.ToString();
    }

    public bool trackTime()
    {
        time -= Time.deltaTime;
        if (time < 100f) { timeText.color = Color.red; }
        if (time <= 0f) { return true; }
        timeText.text = time.ToString("0");
        return false;
    }
}
