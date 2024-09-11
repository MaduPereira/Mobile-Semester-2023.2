using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConectaCabo : MonoBehaviour
{
   public LineRenderer[] lineRenderers; // Array de LineRenderers para os cabos
    public Transform[] startPoints;      // Array de pontos de início dos cabos
    public Transform[] endPoints;        // Array de pontos finais dos cabos

    private bool[] isDragging;            // Array para rastrear se cada cabo está sendo arrastado
    private Vector3[] touchPositions;     // Array para rastrear as posições dos toques
    private Collider2D[][] colliders;     // Array bidimensional para os colliders dos cabos e pontos de conexão
    private bool[] isConnected;           // Array para rastrear se cada cabo está conectado

    void Start()
    {
        int numCables = lineRenderers.Length;
        isDragging = new bool[numCables];
        touchPositions = new Vector3[numCables];
        colliders = new Collider2D[numCables][];
        isConnected = new bool[numCables];

        // Inicialize os arrays e configure o número de pontos de conexão corretamente
        for (int i = 0; i < numCables; i++)
        {
            lineRenderers[i].positionCount = 2;
            colliders[i] = new Collider2D[2];
        }
    }

    void Update()
    {
        for (int i = 0; i < lineRenderers.Length; i++)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        touchPositions[i] = Camera.main.ScreenToWorldPoint(touch.position);
                        touchPositions[i].z = 0;

                        // Verifique se o toque começou no ponto de início do cabo
                        if (colliders[i][0].OverlapPoint(touchPositions[i]))
                        {
                            isDragging[i] = true;
                        }
                        break;

                    case TouchPhase.Moved:
                        if (isDragging[i])
                        {
                            touchPositions[i] = Camera.main.ScreenToWorldPoint(touch.position);
                            touchPositions[i].z = 0;

                            lineRenderers[i].SetPosition(0, startPoints[i].position);
                            lineRenderers[i].SetPosition(1, touchPositions[i]);
                        }
                        break;

                    case TouchPhase.Ended:
                        if (isDragging[i])
                        {
                            // Verifique se o toque terminou em um ponto de conexão válido
                            if (colliders[i][1].OverlapPoint(touchPositions[i]))
                            {
                                isConnected[i] = true;
                                // Execute ações quando a conexão for bem-sucedida
                                OnConnect(i);
                            }
                            else
                            {
                                // Desconectar o cabo e redefinir a linha
                                Disconnect(i);
                            }

                            isDragging[i] = false;
                        }
                        break;
                }
            }
        }
    }

    private void Disconnect(int cableIndex)
    {
        lineRenderers[cableIndex].SetPosition(0, startPoints[cableIndex].position);
        lineRenderers[cableIndex].SetPosition(1, startPoints[cableIndex].position);
    }

    private void OnConnect(int cableIndex)
    {
        // Execute ações quando a conexão for bem-sucedida para o cabo especificado pelo índice cableIndex
    }
}
