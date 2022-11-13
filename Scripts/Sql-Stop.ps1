<#
	
    .SYNOPSIS
        Start SQL Server w. Northwind DB  

    .DESCRIPTION
        See above
    
    .INPUTS
        none

    .OUTPUTS
        Sucess or failure 
#>

[int]$SQLPORT=1433
[string]$imageName="sql-docker"

$null = (docker stop "${$imageName}") 2> $null
$null = (docker rm "${$imageName}") 2> $null
