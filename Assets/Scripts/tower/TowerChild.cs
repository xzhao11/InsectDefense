using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerChild : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        transform.parent.GetComponent<tower>().OnMouseDown();
    }
}
