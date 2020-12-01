using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class UtilsTestRunner
{

    [Test]
    public void TestNearestPointOnSegmentAlreadyOnSegment()
    {
        Vector3 A = new Vector3(0, 0, 0);
        Vector3 B = new Vector3(0, 1, 0);

        Vector3 C = new Vector3(0, 0.5f, 0);

        Vector3 result = Utils.NearestPointOnSegment(C, A, B);

        Assert.AreEqual(C, result, $"Failed with result {result}");
    }

    [Test]
    public void TestNearestPointOnSegmentInBetweenClosest()
    {
        Vector3 A = new Vector3(0, 0, 0);
        Vector3 B = new Vector3(0, 1, 0);

        Vector3 C = new Vector3(1, 0.5f, 0);

        Vector3 result = Utils.NearestPointOnSegment(C, A, B);

        Assert.AreEqual(new Vector3(0, 0.5f, 0), result, $"Failed with result {result}");
    }

    [Test]
    public void TestNearestPointOnSegmentInBetweenClosestButFar()
    {
        Vector3 A = new Vector3(0, 0, 0);
        Vector3 B = new Vector3(0, 1, 0);

        Vector3 C = new Vector3(1000, 0.5f, 0);

        Vector3 result = Utils.NearestPointOnSegment(C, A, B);

        Assert.AreEqual(new Vector3(0, 0.5f, 0), result, $"Failed with result {result}");
    }

    [Test]
    public void TestNearestPointOnSegmentExtremeA()
    {
        Vector3 A = new Vector3(0, 0, 0);
        Vector3 B = new Vector3(0, 1, 0);

        Vector3 C = new Vector3(0, -0.2f, 0);

        Vector3 result = Utils.NearestPointOnSegment(C, A, B);

        Assert.AreEqual(A, result, $"Failed with result {result}");
    }

    [Test]
    public void TestNearestPointOnSegmentExtremeB()
    {
        Vector3 A = new Vector3(0,0,0);
        Vector3 B = new Vector3(0, 1, 0);

        Vector3 C = new Vector3(0, 1.2f, 0);

        Vector3 result = Utils.NearestPointOnSegment(C, A, B);

        Assert.AreEqual(B, result, $"Failed with result {result}");
    }
}
