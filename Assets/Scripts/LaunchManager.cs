using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    public GameObject EnterGamePanel;
    public GameObject ConnectionStatusPanel;
    public GameObject LobbyPanel;
    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        EnterGamePanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Public Methods
    public void ConnectToPhotonServer()
    {
        if(!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            ConnectionStatusPanel.SetActive(true);
            EnterGamePanel.SetActive(false);
        }
    }
    #endregion

    #region Photon Callbacks
    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.NickName + " Connected to Photon Server.");
        LobbyPanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
    }
    public override void OnConnected()
    {
        Debug.Log("Connected to Internet");

    }
    #endregion
}
