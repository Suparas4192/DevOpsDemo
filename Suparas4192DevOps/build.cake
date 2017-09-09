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
		
		
Task("Upload-Coverage-Report")
    .Does(() =>
    {
        MSTest("./Suparas4192DevOps.Test/bin/Debug/Suparas4192DevOps.Test.dll");
    },
    new FilePath("./result.xml"),
    new OpenCoverSettings()
);		

Task("Default")
	.IsDependentOn("Clean")
	.IsDependentOn("Restore")
	.IsDependentOn("Build")
	.IsDependentOn("Test")
	.IsDependentOn("Upload-Coverage-Report");
	
RunTarget(target);