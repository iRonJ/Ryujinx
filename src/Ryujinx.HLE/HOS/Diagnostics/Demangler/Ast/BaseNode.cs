using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public enum NodeType
    {
        CvQualifierType,
        SimpleReferenceType,
        NameType,
        EncodedFunction,
        NestedName,
        SpecialName,
        LiteralOperator,
        NodeArray,
        ElaboratedType,
        PostfixQualifiedType,
        SpecialSubstitution,
        ExpandedSpecialSubstitution,
        CtorDtorNameType,
        EnclosedExpression,
        ForwardTemplateReference,
        NameTypeWithTemplateArguments,
        PackedTemplateArgument,
        TemplateArguments,
        BooleanExpression,
        CastExpression,
        CallExpression,
        IntegerCastExpression,
        PackedTemplateParameter,
        PackedTemplateParameterExpansion,
        IntegerLiteral,
        DeleteExpression,
        MemberExpression,
        ArraySubscriptingExpression,
        InitListExpression,
        PostfixExpression,
        ConditionalExpression,
        ThrowExpression,
        FunctionParameter,
        ConversionExpression,
        BinaryExpression,
        PrefixExpression,
        BracedExpression,
        BracedRangeExpression,
        NewExpression,
        QualifiedName,
        StdQualifiedName,
        DtOrName,
        GlobalQualifiedName,
        NoexceptSpec,
        DynamicExceptionSpec,
        FunctionType,
        PointerType,
        ReferenceType,
        ConversionOperatorType,
        LocalName,
        CtorVtableSpecialName,
<<<<<<< HEAD
        ArrayType,
=======
        ArrayType
>>>>>>> 1ec71635b (sync with main branch)
    }

    public abstract class BaseNode
    {
        public NodeType Type { get; protected set; }

        public BaseNode(NodeType type)
        {
            Type = type;
        }

        public virtual void Print(TextWriter writer)
        {
            PrintLeft(writer);

            if (HasRightPart())
            {
                PrintRight(writer);
            }
        }

        public abstract void PrintLeft(TextWriter writer);

        public virtual bool HasRightPart()
        {
            return false;
        }

        public virtual bool IsArray()
        {
            return false;
        }

        public virtual bool HasFunctions()
        {
            return false;
        }

        public virtual string GetName()
        {
            return null;
        }

<<<<<<< HEAD
        public virtual void PrintRight(TextWriter writer) { }

        public override string ToString()
        {
            StringWriter writer = new();
=======
        public virtual void PrintRight(TextWriter writer) {}

        public override string ToString()
        {
            StringWriter writer = new StringWriter();
>>>>>>> 1ec71635b (sync with main branch)

            Print(writer);

            return writer.ToString();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
