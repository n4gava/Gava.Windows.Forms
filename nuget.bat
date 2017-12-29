mkdir .nuget
cd .nuget
del *.nupkg
nuget update /self
nuget pack GavaWindowsForms.nuspec
cd ..
