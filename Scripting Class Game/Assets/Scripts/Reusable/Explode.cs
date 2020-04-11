using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    #region Attributes
    [SerializeField]
    private GameObject explosion, destroyedObject;
    #endregion

    public void explode()
    {
        GameObject tempExplosion, tempDestroyedObject;
        tempExplosion = Instantiate(explosion, gameObject.transform);
        tempDestroyedObject = Instantiate(destroyedObject, gameObject.transform);
        tempExplosion.transform.parent = null;
        tempExplosion.transform.localScale = new Vector3(1f, 1f, 1f);
        tempDestroyedObject.transform.parent = null;
        Destroy(gameObject);
    }//End explode
}
