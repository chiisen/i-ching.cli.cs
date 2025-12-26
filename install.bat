echo [Format: UTF-8]
chcp 65001

echo 【請輸入 .\install.bat】

echo 【刪除舊的套件檔案】
if exist .\nupkg\*.nupkg del .\nupkg\*.nupkg

echo 【打包全域套件】
dotnet pack -c Release

echo 【解除安裝全域套件】
dotnet tool uninstall -g i-ching.cli.cs

echo 【安裝全域套件】
dotnet tool install --global --add-source .\nupkg i-ching.cli.cs

echo 【查看全域套件】
dotnet tool list -g

