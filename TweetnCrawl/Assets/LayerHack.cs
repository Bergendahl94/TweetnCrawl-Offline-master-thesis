﻿using UnityEngine;
using System.Collections;

public class LayerHack : MonoBehaviour {

    public int SortingLayerID;
    public int SortingOrder;
	
	void Update () {
        GetComponent<Renderer>().sortingLayerID = SortingLayerID;
        GetComponent<Renderer>().sortingOrder = SortingOrder;
	}
}
