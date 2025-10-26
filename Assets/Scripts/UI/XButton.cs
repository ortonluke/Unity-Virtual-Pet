using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XButton : MonoBehaviour
{
    private GameObject menuObject;

    // Start is called before the first frame update
    void Start()
    {
        menuObject = transform.parent.gameObject;
    }

    public void destroyMenu()
    {
        Destroy(menuObject);
    }
}
