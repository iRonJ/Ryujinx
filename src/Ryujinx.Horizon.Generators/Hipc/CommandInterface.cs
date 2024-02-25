<<<<<<< HEAD
using Microsoft.CodeAnalysis.CSharp.Syntax;
=======
﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
>>>>>>> 1ec71635b (sync with main branch)
using System.Collections.Generic;

namespace Ryujinx.Horizon.Generators.Hipc
{
    class CommandInterface
    {
        public ClassDeclarationSyntax ClassDeclarationSyntax { get; }
        public List<MethodDeclarationSyntax> CommandImplementations { get; }

        public CommandInterface(ClassDeclarationSyntax classDeclarationSyntax)
        {
            ClassDeclarationSyntax = classDeclarationSyntax;
            CommandImplementations = new List<MethodDeclarationSyntax>();
        }
    }
}
