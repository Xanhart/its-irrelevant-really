Function Set-ConnectionString{
	[CmdletBinding(SupportsShouldProcess=$True)]
	Param(
        [string]$fileName="app.config",
        [string]$connectionStringName,
        [string]$connectionString
    )
	
	$config = [xml](Get-Content -LiteralPath $fileName)
	
    $config.Configuration.connectionStrings
    
	$connStringElement = $config.SelectSingleNode("configuration/connectionStrings/add[@name='$connectionStringName']")
    
    if($connStringElement) {
        
        $connStringElement.connectionString = $connectionString
    	
    	if($pscmdlet.ShouldProcess("$fileName","Modify app.config connection string")){
    		Write-Host ("Updating app.config connection string {0} to be {1}" -f $connectionStringName, $connectionString)
    	
    		$config.Save($fileName)
    	}
    }
    else{
        Write-Error "Unable to locate connection string named: $connectionStringName"
    }
}

Set-ConnectionString "C:\appveyor\projects\its-irrelevant-really\applications\ScavengerHunt\web.config" DefaultConnection "Data Source=.\SCAVENGERHUNT;Initial Catalog=SCAVENGERHUNT;Integrated Security=True"