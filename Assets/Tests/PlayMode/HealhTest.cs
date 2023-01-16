using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealhTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void HealhTestSimplePasses()
    {
        // Use the Assert class to test conditions
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<PlayerController>();

        player.TakeHit();
        Assert.AreEqual(player.health = 75f, player.health);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator HealhTestWithEnumeratorPasses()
    {
        yield return null;
    }
}
