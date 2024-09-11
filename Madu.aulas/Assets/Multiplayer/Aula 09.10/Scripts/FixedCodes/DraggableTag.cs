using UnityEngine;

public enum TrashType 
{
    BLUE, GREEN, RED, YELLOW, BROW
}

public class DraggableTag : MonoBehaviour
{

    public TrashType trashType = TrashType.BLUE;

    void Update()
    {
        transform.position += Vector3.down * 2f * Time.deltaTime;
    }
}
