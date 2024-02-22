using LinesLib;

namespace TestLinesLib;

[TestClass]
public class LineSegmentTest
{
    [TestMethod]
    public void TestConstructor()
    {
        LineSegment line = new LineSegment(1, 5);
        Assert.AreEqual(1, line.Start);
        Assert.AreEqual(5, line.End);
    }

    [TestMethod]
    public void TestToString()
    {
        LineSegment line = new LineSegment(1, 5);
        Assert.AreEqual("1...5", line.ToString());
    }

    [TestMethod]
    public void TestContains()
    {
        LineSegment line = new LineSegment(1, 5);
        Assert.IsTrue(line.Contains(3));
        Assert.IsFalse(line.Contains(6));
    }

    [TestMethod]
    public void TestContainsLineSegment()
    {
        LineSegment lineSegment = new LineSegment(1, 5);
        LineSegment other = new LineSegment(3, 4);
        Assert.IsTrue(lineSegment.Contains(other));
    }

    [TestMethod]
    public void TestEquals()
    {
        LineSegment lineSegment = new LineSegment(1, 5);
        LineSegment other = new LineSegment(1, 5);
        Assert.IsTrue(lineSegment.Equals(other));
    }

    [TestMethod]
    public void TestIntersection()
    {
        LineSegment lineSegment = new LineSegment(1, 5);
        LineSegment other = new LineSegment(3, 4);
        Assert.AreEqual(3, lineSegment.Intersection(other));
    }

    [TestMethod]
    public void TestUnion()
    {
        LineSegment lineSegment = new LineSegment(1, 5);
        LineSegment other = new LineSegment(3, 7);
        LineSegment expectedUnion = new LineSegment(1, 7);

        LineSegment? union = lineSegment.Union(other);
        Assert.AreEqual(expectedUnion?.ToString(), union?.ToString());
    }

    [TestMethod]
    public void TestMinus()
    {
        LineSegment lineSegment = new LineSegment(1, 5);
        LineSegment other = new LineSegment(3, 7);
        List<LineSegment> expectedMinus = new List<LineSegment> { new LineSegment(1, 2) };

        Assert.AreEqual(expectedMinus, lineSegment.Minus(other));
    }
}