$nugetOutputDirectory = '..\TemplatePack\TemplatePack\Templates'
$nugetFileName = 'nuget.exe'

if (!(Test-Path $nugetFileName))
{
    Write-Host 'Downloading Nuget.exe ...'
    Invoke-WebRequest -Uri "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile $nugetFileName
}

$wpfNuspecPath = 'Wpf\Prism.Wpf.Templates.nuspec'
$xfNuspecPath = 'Xamarin.Forms\Prism.Xamarin.Forms.Templates.nuspec'

Invoke-Expression ".\$($nugetFileName) pack $($wpfNuspecPath) -OutputDirectory $nugetOutputDirectory" 

Invoke-Expression ".\$($nugetFileName) pack $($xfNuspecPath) -OutputDirectory $nugetOutputDirectory" 

Read-Host -Prompt "Press Enter to exit"