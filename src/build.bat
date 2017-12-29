set version=1.0.0
if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)

set nuget=
if "%nuget%" == "" (
	set nuget=nuget
)


"%MsBuildExe%" src\Gava.Windows.Forms.sln /p:Configuration=Release /p:Platform="Any CPU"
