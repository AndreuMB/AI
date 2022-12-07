using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CheckFood : CompositeNode
{
    protected override void OnStart() {

        GameObject[] fruits = GameObject.FindGameObjectsWithTag("Fruit");
        if (fruits.Length>0)
        {
            Select<Eat>();
        }else{
            Select<Chase>();
        }

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return selected.Update();
    }
}
