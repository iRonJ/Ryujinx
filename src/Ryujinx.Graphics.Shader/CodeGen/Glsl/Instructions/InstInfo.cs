namespace Ryujinx.Graphics.Shader.CodeGen.Glsl.Instructions
{
    readonly struct InstInfo
    {
        public InstType Type { get; }

        public string OpName { get; }

        public int Precedence { get; }

        public InstInfo(InstType type, string opName, int precedence)
        {
<<<<<<< HEAD
            Type = type;
            OpName = opName;
            Precedence = precedence;
        }
    }
}
=======
            Type       = type;
            OpName     = opName;
            Precedence = precedence;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
