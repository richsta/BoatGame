using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("BoatGame"); //(SceneManager.GetSceneAt(0).name);
        }

        if (other.gameObject.tag == "Bullet")
        {

            Debug.Log("YES ENTER");
            GameObject.Find("An Unassuming Box").GetComponent<ObstacleManager>().enemyHit(this.gameObject);
        }
    }


}
