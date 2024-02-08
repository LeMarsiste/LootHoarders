using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

/*
	Documentation: https://mirror-networking.gitbook.io/docs/components/network-manager
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkManager.html
*/

public class LootNetworkManager : NetworkManager
{
    // You can adjust the parameters of the Actions below to suit your needs and pass the values through the Invoke() method.

    public event Action OnStartAction;
    public event Action OnDestroyAction;

    public event Action OnApplicationQuitAction;

    public event Action<string> ServerChangeSceneAction;
    public event Action<string> OnServerChangeSceneAction;
    public event Action<string> OnServerSceneChangedAction;
    public event Action<string, SceneOperation, bool> OnClientChangeSceneAction;
    public event Action OnClientSceneChangedAction;

    public event Action<NetworkConnectionToClient> OnServerConnectAction;
    public event Action<NetworkConnectionToClient> OnServerReadyAction;
    public event Action<NetworkConnectionToClient> OnServerAddPlayerAction;
    public event Action<NetworkConnectionToClient> OnServerDisconnectAction;
    public event Action<NetworkConnectionToClient, TransportError, string> OnServerErrorAction;

    public event Action OnClientConnectAction;
    public event Action OnClientDisconnectAction;
    public event Action OnClientNotReadyAction;
    public event Action<ConnectionQuality, ConnectionQuality> OnConnectionQualityChangedAction;
    public event Action<TransportError, string> OnClientErrorAction;

    public event Action OnStartServerAction;
    public event Action OnStopServerAction;
    public event Action OnStartHostAction;
    public event Action OnStopHostAction;
    public event Action OnStartClientAction;
    public event Action OnStopClientAction;

    // Overrides the base singleton so we don't have to cast to this type everywhere.
    public static new LootNetworkManager singleton => (LootNetworkManager)NetworkManager.singleton;

    /// <summary>
    /// Runs on both Server and Client
    /// Networking is NOT initialized when this fires
    /// </summary>
    public override void Awake()
    {
        base.Awake();

        // Example of adding a handler for the OnStartAction
        // Multiple handlers can be added for actions
        // Use -= to remove handlers
        // Set the action to null to remove all handlers
        OnStartAction += OnStartedActionHandler;

    }

    /// <summary>
    /// Example handler for OnStartAction
    /// </summary>
    /// <remarks>Handlers can be assigned from, and exist, in any script</remarks>
    public void OnStartedActionHandler()
    {
        Debug.Log("LootNetworkManager.OnStartAction invoked");
    }

    #region Public Methods
    public void SetIP(string IP)
    {
        networkAddress = IP;
    }
    public void JoinAsHost()
    {
        StartHost();
    }
    public void JoinAsClient()
    {
        StartClient();
    }
    #endregion

    #region Unity Callbacks

    public override void OnValidate()
    {
        base.OnValidate();
    }

    /// <summary>
    /// Runs on both Server and Client
    /// Networking is NOT initialized when this fires
    /// </summary>
    public override void Start()
    {
        OnStartAction?.Invoke();
        base.Start();
    }

    /// <summary>
    /// Runs on both Server and Client
    /// </summary>
    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    /// <summary>
    /// Runs on both Server and Client
    /// </summary>
    public override void OnDestroy()
    {
        OnDestroyAction?.Invoke();
        base.OnDestroy();
    }

    #endregion

    #region Start & Stop

    /// <summary>
    /// Set the frame rate for a headless server.
    /// <para>Override if you wish to disable the behavior or set your own tick rate.</para>
    /// </summary>
    public override void ConfigureHeadlessFrameRate()
    {
        base.ConfigureHeadlessFrameRate();
    }

    /// <summary>
    /// called when quitting the application by closing the window / pressing stop in the editor
    /// </summary>
    public override void OnApplicationQuit()
    {
        OnApplicationQuitAction?.Invoke();
        base.OnApplicationQuit();
    }

    #endregion

    #region Scene Management

    /// <summary>
    /// This causes the server to switch scenes and sets the networkSceneName.
    /// <para>Clients that connect to this server will automatically switch to this scene. This is called automatically if onlineScene or offlineScene are set, but it can be called from user code to switch scenes again while the game is in progress. This automatically sets clients to be not-ready. The clients must call NetworkClient.Ready() again to participate in the new scene.</para>
    /// </summary>
    /// <param name="newSceneName"></param>
    public override void ServerChangeScene(string newSceneName)
    {
        ServerChangeSceneAction?.Invoke(newSceneName);
        base.ServerChangeScene(newSceneName);
    }

    /// <summary>
    /// Called from ServerChangeScene immediately before SceneManager.LoadSceneAsync is executed
    /// <para>This allows server to do work / cleanup / prep before the scene changes.</para>
    /// </summary>
    /// <param name="newSceneName">Name of the scene that's about to be loaded</param>
    public override void OnServerChangeScene(string newSceneName)
    {
        OnServerChangeSceneAction?.Invoke(newSceneName);
    }

    /// <summary>
    /// Called on the server when a scene is completed loaded, when the scene load was initiated by the server with ServerChangeScene().
    /// </summary>
    /// <param name="sceneName">The name of the new scene.</param>
    public override void OnServerSceneChanged(string sceneName)
    {
        OnServerSceneChangedAction?.Invoke(sceneName);
    }

    /// <summary>
    /// Called from ClientChangeScene immediately before SceneManager.LoadSceneAsync is executed
    /// <para>This allows client to do work / cleanup / prep before the scene changes.</para>
    /// </summary>
    /// <param name="newSceneName">Name of the scene that's about to be loaded</param>
    /// <param name="sceneOperation">Scene operation that's about to happen</param>
    /// <param name="customHandling">true to indicate that scene loading will be handled through overrides</param>
    public override void OnClientChangeScene(string newSceneName, SceneOperation sceneOperation, bool customHandling)
    {
        OnClientChangeSceneAction?.Invoke(newSceneName, sceneOperation, customHandling);
    }

    /// <summary>
    /// Called on clients when a scene has completed loaded, when the scene load was initiated by the server.
    /// <para>Scene changes can cause player objects to be destroyed. The default implementation of OnClientSceneChanged in the NetworkManager is to add a player object for the connection if no player object exists.</para>
    /// </summary>
    public override void OnClientSceneChanged()
    {
        OnClientSceneChangedAction?.Invoke();
        base.OnClientSceneChanged();
    }

    #endregion

    #region Server System Callbacks

    /// <summary>
    /// Called on the server when a new client connects.
    /// <para>Unity calls this on the Server when a Client connects to the Server. Use an override to tell the NetworkManager what to do when a client connects to the server.</para>
    /// </summary>
    /// <param name="conn">Connection from client.</param>
    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        OnServerConnectAction?.Invoke(conn);
    }

    /// <summary>
    /// Called on the server when a client is ready.
    /// <para>The default implementation of this function calls NetworkServer.SetClientReady() to continue the network setup process.</para>
    /// </summary>
    /// <param name="conn">Connection from client.</param>
    public override void OnServerReady(NetworkConnectionToClient conn)
    {
        OnServerReadyAction?.Invoke(conn);
        base.OnServerReady(conn);
    }

    /// <summary>
    /// Called on the server when a client adds a new player with ClientScene.AddPlayer.
    /// <para>The default implementation for this function creates a new player object from the playerPrefab.</para>
    /// </summary>
    /// <param name="conn">Connection from client.</param>
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        OnServerAddPlayerAction?.Invoke(conn);
        base.OnServerAddPlayer(conn);
    }

    /// <summary>
    /// Called on the server when a client disconnects.
    /// <para>This is called on the Server when a Client disconnects from the Server. Use an override to decide what should happen when a disconnection is detected.</para>
    /// </summary>
    /// <param name="conn">Connection from client.</param>
    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        OnServerDisconnectAction?.Invoke(conn);
        base.OnServerDisconnect(conn);
    }

    /// <summary>
    /// Called on server when transport raises an error.
    /// <para>NetworkConnection may be null.</para>
    /// </summary>
    /// <param name="conn">Connection of the client...may be null</param>
    /// <param name="transportError">TransportError enum</param>
    /// <param name="message">String message of the error.</param>
    public override void OnServerError(NetworkConnectionToClient conn, TransportError transportError, string message)
    {
        OnServerErrorAction?.Invoke(conn, transportError, message);
    }

    #endregion

    #region Client System Callbacks

    /// <summary>
    /// Called on the client when connected to a server.
    /// <para>The default implementation of this function sets the client as ready and adds a player. Override the function to dictate what happens when the client connects.</para>
    /// </summary>
    public override void OnClientConnect()
    {
        OnClientConnectAction?.Invoke();
        base.OnClientConnect();
    }

    /// <summary>
    /// Called on clients when disconnected from a server.
    /// <para>This is called on the client when it disconnects from the server. Override this function to decide what happens when the client disconnects.</para>
    /// </summary>
    public override void OnClientDisconnect()
    {
        OnClientDisconnectAction?.Invoke();
    }

    /// <summary>
    /// Called on clients when a servers tells the client it is no longer ready.
    /// <para>This is commonly used when switching scenes.</para>
    /// </summary>
    public override void OnClientNotReady()
    {
        OnClientNotReadyAction?.Invoke();
    }

    /// <summary>
    /// Called on client when connection quality changes. Override to show your own warnings or UI visuals.
    /// </summary>
    public override void CalculateConnectionQuality()
    {
        base.CalculateConnectionQuality();
    }

    /// <summary>
    /// Called on client when connection quality changes. Override to show your own warnings or UI visuals.
    /// </summary>
    /// <param name="previous">previous connection quality</param>
    /// <param name="current">new connection quality</param>
    public override void OnConnectionQualityChanged(ConnectionQuality previous, ConnectionQuality current)
    {
        OnConnectionQualityChangedAction?.Invoke(previous, current);
        base.OnConnectionQualityChanged(previous, current);
    }

    /// <summary>
    /// Called on client when transport raises an error.</summary>
    /// </summary>
    /// <param name="transportError">TransportError enum.</param>
    /// <param name="message">String message of the error.</param>
    public override void OnClientError(TransportError transportError, string message)
    {
        OnClientErrorAction?.Invoke(transportError, message);
    }

    #endregion

    #region Start & Stop Callbacks

    // Since there are multiple versions of StartServer, StartClient and StartHost, to reliably customize
    // their functionality, users would need override all the versions. Instead these callbacks are invoked
    // from all versions, so users only need to implement this one case.

    /// <summary>
    /// This is invoked when a server is started - including when a host is started.
    /// <para>StartServer has multiple signatures, but they all cause this hook to be called.</para>
    /// </summary>
    public override void OnStartServer()
    {
        OnStartServerAction?.Invoke();
    }

    /// <summary>
    /// This is called when a server is stopped - including when a host is stopped.
    /// </summary>
    public override void OnStopServer()
    {
        OnStopServerAction?.Invoke();
    }

    /// <summary>
    /// This is invoked when a host is started.
    /// <para>StartHost has multiple signatures, but they all cause this hook to be called.</para>
    /// </summary>
    public override void OnStartHost()
    {
        OnStartHostAction?.Invoke();
    }

    /// <summary>
    /// This is called when a host is stopped.
    /// </summary>
    public override void OnStopHost()
    {
        OnStopHostAction?.Invoke();
    }

    /// <summary>
    /// This is invoked when the client is started.
    /// </summary>
    public override void OnStartClient()
    {
        OnStartClientAction?.Invoke();
    }

    /// <summary>
    /// This is called when a client is stopped.
    /// </summary>
    public override void OnStopClient()
    {
        OnStopClientAction?.Invoke();
    }

    #endregion
}
