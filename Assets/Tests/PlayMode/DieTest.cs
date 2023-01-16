using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DieTest
{
  
  
    [UnityTest]
    public IEnumerator DieTestWithEnumeratorPasses()
    {

        var player = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player")).GetComponent<PlayerController>();
        var lifeManager = player.GetComponent<LiveManager>();

        for(int i = 0; i < 4; i++)
        {
            player.TakeHit();
        }

        yield return new WaitForSeconds(1);
        Assert.True(lifeManager.died);
        
        // Use yield to skip a frame.
    }
}
