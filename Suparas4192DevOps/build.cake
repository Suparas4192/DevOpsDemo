var target = Argument("target", "Default");

var configuration = Argument("configuration", "Debug");
var solutionFile = "./Suparas4192DevOps.sln";
var cleanConsoleDir = Directory("./Suparas4192DevOps/bin/Debug");
var cleanTestDir = Directory("./Suparas4192DevOps.Test/bin/Debug");

Task("Clean")
	.IsDependentOn("Clean-Outputs")
	.Does(() => 
	{
		DotNetBuild(solutionFile, settings => settings
			.SetConfiguration(configuration)
			.WithTarget("Clean")
			.SetVerbosity(Verbosity.Minimal));
	});
	
Task("Clean-Outputs")
	.Does(() => 
	{
		CleanDirectory(cleanConsoleDir);
		CleanDirectory(cleanTestDir);
	});
	
	Task("Restore")
	.Does(() =>
	{
	NuGetRestore(solutionFile);
	});

Task("Build")
  .Does(() =>
  {
	MSBuild("./Suparas4192DevOps.sln");
  });

Task("Test")
    .Does(() =>
	{
		MSTest("./Suparas4192DevOps.Test/bin/Debug/Suparas4192DevOps.Test.dll");
	});
		
		

Task("Default")
	.IsDependentOn("Clean")
	.IsDependentOn("Restore")
	.IsDependentOn("Build")
	.IsDependentOn("Test")
	
RunTarget(target);