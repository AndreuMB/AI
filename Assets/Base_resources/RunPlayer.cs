using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayer : MonoBehaviour
{
    GameObject player;
    [SerializeField] float speed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 playerPosition = player.transform.position;
        Vector3 direction = transform.position - player.transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
    }
}
