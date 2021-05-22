node
{
stage 'checkout code'
git 'https://github.com/komalverma982/JenkinsFileExtent.git'
stage 'restore nuget'
bat '"C:\\Users\\komal.verma982\\Downloads\\nuget.exe" restore NUnitTestProject1.sln'
stage 'build'
bat '"C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Enterprise\\MSBuild\\Current\\Bin\\amd64\\MSBuild" NUnitTestProject1.sln /p:Configuration=Release /p:Platform="Any CPU" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}'
stage 'test'
bat 'dotnet test D:/Calculator/NUnitTestProject1/NUnitTestProject1/NUnitTestProject1.csproj'
}