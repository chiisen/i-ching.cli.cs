# i-ching.cli.cs
由 C# 程式語言開發的易經卜卦 CLI 介面工具

# 建立 nuget 專案
```bash=
dotnet new console -lang c#
```
- 在 *.csproj 下新增下面三行
```xml=
<PackAsTool>true</PackAsTool>
<ToolCommandName>i-ching.cli.cs</ToolCommandName>
<PackageOutputPath>./nupkg</PackageOutputPath>
```
- 設定編譯時產生 nupkg(可由介面設定或在 *.csproj 內新增)
```xml=
<GeneratePackageOnBuild>True</GeneratePackageOnBuild>
```
介面在【專案】=>【XXX 屬性】  
    =>【套件】=>【一般】=>【在建置時產生 NuGet 套件】  
    =>勾選【在建置作業期間產生套件檔案】 


---

# 安裝 nuget
- 編譯
```bash=
dotnet build
```
看看有沒有錯誤訊息
- 產生 nupkg
```bash=
dotnet pack
```
- 安裝全域 nuget 套件
```bash=
dotnet tool install --global --add-source .\nupkg i-ching.cli.cs
```
- 查看全域 nuget 套件
```bash=
dotnet tool list -g
```
- 測試 i-ching.cli.cs 是否安裝成功 
```bash=
i-ching.cli.cs --help
```

---

# 解除 i-ching.cli.cs 安裝
- 解除安裝全域 i-ching.cli.cs 的 nuget 套件
```bash=
dotnet tool uninstall -g i-ching.cli.cs
```

---

# 本地安裝 nuget 套件批次檔案
```bash=
.\install.bat
```
會循序進行清理目錄、打包、移除套件、安裝套件並顯示套件安裝版本  
如果執行失敗可以試試看下面指令，指定 sdk 版本，因為目前還不支援 sdk 9 以上的版本
 ```bash=
dotnet new globaljson --sdk-version 10.0.101
```
最後的一串數字 10.0.101 是 sdk 版本號，可以用下面指令查詢目前已安裝的 sdk 版本
 ```bash=
dotnet --info
```

---

# 執行套件
```bash=
i-ching.cli.cs i-ching
```

