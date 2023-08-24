using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    static Music music = null;

    [SerializeField]
    Texture2D cursorArrow;


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
    private void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
  

}
