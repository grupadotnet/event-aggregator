function buildVS
{
    param
    (
        [parameter(Mandatory=$true)]
        [String] $path = "C:\Users\biela\Documents\event-aggregator\Event-Aggregator.sln",

        [parameter(Mandatory=$true)]
        [String] $msBuildExe = "C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe",

        [parameter(Mandatory=$false)]
        [bool] $nuget = $true,
        
        [parameter(Mandatory=$false)]
        [bool] $clean = $true
    )
        #if ($nuget) {
        #Write-Host "Restoring NuGet packages" -foregroundcolor green
        #nuget restore "$($path)"
        #}

        #if ($clean) {
        #    Write-Host "Cleaning $($path)" -foregroundcolor green
        #    & "$($msBuildExe)" "$($path)" /t:Clean /m
        #}

        Write-Host "Building $($path)" -foregroundcolor green
        & "$($msBuildExe)" "$($path)" /t:Build /m
        Write-Host "Builf finished. :)"

}