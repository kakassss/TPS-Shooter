using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueTest : MonoBehaviour
{
    Queue<MyDebugger> debugQueue = new Queue<MyDebugger>();
    GameObject newDebugger;

    private void Start()
    {
           
    }

    private void AddIndex(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            MyDebugger index1 = new();   
            debugQueue.Enqueue(index1);
        }
        Debug.Log(debugQueue.Count);

        foreach (var item in debugQueue)
        {
            item.DebugMyStr();
        }
    }

    private IEnumerator waitForToPrint()
    {
        yield return new WaitForSeconds(1.5f);

        
    }
}

public class MyDebugger
{
    public string debugStr;
    private int randomIndex;
    public void DebugMyStr()
    {
        debugStr = " ";
        randomIndex = Random.Range(0,25);
        Debug.Log(debugStr + randomIndex.ToString());
    }
}
