using System.Collections;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    bool visited = false;
    float waitTime = 3f;

    public bool Visited 
    {
        get {return visited;}
        set 
        {
            visited = value;

            if(value)
            {
                StartCoroutine(AwaitFlipVisited());
            }
        }
    }

    public void FlipVisited()
    {
        Visited = !Visited;
    }

    IEnumerator AwaitFlipVisited()
    {
        yield return new WaitForSeconds(waitTime);  // Wait for the specified time
        FlipVisited();
        Debug.Log("Flipped");
    }
}
