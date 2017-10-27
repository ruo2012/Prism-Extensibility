$nugetOutputDirectory = '..\TemplatePack\TemplatePack\Templates'
$nugetFileName = 'nuget.exe'

if (!(Test-Path $nugetFileName))
{
    Write-Host 'Downloading Nuget.exe ...'
    Invoke-WebRequest -Uri "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile $nugetFileName
}

$nuspecPath = 'Xamarin.Forms\Prism.Xamarin.Forms.Templates.nuspec'

Write-Host "NuSpec: $nuspecPath"

Invoke-Expression ".\$($nugetFileName) pack $($nuspecPath) -OutputDirectory $nugetOutputDirectory" 

Read-Host -Prompt "Press Enter to exit"