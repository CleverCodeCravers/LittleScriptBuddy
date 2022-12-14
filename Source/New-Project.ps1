<#
    Creates a new dotnet project with my preferred structure
#>
Param(
    [Parameter(Mandatory=$true)]
    [string]$ProjectName
)

function New-ClassLib {
    Param(
        [Parameter(Mandatory=$true)]
        [string]$Namespace,
        [Parameter(Mandatory=$true)]
        [string]$ToProject,
        [switch]$ForUnitTesting
    )

    Process {
        mkdir $Namespace
        Push-Location $Namespace

        dotnet new classlib

        if ($ForUnitTesting) {
            dotnet add package Microsoft.NET.Test.Sdk
            dotnet add package NUnit
            dotnet add package NUnit3TestAdapter
        }

        Pop-Location

        dotnet sln "./$($ToProject).sln" add "./$($Namespace)/"
    }
}


Set-Location $PSScriptRoot

mkdir $ProjectName
cd $ProjectName

dotnet new sln
dotnet new gitignore

New-ClassLib -Name ($ProjectName + ".Persistence") -ToProject $ProjectName

New-ClassLib ($ProjectName + ".Domain") -ToProject $ProjectName
New-ClassLib ($ProjectName + ".Domain.Tests") -ToProject $ProjectName -ForUnitTesting

New-ClassLib ($ProjectName + ".Interactors") -ToProject $ProjectName
New-ClassLib ($ProjectName + ".Interactors.Tests") -ToProject $ProjectName -ForUnitTesting

New-ClassLib ($ProjectName + ".Contracts") -ToProject $ProjectName
New-ClassLib ($ProjectName + ".Contracts.Tests") -ToProject $ProjectName -ForUnitTesting

