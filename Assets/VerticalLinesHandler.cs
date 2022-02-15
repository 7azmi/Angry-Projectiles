using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Collections;

public class VerticalLinesHandler : LinesHandler
{
    float Radius { get { return camX / camY * CameraSize; } }
    //float RadiusInPosition { get { return Radius + Camera.main.transform.position.x; } } //x

    public override void Awake()
    {
        base.Awake();
        CreateLines();
        OnRepositionCamera += RepositionLines;
    }

    [ContextMenu("hehe boi")]
    public void CreateLines()
    {
        lines = new List<LineRenderer>();

        for (int i = (int)-Radius; i <= Radius; i++)
        {
            lines.Add(CreateLine(new Vector3[]{
                new Vector3(i,CameraSize,0),
                new Vector3(i,-CameraSize,0)
            }));

            AdjustLineThickness(lines.Last());
        }
    }

    

    bool InBounds(LineRenderer line)
    {
        float linePos = line.GetPosition(0).x;
        return Within(linePos, new Vector2(-Radius + CameraPos.x, Radius + CameraPos.x));
    }

    bool Within(float value, Vector2 range)
    {
        return value >= range.x && value <= range.y;
    }

    bool LineIsOutBoundsFromLeft(LineRenderer l)
    {
        return l.GetPosition(0).x < -Radius + CameraPos.x;
    }

    /// <summary>
    /// triggered when camera is moving
    /// it checks if lines are not in bounds to displace them to the displaced side(+-radius)
    /// </summary>
    void RepositionLines()
    {
        foreach (var l in lines)
        {
            if (!InBounds(l))
            {
                float displacement = LineIsOutBoundsFromLeft(l) ? Radius * 2 : -(Radius * 2);
                Reposition(l, (int) displacement);

                //also adjust thickness boy
                AdjustLineThickness(l);
            }
        }
    }


    /// <summary>
    /// modifies all lines position.x to displacement value
    /// </summary>
    /// <param name="r"></param>
    /// <param name="displacement"></param>
    void Reposition(LineRenderer r, int displacement)
    {
        Vector3[] poses = new Vector3[r.positionCount];
        r.GetPositions(poses);
        for (int i = 0; i < poses.Length; i++)
        {
            poses[i] += (Vector3)(Vector2.right * displacement); //displacement on x
        }

        r.SetPositions(poses);
    }

    protected void AdjustLineThickness(LineRenderer line)
    {
        int lineIndex = (int)line.GetPosition(0).x;
        float thickness = lineIndex % thickerLineEach == 0 ? LineThicknessMultiplier : LineThicknessMultiplier / 3;
        line.widthMultiplier = thickness;
    }

}
