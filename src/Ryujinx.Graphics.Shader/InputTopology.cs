namespace Ryujinx.Graphics.Shader
{
    public enum InputTopology : byte
    {
        Points,
        Lines,
        LinesAdjacency,
        Triangles,
<<<<<<< HEAD
        TrianglesAdjacency,
=======
        TrianglesAdjacency
>>>>>>> 1ec71635b (sync with main branch)
    }

    static class InputTopologyExtensions
    {
        public static string ToGlslString(this InputTopology topology)
        {
            return topology switch
            {
                InputTopology.Points => "points",
                InputTopology.Lines => "lines",
                InputTopology.LinesAdjacency => "lines_adjacency",
                InputTopology.Triangles => "triangles",
                InputTopology.TrianglesAdjacency => "triangles_adjacency",
<<<<<<< HEAD
                _ => "points",
=======
                _ => "points"
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static int ToInputVertices(this InputTopology topology)
        {
            return topology switch
            {
                InputTopology.Points => 1,
<<<<<<< HEAD
                InputTopology.Lines => 2,
                InputTopology.LinesAdjacency => 4,
                InputTopology.Triangles => 3,
                InputTopology.TrianglesAdjacency => 6,
                _ => 1,
            };
        }

        public static int ToInputVerticesNoAdjacency(this InputTopology topology)
        {
            return topology switch
            {
                InputTopology.Points => 1,
=======
>>>>>>> 1ec71635b (sync with main branch)
                InputTopology.Lines or
                InputTopology.LinesAdjacency => 2,
                InputTopology.Triangles or
                InputTopology.TrianglesAdjacency => 3,
<<<<<<< HEAD
                _ => 1,
            };
        }
    }
}
=======
                _ => 1
            };
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
