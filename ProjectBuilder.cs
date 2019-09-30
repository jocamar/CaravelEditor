using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using System.Collections.Generic;

namespace CaravelEditor
{
    class ProjectBuilder
    {
        public static bool Build(string projectPath, string outputDirectory, EditorBuildLogger logger, out string assemblyName)
        {
            List<ILogger> loggers = new List<ILogger>();
            loggers.Add(logger);

            string projectFilePath = projectPath;

            ProjectCollection pc = new ProjectCollection();
            pc.RegisterLogger(logger);
            
            Dictionary<string, string> globalProperty = new Dictionary<string, string>();
            globalProperty.Add("OutputPath", outputDirectory);

            //BuildParameters bp = new BuildParameters(pc);
            //BuildRequestData buildRequest = new BuildRequestData(projectFilePath, globalProperty, "4.0", new string[] { "Build" }, null);
            
            try
            {
                pc.LoadProject(projectFilePath, globalProperty, "4.0");
                //BuildResult buildResult = BuildManager.DefaultBuildManager.Build(bp, buildRequest);
                foreach (var proj in pc.LoadedProjects)
                {
                    if (proj.Build())
                    {
                        logger.WriteLine("Build Finished!");
                        assemblyName = proj.GetPropertyValue("AssemblyName");
                        return true;
                    }
                    else
                    {
                        logger.WriteLine("Build Failed!");
                        assemblyName = "";
                        return false;
                    }
                }

                assemblyName = "";
                return false;
                
                /*if (buildResult.OverallResult == BuildResultCode.Success)
                {
                    //...
                    logger.WriteLine("Build Finished!");
                    return true;
                }

                return false;*/
            }
            finally
            {
                pc.UnregisterAllLoggers();
            }
        }
    }
}
