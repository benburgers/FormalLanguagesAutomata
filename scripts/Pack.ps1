$cache_folder = "%USERPROFILE%/.nuget/packages"
$source_folder = "../source"
$version = ""
for ( $i = 0; $i -lt $args.count; $i++ )
{
	if ($args[ $i ] -eq "/v") { $version=$args[ $i+1 ] }
	if ($args[ $i ] -eq "-v") { $version=$args[ $i+1 ] }
}
if ( $version -eq "" )
{
	$version = Read-Host "Version?"
}

$projects = `
	"BenBurgers.FormalLanguagesAutomata", `
	"BenBurgers.FormalLanguagesAutomata.Automata", `
	"BenBurgers.FormalLanguagesAutomata.Grammars"
foreach ($project in $projects)
{
	dotnet pack "$source_folder/$project/$project.csproj" -o D:\SD\NuGet -c Debug /p:Version="$version-beta"
	
	if ( Test-Path -Path $cache_folder/$project/${ version }-beta )
	{
		rm -R $cache_folder/$project/${ version }-beta
	}
}
dotnet restore "$source_folder"