using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour
{
    
    private static bool isLoad = false;
    private void Awake()
    {
        if (isLoad)
        {
            Destroy(this.gameObject);
            return;
        }
    isLoad = true;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
