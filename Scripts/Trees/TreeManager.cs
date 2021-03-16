using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public float TreeWoodCount { get { return treeWoodCount; } }
    private int treeWoodCount;
    public float treeRefreshDelay = 10f;

    public bool isTreeFinished;
    public Transform logDropPosition;
    public Transform logParent;
    
    [SerializeField]
    private int treeStartWoodCount = 15;
    
    GameObject logPrefab;
    GameObject leafParticle;

    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        treeWoodCount = treeStartWoodCount;
        leafParticle = Resources.Load<GameObject>("Tree/LeafParticle");
        logPrefab = Resources.Load<GameObject>("Tree/WoodLog");
    }

    public void DecreaseWoodCount(int decreaseAmount)
    {
        treeWoodCount = treeWoodCount - decreaseAmount;
        PlayerController.Instance.wood.amount += Mathf.RoundToInt(decreaseAmount);
        Instantiate(logPrefab, logDropPosition.position, Quaternion.identity,logParent);
        Instantiate(leafParticle, transform.position, Quaternion.identity, transform);
        

        if (treeWoodCount <= 0)
        {
            isTreeFinished = true;
            DisableAndRefreshAfterDelay(treeRefreshDelay);
        }
    }

    public void DestroyFinishedTree()
    {
        gameObject.SetActive(false);
    }
    private void DisableAndRefreshAfterDelay(float delay)
    {
        StartCoroutine(CR_DisableAndRefreshAfterDelay(delay));
    }
    private IEnumerator CR_DisableAndRefreshAfterDelay(float delay)
    {

        Collider[] colliders = GetComponentsInChildren<Collider>();
        Renderer treeRenderer = GetComponent<Renderer>();
        GetComponent<Rigidbody>().isKinematic = true;
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }

        treeRenderer.enabled = false;
        yield return new WaitForSeconds(delay);

        foreach (Collider collider in colliders)
        {
            collider.enabled = true;

        }

        GetComponent<Rigidbody>().isKinematic = false;
        transform.position = initialPosition;
        treeWoodCount = treeStartWoodCount;
        treeRenderer.enabled = true;
        isTreeFinished = false;
    }
}
