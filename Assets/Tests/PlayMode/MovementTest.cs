using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTest
{
   


    [UnityTest]
    public IEnumerator HorizontalMovementTest()
    {
        var player = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player")).GetComponent<PlayerController>();
        player.HorizontalMovement();

        yield return null;
        Assert.AreEqual(player.moveDirection = player.transform.forward * player.curSpeedX, player.moveDirection);
    }

    [UnityTest]
    public IEnumerator VerticalMovementTest()
    {
        var player = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player")).GetComponent<PlayerController>();
        player.VerticalMovement();

        yield return null;
        Assert.AreEqual(player.moveDirection = player.transform.right * player.curSpeedY, player.moveDirection);
    }
}
