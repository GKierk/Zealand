using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace LinesLib;

public class LineSegment
{
  private int start;
  private int end;

  public LineSegment(int start, int end)
  {
    if (start <= end)
    {
      this.start = start;
      this.end = end;
    }
    else
    {
      throw new ArgumentException("Start must be less than or equal to end");
    }
  }

  public int Start => start;
  public int End => end;

  public override string ToString() => $"{start}...{end}";
  public bool Contains(int point) => point >= start && point <= end;
  public bool Contains(LineSegment other) => this.Contains(other.start) || this.Contains(other.end);
  public bool Equals(LineSegment other) => this.start == other.start && this.end == other.end;

  public Nullable<int> Intersection(LineSegment other)
  {
    if (other.Contains(this) || this.Contains(other))
    {
      for (int i = other.start; i <= other.end; i++)
      {
        for (int j = this.start; j <= this.end; j++)
        {
          if (i == j)
          {
            return i;
          }
        }
      }
    }

    return null;
  }

  public LineSegment? Union(LineSegment other)
  {
    if (other.Contains(this) || this.Contains(other))
    {
      int start = other.start < this.start ? other.start : this.start;
      int end = other.end > this.end ? other.end : this.end;

      return new LineSegment(start, end);
    }

    return null;
  }



  public List<LineSegment> Minus(LineSegment other)
  {
    List<LineSegment> result = new List<LineSegment>();

    if (other.Contains(this))
    {
      return result;
    }

    if (other.start < this.start)
    {
      result.Add(new LineSegment(other.start, this.start - 1));
    }

    if (other.end > this.end)
    {
      result.Add(new LineSegment(this.end + 1, other.end));
    }

    return result;
  }

}
