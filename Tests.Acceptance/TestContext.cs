using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Tests.Acceptance.Infrastructure;

namespace Tests.Acceptance
{
    [Binding]
    static class TestContext
    {
        const string RelativePath = "IIS Express\\iisexpress.exe";

        const string Port = "53735";
        private static Process _expressProcess;

        [BeforeTestRun()]
        public static void BeforeTestRun()
        {
            StartExpress();
            Service.Instance.RegisterValueRetriever(new SpanValueRetriever());
        }

        [AfterTestRun()]
        public static void AfterTestRun()
        {
            StopProcess(_expressProcess);
        }

        private static void StartExpress()
        {
            var sitePath = Path.Combine(GetSolutionPath(), "API");
            var arguments = string.Format(CultureInfo.InvariantCulture, "/path:\"{0}\" /port:{1}", sitePath, Port);

            _expressProcess = StartProcess(GetExpressPath(), arguments);
        }

        private static Process StartProcess(string path, string args = "")
        {
            var startInfo = new ProcessStartInfo(path)
            {
                WindowStyle = ProcessWindowStyle.Normal,
                ErrorDialog = true,
                LoadUserProfile = true,
                CreateNoWindow = false,
                UseShellExecute = true,
                Arguments = args
            };

            return Process.Start(startInfo);
        }


        private static void StopProcess(Process process)
        {
            if ((process.HasExited == false))
            {
                process.Kill();
                process.Dispose();
            }
        }

        private static string GetExpressPath()
        {
            var key = (Environment.Is64BitOperatingSystem ? "ProgramFiles(x86)" : "ProgramFiles");
            var programFiles = Environment.GetEnvironmentVariable(key);

            return Path.Combine(programFiles, RelativePath);
        }

        private static string GetSolutionPath()
        {

            var dir = new DirectoryInfo(Environment.CurrentDirectory);

            while (!dir.GetFiles().Any(IsSolutionDirectory))
            {
                dir = dir.Parent;
            }

            return dir.FullName;

        }

        private static bool IsSolutionDirectory(FileInfo file)
        {
            return file.Extension.Equals(".sln", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}