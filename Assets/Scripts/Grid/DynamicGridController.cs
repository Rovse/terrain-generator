﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicGridController : MonoBehaviour
{
    //Atributos
    public int width = 100;
    public int height = 100;
    public int length = 100;
    public float unitSize = 1;
    public bool drawVolume = true;

    private GridObject<GameObject> grid;

    //Metodo para crear la malla
    public void CreateGrid()
    {
        //Si no es nula la malla entonces la destruye
        if (grid != null)
            DestroyGrid();

        //Inicializa la malla con los parametros dados
        grid = new GridObject<GameObject>(length, width, height, unitSize, transform.position, null);
    }

    //Metodo para destruir la malla
    public void DestroyGrid()
    {
        //Recorre todas las casillas para destruirlas
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < length; z++)
                {
                    //Obtiene el objeto en la posicion
                    GameObject cube = grid.GetDataFromGridCoordinates(x, y, z);

                    //Comprueba si existe para destruirlo
                    if (cube)
                        Destroy(cube);
                }
            }
        }
    }

    //Metodo para dibujar la malla
    private void OnDrawGizmos()
    {
        //Solamente si puede dibujar
        if (drawVolume)
        {
            //Dibuja el plano xy de la malla
            for (int x = 1; x <= width; x++)
            {
                float xScaled = x * unitSize;

                for (int y = 1; y <= height; y++)
                {
                    float yScaled = y * unitSize;

                    Debug.DrawLine(new Vector3(transform.position.x + (xScaled - unitSize), transform.position.y + (yScaled - unitSize), transform.position.z), new Vector3(transform.position.x + xScaled, transform.position.y + (yScaled - unitSize), transform.position.z), Color.white);
                    Debug.DrawLine(new Vector3(transform.position.x + (xScaled - unitSize), transform.position.y + (yScaled - unitSize), transform.position.z), new Vector3(transform.position.x + (xScaled - unitSize), transform.position.y + yScaled, transform.position.z), Color.white);
                }
            }

            Debug.DrawLine(new Vector3(transform.position.x, transform.position.y + (height * unitSize), transform.position.z), new Vector3(transform.position.x + (width * unitSize), transform.position.y + (height * unitSize), transform.position.z), Color.white);
            Debug.DrawLine(new Vector3(transform.position.x + (width * unitSize), transform.position.y, transform.position.z), new Vector3(transform.position.x + (width * unitSize), transform.position.y + (height * unitSize), transform.position.z), Color.white);

            //Dibuja el otro plano xy de la malla
            for (int x = 1; x <= width; x++)
            {
                float xScaled = x * unitSize;

                for (int y = 1; y <= height; y++)
                {
                    float yScaled = y * unitSize;

                    Debug.DrawLine(new Vector3(transform.position.x + (xScaled - unitSize), transform.position.y + (yScaled - unitSize), transform.position.z + (length * unitSize)), new Vector3(transform.position.x + xScaled, transform.position.y + (yScaled - unitSize), transform.position.z + (length * unitSize)), Color.white);
                    Debug.DrawLine(new Vector3(transform.position.x + (xScaled - unitSize), transform.position.y + (yScaled - unitSize), transform.position.z + (length * unitSize)), new Vector3(transform.position.x + (xScaled - unitSize), transform.position.y + yScaled, transform.position.z + (length * unitSize)), Color.white);
                }
            }

            Debug.DrawLine(new Vector3(transform.position.x, transform.position.y + (height * unitSize), transform.position.z + (length * unitSize)), new Vector3(transform.position.x + (width * unitSize), transform.position.y + (height * unitSize), transform.position.z + (length * unitSize)), Color.white);
            Debug.DrawLine(new Vector3(transform.position.x + (width * unitSize), transform.position.y, transform.position.z + (length * unitSize)), new Vector3(transform.position.x + (width * unitSize), transform.position.y + (height * unitSize), transform.position.z + (length * unitSize)), Color.white);

            //Dibuja el plano yz de la malla
            for (int z = 1; z <= length; z++)
            {
                float zScaled = z * unitSize;

                for (int y = 1; y <= height; y++)
                {
                    float yScaled = y * unitSize;

                    Debug.DrawLine(new Vector3(transform.position.x + (width * unitSize), transform.position.y + (yScaled - unitSize), transform.position.z + (zScaled - unitSize)), new Vector3(transform.position.x + (width * unitSize), transform.position.y + (yScaled - unitSize), transform.position.z + zScaled), Color.white);
                    Debug.DrawLine(new Vector3(transform.position.x + (width * unitSize), transform.position.y + (yScaled - unitSize), transform.position.z + (zScaled - unitSize)), new Vector3(transform.position.x + (width * unitSize), transform.position.y + yScaled, transform.position.z + (zScaled - unitSize)), Color.white);
                }
            }

            Debug.DrawLine(new Vector3(transform.position.x + (width * unitSize), transform.position.y + (height * unitSize), transform.position.z), new Vector3(transform.position.x + (width * unitSize), transform.position.y + (height * unitSize), transform.position.z + (length * unitSize)), Color.white);

            //Dibuja el otro plano yz de la malla
            for (int z = 1; z <= length; z++)
            {
                float zScaled = z * unitSize;

                for (int y = 1; y <= height; y++)
                {
                    float yScaled = y * unitSize;

                    Debug.DrawLine(new Vector3(transform.position.x, transform.position.y + (yScaled - unitSize), transform.position.z + (zScaled - unitSize)), new Vector3(transform.position.x, transform.position.y + (yScaled - unitSize), transform.position.z + zScaled), Color.white);
                    Debug.DrawLine(new Vector3(transform.position.x, transform.position.y + (yScaled - unitSize), transform.position.z + (zScaled - unitSize)), new Vector3(transform.position.x, transform.position.y + yScaled, transform.position.z + (zScaled - unitSize)), Color.white);
                }
            }

            Debug.DrawLine(new Vector3(transform.position.x, transform.position.y + (height * unitSize), transform.position.z), new Vector3(transform.position.x, transform.position.y + (height * unitSize), transform.position.z + (length * unitSize)), Color.white);
        }
    }

    //Metodo para obtener el grid
    public GridObject<GameObject> Grid
    {
        get { return grid; }
    }
}
