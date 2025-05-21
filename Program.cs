using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AddoSamples.Actions;
using AddoSamples.DomainModel;
using Microsoft.Extensions.Configuration;

namespace AddoSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = BuildConfiguration(args);
            var context = new Context
            {
                BaseUrl = configuration["BaseUrl"],
            };

            // Login - you should do the before anything else.
            // Remember, the token is short lived (10 minutes).
            new Login(context).Execute(configuration["Email"], configuration["Password"]);

            // Select one below:
            // var signingToken = CreateSigningRequest(configuration, context);
            //PrintSigningDetails(context, signingToken);

            //ListOverview(configuration, context);

            GetLatestCompletedSigning(configuration, context);
            // End-select
        }

        static IConfiguration BuildConfiguration(string[] args)
        {
            return new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile("credentials.json", optional: false, reloadOnChange: true)
                        .AddEnvironmentVariables()
                        .AddCommandLine(args)
                        .Build();
        }

        static string CreateSigningRequest(IConfiguration configuration, Context context)
        {
            var template = new GetSigningTemplate(context).Execute(configuration["Template"]);
            var recipient = new AddoRecipient
            {
                Email = configuration["RecipientEmail"],
                Name = configuration["RecipientName"],
            };

            const string filename = "TestDocument.pdf";
            var document = File.ReadAllBytes(filename);
            var signingData = new AddoSigningData();
            signingData.Documents.Add(new AddoDocument(document, filename));
            signingData.Recipients.Add(recipient);

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var signingId = new CreateSigningRequest(context).Execute(template, signingData);
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            Console.WriteLine("Signing Token of newly created signing request: {0}", signingId);
            Console.WriteLine("RunTime: {0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            return signingId;
        }

        static void ListOverview(IConfiguration configuration, Context context)
        {
            var overview = new GetOverview(context).Execute();
            const string formatter = "{0,-24}{1,-14}{2,-24}{3,-24}{4}";
            Console.WriteLine(formatter, "Signing Token", "Status", "Created", "Expires", "Reference number");
            foreach (var item in overview)
            {
                Console.WriteLine(formatter,
                    item.Token,
                    item.State.ToString(),
                    item.CreatedOn,
                    item.ExpiresOn,
                    item.ReferenceNumber ?? string.Empty);
            }
        }

        static void GetLatestCompletedSigning(IConfiguration configuration, Context context)
        {
            // I'm lying here. This will not be the latest completed signing.
            // This is the completed signing of the latest created signing.
            var overview = new GetOverview(context).Execute();
            var signing = overview.FirstOrDefault(x => x.State == AddoSigningState.Completed);
            if (signing == null)
            {
                Console.WriteLine("No signings completed");
                return;
            }

            PrintSigningDetails(context, signing.Token);
        }

        static void PrintSigningDetails(Context context, string signingToken)
        {
            var details = new GetSigningDetails(context).Execute(signingToken);
            Console.WriteLine("Signing token:    '{0}'", details.SigningToken);
            Console.WriteLine("Signing name:     '{0}'", details.Name);
            Console.WriteLine("Reference number: '{0}'", details.ReferenceNumber);
            Console.WriteLine("Documents:");
            var docIdx = 1;
            foreach (var document in details.Documents)
            {
                Console.WriteLine("\t{0}", document.Name);
                File.WriteAllBytes($"c:\\temp\\{docIdx}-{document.Name}", document.Data);
                docIdx++;
            }
            Console.WriteLine("Recipients:");
            foreach (var recipient in details.Recipients)
            {
                Console.WriteLine("\t{0}", recipient.Name);
            }
        }
    }
}
