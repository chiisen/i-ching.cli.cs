

using McMaster.Extensions.CommandLineUtils;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using Console = Colorful.Console;

namespace i_ching.cli.cs;

public partial class Program
{
    private static string? _currentPath = "";
    private static readonly CommandLineApplication App = new() { Name = "i-ching.cli.cs" };

    private static int Main(string[] args)
    {

        // 指定輸出為 UTF8
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        #region 顯示執行路徑

        var sw = Stopwatch.StartNew();

        var assem = Assembly.GetEntryAssembly();
        if (assem is not null)
        {
            _currentPath = Path.GetDirectoryName(assem.Location);
        }
        Console.WriteLine($"執行路徑: {_currentPath}", Color.Aqua);
        Console.WriteLine($"================", Color.Aqua);

        sw.Stop();

        Console.WriteLine($"顯示執行路徑 - sw: {sw.ElapsedMilliseconds}", Color.Azure);

        #endregion 顯示執行路徑


        #region 【Logger 輸入參數】

        sw = Stopwatch.StartNew();

        // ! Logger 輸入參數
        var argString = args.Aggregate("", (current, arg) => current + (arg + " "));
        Console.WriteLine($"輸入參數:i-ching.cli.cs {argString}");
        Console.WriteLine($"====================");

        sw.Stop();

        Console.WriteLine($"Logger 輸入參數 - sw: {sw.ElapsedMilliseconds}", Color.Azure);

        #endregion 【Logger 輸入參數】


        #region 【設定 Help】

        sw = Stopwatch.StartNew();

        // ! 設定 Help
        App.HelpOption("-?|-h|--help");
        App.OnExecute(() =>
        {
            App.ShowHelp();
            return 0;
        });

        sw.Stop();

        Console.WriteLine($"設定 Help - sw: {sw.ElapsedMilliseconds}", Color.Azure);

        #endregion 【設定 Help】


        #region 【註冊 Command】

        sw = Stopwatch.StartNew();

        // ! 註冊 Command
        IChing();
        sw.Stop();

        Console.WriteLine($"註冊 Command - sw: {sw.ElapsedMilliseconds}", Color.Azure);

        #endregion 【註冊 Command】


        var ret = -1;
        try
        {
            ret = App.Execute(args);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"發生錯誤:{ex.Message}");
        }

        #region 取的 File Version

        sw = Stopwatch.StartNew();

        // ! 取的 File Version
        var assembly = Assembly.GetExecutingAssembly();
        var fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
        var fileVersion = "";
        if (fvi.FileVersion is not null)
        {
            fileVersion = fvi.FileVersion;
        }

        sw.Stop();

        Console.WriteLine($"取的 File Version - sw: {sw.ElapsedMilliseconds}", Color.Azure);

        #endregion 取的 File Version
        

        #region 取得 Assembly Version

        sw = Stopwatch.StartNew();

        // ! 取得 Assembly Version
        var assemblyVersion = "";
        var execAssem = Assembly.GetExecutingAssembly();
        if (execAssem?.GetName() is not null)
        {
            var ver = execAssem.GetName().Version;
            if (ver is not null)
            {
                assemblyVersion = ver.ToString();
            }
        }

        sw.Stop();

        Console.WriteLine($"取得 Assembly Version - sw: {sw.ElapsedMilliseconds}", Color.Azure);

        #endregion 取得 Assembly Version


        Console.WriteLine($"================", Color.Blue);
        Console.WriteLine($"csharp.cli find-id -? 可以查第二層說明", Color.Yellow);
        Console.WriteLine($"================", Color.Blue);
        Console.WriteLine($" AssemblyVersion: {assemblyVersion}\r\n FileVersion: {fileVersion}\r\n 回傳值為: {ret}");
        Console.WriteLine($"^^^^程式結束^^^^", Color.Green);


        return 0;
    }
}
