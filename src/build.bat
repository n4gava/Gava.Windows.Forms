set version=1.0.0
if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)

set nuget=
if "%nuget%" == "" (
	set nuget=nuget
)


%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\Gava.Windows.Forms.sln /p:Configuration=Release /p:Platform="Any CPU"

mkdir Build
mkdir Build\lib
mkdir Build\lib\net40

%nuget% pack "src\Gava.Windows.Forms.nuspec" -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"