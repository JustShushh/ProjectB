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
        Object.Instantiate(Resources.Load<GameObject>("Prefabs/Plane"));
        var player = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player")).GetComponent<PlayerController>();

        yield return new WaitForSeconds(1f);
        
        var initialPosition = player.transform.position;

        player.Jump();

        yield return new WaitForSeconds(player.jumpSpeed);
        Assert.AreEqual(initialPosition,player.transform.position);
    }
}
