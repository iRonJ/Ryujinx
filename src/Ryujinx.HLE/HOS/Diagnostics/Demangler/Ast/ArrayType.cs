using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class ArrayType : BaseNode
    {
<<<<<<< HEAD
        private readonly BaseNode _base;
        private readonly BaseNode _dimensionExpression;
        private readonly string _dimensionString;

        public ArrayType(BaseNode Base, BaseNode dimensionExpression = null) : base(NodeType.ArrayType)
        {
            _base = Base;
=======
        private BaseNode _base;
        private BaseNode _dimensionExpression;
        private string   _dimensionString;

        public ArrayType(BaseNode Base, BaseNode dimensionExpression = null) : base(NodeType.ArrayType)
        {
            _base                = Base;
>>>>>>> 1ec71635b (sync with main branch)
            _dimensionExpression = dimensionExpression;
        }

        public ArrayType(BaseNode Base, string dimensionString) : base(NodeType.ArrayType)
        {
<<<<<<< HEAD
            _base = Base;
=======
            _base            = Base;
>>>>>>> 1ec71635b (sync with main branch)
            _dimensionString = dimensionString;
        }

        public override bool HasRightPart()
        {
            return true;
        }

        public override bool IsArray()
        {
            return true;
        }

        public override void PrintLeft(TextWriter writer)
        {
            _base.PrintLeft(writer);
        }

        public override void PrintRight(TextWriter writer)
        {
            // FIXME: detect if previous char was a ].
            writer.Write(" ");

            writer.Write("[");

            if (_dimensionString != null)
            {
                writer.Write(_dimensionString);
            }
<<<<<<< HEAD
            else
            {
                _dimensionExpression?.Print(writer);
=======
            else if (_dimensionExpression != null)
            {
                _dimensionExpression.Print(writer);
>>>>>>> 1ec71635b (sync with main branch)
            }

            writer.Write("]");

            _base.PrintRight(writer);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
