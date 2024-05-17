using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis.MSBuild;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//


namespace CodeAnalysisProjectsNET70.Services
{
    public static class ProjectAnalysisService
    {

        public static List<Project> GetProjects(string solutionPath)
        {
            // Используйте MSBuildLocator для регистрации версии MSBuild
            MSBuildLocator.RegisterDefaults();
            // using var collection = new ProjectCollection();
            using var workspace = MSBuildWorkspace.Create();
            var solution = SolutionFile.Parse(solutionPath);

            var solutionProjects = solution.ProjectsInOrder
                                        .Select(project => workspace.OpenProjectAsync(project.AbsolutePath).Result)
                                        .Cast<Microsoft.Build.Evaluation.Project>() // Добавьте эту строку
                                        .ToList();
                        
            return solutionProjects;
        }
    }
}
