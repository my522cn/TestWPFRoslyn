using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using NeoSharp;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var main = new TestMain();
            main.Logger = "4";
        }

        class TestMain : TSBase
        {

        }
    }
}
