using UnityEngine;
using Unity.Netcode;

public class PlayerData : NetworkBehaviour
{
    private bool _isServerPlayer = false;

    public bool isServerPlayer
    {
        get { return _isServerPlayer; }
        set
        {
            _isServerPlayer = value;
            OnServerPlayerChanged?.Invoke(value);
        }
    }

    public delegate void ServerPlayerChangedHandler(bool isServerPlayer);
    public event ServerPlayerChangedHandler OnServerPlayerChanged;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsLocalPlayer && IsServer)
        {
            isServerPlayer = true;
        }
    }
}
