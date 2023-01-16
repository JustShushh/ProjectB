using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SafetyTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void SafetyTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SafetyTestWithEnumeratorPasses()
    {
        var player = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player")).GetComponent<PlayerController>();

        player.TakeHit();

        yield return new WaitForSeconds(3f);
        Assert.False(player.safe);
    }
}
