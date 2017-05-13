using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObstacleManager : MonoBehaviour
{
    public Text objective;
    public GameObject[] enemies;
    public GameObject anim;
    GameObject[] getCount;

    public LoseMenu loseMenu;
    public LoseMenu winMenu;
    private char[] enemyNums;

    // Use this for initialization
    void Start()
    {
        Debug.Log(FrameworkCore.currentContent.getTerm());
        objective.text = FrameworkCore.currentContent.getTerm();
        Debug.Log(objective.text);
        enemyNums = new char[enemies.Length];

        Debug.Log("CHEKKK BEFORE" + enemyNums[0]);
        for (int i = 0; i < enemies.Length; i++)
        {
            generateEnemy(i);
        }
    }

    private void generateEnemy(int index)
    {
       // Debug.Log("checking value of instantiated enemyNums"+enemyNums[index]);
        //while (enemyNums[index] != 'A' || enemyNums[index] != 'B' || enemyNums[index] != 'C' )
        {
            enemyNums[index] = getRandomUniqueItem(enemyNums);

            Debug.Log("CHEKKK" + enemyNums[0]);

            Debug.Log("CHEKKK" + enemyNums[1]);
            Debug.Log("CHEKKK" + enemyNums[2]);
            makeEnemy(enemies[index], enemyNums[index]);
        }

        Debug.Log("checking value of instantiated enemyNums" + enemyNums[index]);
    }

    private char getRandomUniqueItem(char[] check) {
        char temp = FrameworkCore.currentContent.getItem();
        for (int i = 0; i < check.Length; i++)
        {
            if (temp == check[i])
            {
                return getRandomUniqueItem(check);
                
            }
            
        }
        Debug.Log("checking random enemyNums" + temp);
        Debug.Log("TEMP CHARARRAY" + check);
        return temp;
    }

    private void makeEnemy(GameObject enemy, char item)
    {
        string itemText;
        //int[] xPos = {-358, 110, 358 };
        GameObject temp = (GameObject)Instantiate(enemy, GetNextPos(), Quaternion.identity);

        //GameObject temp = (GameObject)Instantiate(enemy, new Vector3(xPos[Random.Range(0, 3)], 12.5f, Random.Range(360, 560)), Quaternion.identity);
        Debug.Log("CHECKING RANDOM");
        //GameObject temp = (GameObject)Instantiate(enemy, new Vector3(Random.Range(-358, 377), 12.5f, Random.Range(360, 560)), Quaternion.identity);
        switch (item)
        {
            case 'A':
                itemText = "A. America discovered";
                break;
            case 'B':
                itemText = "B. Independence";
                break;
            case 'C':
                itemText = "C. Civil War";
                break;
            default:
                itemText = null;
                break;
        }
        temp.GetComponentInChildren<TextMesh>().text = "" + itemText; //Add text mesh to the iceberg TODO
    }

    private Vector3 GetNextPos() {
        int[] xPos = { -358, 110, 377 };
        int xRand = Random.Range(0, 3);
        Vector3 spawnPos = new Vector3(xPos[xRand], 12.5f, 460f); //Random.Range(360, 560));
        float radius = 2.0f;

        if (Physics.CheckSphere(spawnPos, radius))
        {

            Vector3 newSpawnPos = GetNextPos();//new Vector3(xPos[xRand+1], 12.5f, Random.Range(360, 560));
            return newSpawnPos;
        }
        else {
            return spawnPos;
        }

    }

    public void enemyHit(GameObject enemy)
    {
        int index = -1;
        Debug.Log("Check ENTER enemyhit");
        for (int i = 0; i < enemyNums.Length; i++)
        {
            TextMesh temp = enemy.GetComponentInChildren<TextMesh>();
            //Debug.Log("Check temp--" + temp.text.ToCharArray()[0]);
            if (temp != null)
            {
                Debug.Log("check enemynums" +enemyNums[i]);
                Debug.Log(temp.text.ToCharArray()[0]);
                if (enemyNums[i] == temp.text.ToCharArray()[0])
                {
                    index = i;
                    //for (int a = 0; a < enemyNums.Length; a++)
                   // {
                     //   char[] solution = enemyNums[index].ToCharArray();
                    //}
                    }
                }
        }

        if (index != -1)
        {
            TitanicalMechanics temp = (TitanicalMechanics)GameInfo.currentMechanics;
            temp.sendHook(enemyNums[index], enemyNums, objective.text);
            Debug.Log(enemyNums[index]);
            Debug.Log("check sending"+enemyNums);
            if (FrameworkCore.currentContent.wasLastActionValid())
            {
                Debug.Log("LAST ACTION VALID");
                Vector3 oldPosition = enemy.transform.position;
                Instantiate(anim, oldPosition, Quaternion.identity);
                Destroy(enemy); //(enemies[index]);

                Destroy(GameObject.Find("Boat"));
                //generateEnemy(index);
                //objective.text = FrameworkCore.currentContent.getTerm();
                winMenu.ToggleEndMenu();
            }
            else {
                Vector3 oldPosition = enemy.transform.position;
                Instantiate(anim, oldPosition, Quaternion.identity);
                Destroy(enemy); //(enemies[index]);
                getCount = GameObject.FindGameObjectsWithTag("AnimIce");

                Debug.Log("LOSE CHECK" + getCount.Length);
                if (getCount.Length > 2) {

                    Destroy(GameObject.Find("Boat"));
                    Debug.Log("INSIDE LOSE CHECK" + getCount.Length);
                    loseMenu.ToggleEndMenu();
                }
            }
        }
    }
}
