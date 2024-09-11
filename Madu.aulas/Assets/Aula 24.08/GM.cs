using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public GameObject winText;
    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vaca.verifica && Rato.verifica && Tucano.verifica && Tigre.verifica)
        {
            winText.SetActive(true);
        }
    }
}
