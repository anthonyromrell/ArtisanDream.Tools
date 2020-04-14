using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerContoller : MonoBehaviour
{

    public void ChangeLayer(int layerNum)
    {
        gameObject.layer = layerNum;
    }
}
