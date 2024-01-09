using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public void Log()
    {
    }

    public void TestMultipleParams(AnimationEvent e)
    {
        Debug.Log(e.floatParameter +" "+  e.objectReferenceParameter);
    }
}
