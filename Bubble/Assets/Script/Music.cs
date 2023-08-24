using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    static Music music = null;
    private void Awake()
    {
        if (music == null)
        {
            music = this;
            DontDestroyOnLoad(this);
        }
        else if (this != music)
        {
            Destroy(gameObject);
        }
    }

}
