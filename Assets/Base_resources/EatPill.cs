using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatPill : MonoBehaviour
{
    GameObject pill;
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        pill = GameObject.FindWithTag("Pill");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision obj) {
        string tag = obj.gameObject.tag;
        // Debug.Log("Collision = "+tag);
        switch (tag)
        {
            case "Pill":
                Destroy(pill);
                active = true;
            break;
            case "Enemy":
                // if active player
                // destroy enemy
                // else
                // gameover
            break;
            case "Fruit":
                Destroy(obj.gameObject);
                GetComponent<PlayerSystem>().addFoodCount();
            break;
            default:
            break;
        }
    }

    public bool getActive(){
        return active;
    }
}
