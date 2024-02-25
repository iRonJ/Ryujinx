namespace Ryujinx.Graphics.Shader
{
    enum OutputTopology
    {
<<<<<<< HEAD
        PointList = 1,
        LineStrip = 6,
        TriangleStrip = 7,
=======
        PointList     = 1,
        LineStrip     = 6,
        TriangleStrip = 7
>>>>>>> 1ec71635b (sync with main branch)
    }

    static class OutputTopologyExtensions
    {
        public static string ToGlslString(this OutputTopology topology)
        {
<<<<<<< HEAD
            return topology switch
            {
                OutputTopology.LineStrip => "line_strip",
                OutputTopology.PointList => "points",
                OutputTopology.TriangleStrip => "triangle_strip",
                _ => "points",
            };
        }
    }
}
=======
            switch (topology)
            {
                case OutputTopology.LineStrip:     return "line_strip";
                case OutputTopology.PointList:     return "points";
                case OutputTopology.TriangleStrip: return "triangle_strip";
            }

            return "points";
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
