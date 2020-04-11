using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    #region Attributes
    [SerializeField]
    private float timeToDie;
    private float currentTime;
    #endregion

    private void Start()
    {
        currentTime = timeToDie;
    }//End Start

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            Destroy(gameObject);
        }//End if
    }//End Update
}
