using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject[] firstObjects;
    public GameObject[] secondObjects;
    public Mesh[] meshes = new Mesh[2];
    private Vector3[] colliderSizes = new Vector3[2];
    int actualShape = 0;
    MeshFilter _meshFilter;
    BoxCollider _boxCollider;
    void Start()
    {
        colliderSizes[0] = new Vector3(1, 1, 1);
        colliderSizes[1] = new Vector3(1, 0.5f, 1);
        _meshFilter = GetComponent<MeshFilter>();
        _meshFilter.sharedMesh = meshes[actualShape];
        _boxCollider = GetComponent<BoxCollider>();
        for (int i = 0; i < firstObjects.Length; ++i)
        {
            firstObjects[i].SetActive(true);
        }
        for (int i = 0; i < secondObjects.Length; ++i)
        {
            secondObjects[i].SetActive(false);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            actualShape = (actualShape + 1) % 2;
            if (actualShape == 1) GameSounds.Instance.playButtonOn();
            else GameSounds.Instance.playButtonOff();
            _meshFilter.sharedMesh = meshes[actualShape];
            _boxCollider.size = colliderSizes[actualShape];
            for (int i = 0; i < firstObjects.Length; ++i)
            {
                firstObjects[i].SetActive(!firstObjects[i].activeSelf);
            }
            for (int i = 0; i < secondObjects.Length; ++i)
            {
                secondObjects[i].SetActive(!secondObjects[i].activeSelf);
            }
        }
    }
}
