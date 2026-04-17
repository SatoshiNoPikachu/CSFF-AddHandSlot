using UnityEngine;

namespace AddHandSlot.Line;

public struct DoubleLineArg(int offset, Vector2 padding, Vector2 margin)
{
    public int Offset = offset;
    public Vector2 Padding = padding;
    public Vector2 Margin = margin;
}