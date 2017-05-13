using UnityEngine;
using System.Collections;

public class BulletColl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {

            Debug.Log("YES ENTER");
            GameObject.Find("An Unassuming Box").GetComponent<ObstacleManager>().enemyHit(coll.gameObject);
        }
    }
}
