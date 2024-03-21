using UnityEngine;
using TMPro;
using Unity.Netcode;

public class ScoreKeeper : NetworkBehaviour
{
    [SerializeField] private NetworkVariable<int> score = new NetworkVariable<int>(0); // Serialized field for the score
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component in your UI

    private void Start()
    {
        // Subscribe to changes in the score NetworkVariable
        score.OnValueChanged += OnScoreChanged;

        // Initialize the UI
        UpdateScoreUI(score.Value);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the NetworkVariable change event when the object is destroyed
        score.OnValueChanged -= OnScoreChanged;
    }

    // This method gets called automatically whenever the score changes
    private void OnScoreChanged(int oldValue, int newValue)
    {
        UpdateScoreUI(newValue);
    }

    // Call this method to increase the score
    public void IncreaseScore()
    {
        if (IsServer)
        {
            score.Value += 1; // Increase score by the specified amount
        }
        else
        {
            // If the client tries to modify the score, invoke an RPC on the server to handle it
            IncreaseScoreServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void IncreaseScoreServerRpc()
    {
        // Only the server should handle score modification
        if (IsServer)
        {
            score.Value += 1; // Increase score by the specified amount
        }
    }

    public int GetScore()
    {
        return score.Value;
    }

    private void UpdateScoreUI(int currentScore)
    {
        if (scoreText != null)
        {
            scoreText.text = currentScore.ToString();
        }
    }
}

