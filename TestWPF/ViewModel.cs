using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.IO;
using System.Reflection;

namespace TestWPF
{
    class ViewModel : ViewModelBase
    {

        private string _Text;
        public string Text
        {
            get => _Text;
            set { Set(ref _Text, value); }
        }

        public ICommand RunCommand => new RelayCommand(() =>
        {
            Main();
        });

        public async void Main()
        {
            string code1 = File.ReadAllText("TestMain.cs");
            await Task.Run(async () =>
            {
                var script = CSharpScript.RunAsync(code1 + "var tmain = new TestMain();", ScriptOptions.Default.AddReferences(typeof(TSBase).Assembly).AddImports("TestWPF")).Result;
                await script.ContinueWithAsync("tmain.Run();");
                var state1 = script.ContinueWithAsync<string>("tmain.Logger");
                Text += state1.Result.ReturnValue + "\n===========\n";
            });

            //await Task.Run(async () =>
            //{
            Assembly assembly = Assembly.LoadFrom(@"TSBase.dll");
            var type = assembly.GetType("TSBaseNS.TSBase");
            var script = CSharpScript.RunAsync(code1 + "var tmain = new TestMain();", ScriptOptions.Default.AddReferences(type.Assembly).AddImports("TSBaseNS")).Result;
            await script.ContinueWithAsync("tmain.Run();");
            var state1 = script.ContinueWithAsync<string>("tmain.Logger");
            Text += state1.Result.ReturnValue + "\n===========\n";
            //});

        }

    }
}
