using UnityEngine;
using Unity.Netcode;

public class PlayerSpawner : NetworkBehaviour
{
    public GameObject hostPrefab;
    public GameObject clientPrefab;
    public GameObject timerPrefab;
    public GameObject hostUIPrefab; // UI for the host
    public GameObject clientUIPrefab; // UI for the client
    public bool hostConnected = false;

    // Define spawn positions for each prefab
    public Vector3 hostSpawnPosition = Vector3.zero;
    public Vector3 clientSpawnPosition = Vector3.zero;

    private void Start()
    {
        Debug.Log("PlayerSpawner Start method called.");

        NetworkManager.Singleton.OnServerStarted += HandleServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
    }

    public override void OnDestroy()
    {
        NetworkManager.Singleton.OnServerStarted -= HandleServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback -= HandleClientConnected;
        base.OnDestroy(); // Call the base class method
    }

    private void HandleServerStarted()
    {
        Debug.Log("Server started. Host ClientId: " + NetworkManager.Singleton.LocalClientId);

        if (IsServer && IsHost)
        {
            Debug.Log("Server is host. Spawning host player...");
            SpawnPlayer(hostPrefab, hostSpawnPosition, 0);
            SpawnUI(hostUIPrefab); // Spawn host UI
            hostConnected = true;
        }

        if (IsServer) {
            GameObject timerObject = Instantiate(timerPrefab);
            timerObject.GetComponent<NetworkObject>().Spawn();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void SpawnPlayerOnServerRpc(Vector3 position)
    {
        ulong clientId = NetworkManager.Singleton.LocalClientId;
        Debug.Log("Received request to spawn player from client with ClientId: " + GetClientId());
        SpawnPlayer(clientPrefab, position, 1);
    }

    private void HandleClientConnected(ulong clientId)
    {
        Debug.Log("HandleClientConnected method called. Connected ClientId: " + clientId);

        if (IsClient && !IsServer)
        {
            Debug.Log("Client is connecting.");

            // Call the Server RPC to spawn the player on the server
            SpawnPlayerOnServerRpc(clientSpawnPosition);
            SpawnUI(clientUIPrefab);
        }
    }

    private ulong GetClientId()
    {
        return NetworkManager.Singleton.LocalClientId;
    }

    private void SpawnPlayer(GameObject prefab, Vector3 position, ulong clientId)
    {
        Debug.Log("Spawning player object...");

        GameObject playerObject = Instantiate(prefab, position, Quaternion.identity);

        // Check if we are on the server before attempting to spawn a NetworkObject
        if (IsServer)
        {
            playerObject.GetComponent<NetworkObject>().SpawnWithOwnership(clientId);
            Debug.Log("Player spawned successfully.");
        }
        else
        {
            Debug.LogWarning("Trying to spawn NetworkObject on a client. Only the server can spawn NetworkObjects.");
        }
    }

    private void SpawnUI(GameObject uiPrefab)
    {
        if (IsHost)
        {
            Instantiate(uiPrefab); // Spawn UI for the host
        }
        else if (IsClient)
        {
            Instantiate(uiPrefab); // Spawn UI for the client
        }
    }
}
