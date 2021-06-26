using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public Text scoreText;
    // Update is called once per frame

    private void Start()
    {
        scoreText.text = "0";
    }

    private void Update()
    {
        scoreText.text = Score.scoreValue.ToString();
    }

}
