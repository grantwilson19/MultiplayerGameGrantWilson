using UnityEngine;
using TMPro;
using Unity.Netcode;

public class Timer : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private NetworkVariable<float> remainingTime = new NetworkVariable<float>(300f);

    [SerializeField] private GameObject backgroundItem;
    [SerializeField] private GameObject timeItem;
    [SerializeField] private GameObject endMenu;

    private void Start()
    {
        if (IsServer)
        {
            endMenu.SetActive(false);
        }
    }

    private void Update()
    {
        if (IsServer)
        {
            UpdateTimerOnServer();
        }

        if (IsClient)
        {
            UpdateTimerUI(remainingTime.Value);
        }
    }

    private void UpdateTimerOnServer()
    {
        remainingTime.Value -= Time.deltaTime;
        backgroundItem.SetActive(true);
        timeItem.SetActive(true);

        if (remainingTime.Value <= 0)
        {
            EndTimer();
        }
    }

    private void EndTimer()
    {
        remainingTime.Value = 0;
        RpcShowEndMenuClientRpc();
        Time.timeScale = 0f;
    }

    [ClientRpc]
    private void RpcShowEndMenuClientRpc()
    {
        endMenu.SetActive(true);
    }

    private void UpdateTimerUI(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
