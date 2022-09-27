using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InputLocal : MonoBehaviour
{
#if PLATFORM_STANDALONE_WIN || UNITY_EDITOR

    [SerializeField] KeyCode foward;
    [SerializeField] KeyCode back;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;


    float Horizontal;
    float Vertical;

    void Update()
    {
        Horizontal = 0;
        Vertical = 0;
        if (Input.GetKey(left))
        {
            Horizontal = -1;
        }
        if (Input.GetKey(right))
        {
            Horizontal = 1;
        }
        if (Input.GetKey(foward))
        {
            Vertical = 1;
        }
        if (Input.GetKey(back))
        {
            Vertical = -1;
        }

    }

    public float GetHorizontal()
    {
        return Horizontal;
    }

    public float getvertical()
    {
        return Vertical;
    }
#endif
}
