using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerSystem : MonoBehaviour
{
    int foodCount;
    [SerializeField] float speed = 5;
    [SerializeField] GameObject pointLog;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshAgent>().speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public int getFoodCount(){
        return foodCount;
    }

    void setFoodCount(int inputFoodCount){
        foodCount = inputFoodCount;
    }

    public void addFoodCount(){
        foodCount++;
        pointLog.GetComponent<Text>().text = foodCount.ToString();
    }

    void OnCollisionEnter(Collision obj) {
        if (obj.gameObject.tag == "Player")
        {
            int player2FoodCount = obj.gameObject.GetComponent<PlayerSystem>().getFoodCount();
            if (foodCount<player2FoodCount)
            {
                Destroy(gameObject);
            }
        }
    }
}
