using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviourPunCallbacks, IPunObservable
{
    bool isBeingDragged = false;
    Vector3 offset;
    GameObject objectBeingDragged;

    int playerPoints = 0;
    [SerializeField] LayerMask pontuableObjectLayer; // Camada para objetos que concedem os pontos

    RoomManager roomManager;

    PhotonView pview;

    void Awake() {
        pview = GetComponent<PhotonView>();
    }

    void Start()
    {
        roomManager = FindObjectOfType<RoomManager>();
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Collider2D collider = null;

            if (touch.phase == TouchPhase.Began)
            {
                collider = GetColliderFromTouch(touch.position);
                OnTouchDown(collider);

                if(RoomManager.canvaInfo == true)
                {
                    RoomManager.canvaInfo = false;
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                OnTouchUp();
            }
        }

        if (isBeingDragged && objectBeingDragged != null)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            objectBeingDragged.transform.position = new Vector3(touchPosition.x + offset.x, touchPosition.y + offset.y, objectBeingDragged.transform.position.z);

            Collider2D collisionTrash = Physics2D.OverlapPoint(objectBeingDragged.transform.position, pontuableObjectLayer);
            // Verificar colisão com objeto pontuável usando OverlapPoint
            if (collisionTrash != null)
            {
                OnPontuableObjectCollision(collisionTrash.gameObject.tag);
            }

        }
    }

    void OnPontuableObjectCollision(string tag)
    {
        if (!pview.IsMine) return;

        playerPoints = Mathf.Clamp(playerPoints + GetPointsFromCollision(tag), 0, 9999); 

        int playerNumber = pview.OwnerActorNr;
        roomManager.UpdatePoints(playerNumber, playerPoints);

        if (objectBeingDragged != null)
        {
            if(PhotonNetwork.IsMasterClient)
                PhotonNetwork.Destroy(objectBeingDragged);
            else
                pview.RPC("DestroyObject", RpcTarget.MasterClient, objectBeingDragged.GetPhotonView().ViewID);
            objectBeingDragged = null;
        }
    }

    [PunRPC]
    void DestroyObject(int viewID)
    {
        PhotonNetwork.Destroy(PhotonView.Find(viewID));
    }

    int GetPointsFromCollision(string tag){
        
        // Se colocar o lixo na lixeira correta, ganha 1 ponto
        // Se colocar o lixo na lixeira errada, perde 1 ponto

        TrashType trashType =  objectBeingDragged.GetComponent<DraggableTag>().trashType;
        
        int _points = -1;
        
        if(
            tag == "LixeiraAzul" && trashType == TrashType.BLUE || 
            tag == "LixeiraAmarela" && trashType == TrashType.YELLOW || 
            tag == "LixeiraVerde"  && trashType == TrashType.GREEN || 
            tag == "LixeiraVermelha" && trashType == TrashType.RED || 
            tag == "LixeiraMarrom" && trashType == TrashType.BROW
        )
            _points = 1;

        return _points;
    }

    void OnTouchDown(Collider2D collider)
    {
        if (!pview.IsMine)
        {
            return;
        }

        if (collider?.GetComponent<DraggableTag>() != null)
        {
            isBeingDragged = true;
            objectBeingDragged = collider.gameObject;
            offset = objectBeingDragged.transform.position - Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
    }

    void OnTouchUp()
    {
        if (!pview.IsMine || !isBeingDragged)
        {
            return;
        }

        isBeingDragged = false;

        pview.RPC("SyncPosition", RpcTarget.All, objectBeingDragged.transform.position);

        objectBeingDragged = null;
    }

    Collider2D GetColliderFromTouch(Vector2 touchPosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touchPosition), Vector2.zero);
        if (hit.collider != null)
        {
            return hit.collider;
        }
        return null;
    }

    [PunRPC]
    void SyncPosition(Vector3 newPosition)
    {
        if (pview.IsMine)
        {
            return;
        }
        if(objectBeingDragged == null) return;        
        objectBeingDragged.transform.position = newPosition;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {        
            if(objectBeingDragged == null) return;
            stream.SendNext(objectBeingDragged.transform.position);
        }
        else
        {                            
            if(objectBeingDragged == null) return;
            objectBeingDragged.transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}
