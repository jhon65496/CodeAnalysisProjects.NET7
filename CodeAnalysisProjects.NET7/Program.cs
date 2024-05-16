using CodeAnalysisProjects.NET7.Services;
using Microsoft.Build.Evaluation;

namespace CodeAnalysisProjects.NET7
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Test1();
        }

        
        static void Test1()
        {
            string path = @"e:\Projects\WPF\4587\01_pr\01\github.com\WPFCrudControl-master\fl\GenericCodes.WPF.sln";

            List<Project> table = ProjectAnalysisService.GetProjects(path);            
        }
    }
}