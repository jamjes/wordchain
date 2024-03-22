using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysPooler : MonoBehaviour
{

    #region Attributes

    public Key[] allKeys;

    #endregion

    #region Methods

    public Key RequestAppend()
    {
        foreach(Key key in allKeys)
        {
            if (!key.gameObject.activeInHierarchy)
            {
                key.gameObject.SetActive(true);
                return key;
            }
        }

        return null;
    }

    public void RequestRemove(Key key)
    {
        key.gameObject.SetActive(false);
    }

    #endregion

}
