using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStoreActive : MonoBehaviour
{
    public GameObject store;
    // Start is called before the first frame update
    void Start()
    {
        store = GameObject.FindGameObjectWithTag("Store");
    }

    public void StoreYes()
    {
        store.SetActive(true);
    }

    public void StoreNo()
    {
        store.SetActive(false);
    }
}
