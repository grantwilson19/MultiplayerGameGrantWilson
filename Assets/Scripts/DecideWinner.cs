using UnityEngine;
using TMPro;

public class DecideWinner : MonoBehaviour
{
    public ScoreKeeper player1ScoreKeeper;
    public ScoreKeeper player2ScoreKeeper;
    public TextMeshProUGUI resultText; // Reference to the TextMeshProUGUI component in your UI

    private void Start()
    {
        CompareScoresAndReact();
    }

    private void CompareScoresAndReact()
    {
        int player1Score = player1ScoreKeeper.GetScore();
        int player2Score = player2ScoreKeeper.GetScore();

        if (player1Score == player2Score)
        {
            // Scores are equal
            UpdateResultText("TIE GAME!");
        }
        else if (player1Score > player2Score)
        {
            // Player 1 has a higher score
            UpdateResultText("Knight Wins!");
        }
        else
        {
            // Player 2 has a higher score
            UpdateResultText("Mage Wins!");
        }
    }

    private void UpdateResultText(string newText)
    {
        if (resultText != null)
        {
            resultText.text = newText;
        }
    }
}
