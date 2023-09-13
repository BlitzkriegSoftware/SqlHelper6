<#
	
    .SYNOPSIS
        Stop SQL Server 

    .DESCRIPTION
        See above
    
    .INPUTS
        none

    .OUTPUTS
        Sucess or failure 
#>

Import-Module Microsoft.PowerShell.Utility

function Get-DockerRunning {

	[bool]$DockerAlive = $false

	try {
		$null = Get-Process 'com.docker.backend'
		$DockerAlive = $true;
	} catch {
		$DockerAlive = $false;
	}

	return $DockerAlive
}

#
# Main
#

Set-StrictMode -Version 2.0
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls -bor [Net.SecurityProtocolType]::Tls11 -bor [Net.SecurityProtocolType]::Tls12
$ScriptUtc = (get-date).ToUniversalTime()
Push-Location $PSScriptRoot
[string]$scriptName = $MyInvocation.MyCommand.Name

[bool]$da = Get-DockerRunning

if(! $da) {
	Write-Error "docker must be running 1st"
	return 1
}

[int]$SQLPORT=1433
[string]$imageName="sql-docker"
[string]$SAPASS="blitz!2023stw-"
[string]$dbname="Northwind"
[string]$justscript = "instnwnd.sql"

# Dispose of any old running ones
$null = (docker stop "${imageName}") 2> $null
$null = (docker rm "${imageName}") 2> $null

[string]$pwd = $(Get-Location).Path

$dbPath = Join-Path -Path $pwd -ChildPath "db"
[string]$sqlfile = (Get-Item (Join-Path -Path $dbPath -ChildPath $justscript)).FullName

$dockerImage="mcr.microsoft.com/mssql/server:2019-latest"

docker pull $dockerImage
docker run -d -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=${SAPASS}" -p "${SQLPORT}:${SQLPORT}" --volume "${dbPath}:/db" --workdir "/db" --name="${imageName}" $dockerImage

echo "Waiting for SQL to Start"

Start-Sleep -Seconds 30

echo "Creating $dbname from $justscript"

docker exec -it $imageName //opt/mssql-tools/bin/sqlcmd  -S '.' -U sa -P $SAPASS -i //db/$justscript

$SQLCN="Server=127.0.0.1,${SQLPORT};Database=${dbname};User Id=sa;Password=${SAPASS};"

Write-Output "ConnectionString: ${SQLCN}"