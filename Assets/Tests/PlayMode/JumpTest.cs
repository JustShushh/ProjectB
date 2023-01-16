using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class JumpTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void JumpTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator JumpTesting()
    {
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<PlayerController>();

        player.Jump();

        yield return new WaitForSeconds(player.jumpSpeed);
        Assert.AreEqual(new Vector3(0,0,0),gameObject.transform.position);
    }
}
