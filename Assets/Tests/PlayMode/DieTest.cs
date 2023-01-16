using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DieTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void DieTestSimplePasses()
    {
        var player = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player")).GetComponent<PlayerController>();
        var lifeManager = player.GetComponent<LiveManager>();

        for(int i = 0; i < 4; i++)
        {
            player.TakeHit();
        }
        Assert.True(lifeManager.died);
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator DieTestWithEnumeratorPasses()
    {

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
