using UnityEngine;
using Photon.Pun;

public class DisableScripts : MonoBehaviourPunCallbacks
{

    [SerializeField] MonoBehaviour[] scriptsToDisable;

    PhotonView pView;

    void Start()
    {
        pView = GetComponent<PhotonView>();

        if (!pView.IsMine) DisableMonoScripts();
    }

    void DisableMonoScripts(){
        for (int i = 0; i < scriptsToDisable.Length; i++) 
            scriptsToDisable[i].enabled = false;
    }
}
