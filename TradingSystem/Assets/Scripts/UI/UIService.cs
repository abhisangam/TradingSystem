using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIService : MonoBehaviour
{
    private static UIService instance;
    public static UIService Instance { get { return instance; } private set { } }

    public QuickInfo quickInfo;
    public WarningPopup warningPopup;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
