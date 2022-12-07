using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CheckEnemyFood : CompositeNode
{
    GameObject enemyPlayer;
    protected override void OnStart() {
        enemyPlayer = getEnemyPlayer();
    }

    GameObject getEnemyPlayer(){
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Vector3 selfPosition = context.transform.position;
        foreach (GameObject player in players)
        {
            if (context.gameObject != player)
            {
                return player;
            }
        }
        return null;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        int playerFood = context.gameObject.GetComponent<PlayerSystem>().getFoodCount();
        int enemyPlayerFood = enemyPlayer.GetComponent<PlayerSystem>().getFoodCount();
        Debug.Log("playerFood = "+playerFood+" enemyPlayerFood = "+enemyPlayerFood);
        if (playerFood>enemyPlayerFood)
        {
            Select<Chase>();
        }else{
            Select<Eat>();
        }
        return selected.Update();
    }
}
