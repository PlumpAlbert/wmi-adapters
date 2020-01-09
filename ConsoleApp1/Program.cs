using System;
using System.Collections.Generic;
using System.Management;
using Microsoft.Management.Infrastructure;
using Microsoft.Management.Infrastructure.Options;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string Namespace = @"root\cimv2";
            //string query = "SELECT * FROM Win32_NetworkAdapter";
            //string username = "Administrator";
            //string password = "matthew";
            //var securePassword = new System.Security.SecureString();
            //foreach (var c in password)
            //    securePassword.AppendChar(c);

            //var credentials = new CimCredential(PasswordAuthenticationMechanism.Default, "", username, securePassword);

            //var options = new WSManSessionOptions();
            //options.AddDestinationCredentials(credentials);
            //CimSession session = CimSession.Create("SERVER", options);

            //IEnumerable<CimInstance> queryInstance = session.QueryInstances(Namespace, "WQL", query);

            //foreach (CimInstance cimObj in queryInstance)
            //{
            //    Console.WriteLine(cimObj.CimInstanceProperties["Name"].ToString());
            //    Console.WriteLine(cimObj.CimInstanceProperties["Description"].ToString());
            //    Console.WriteLine();
            //}
            //Console.ReadLine();
            oldSchoolQueryInstanceFunc();
        }

        static void oldSchoolQueryInstanceFunc()
        {
            ConnectionOptions options = new ConnectionOptions() { 
                Username = "Administrator",
                Password = "matthew",
                Authentication = AuthenticationLevel.Default,
                Impersonation = ImpersonationLevel.Impersonate,
                EnablePrivileges = true
            };
            ManagementScope scope = new ManagementScope("\\\\192.168.150.2\\root\\cimv2", options);
            scope.Connect();
            //ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            //ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            ManagementObjectCollection queryCollection = searcher.Get();
            foreach (ManagementObject m in queryCollection)
            {
                //if (m["NetEnabled"] == null)
                //{
                //    Console.WriteLine("HUI");
                //    continue;
                //}
                Console.WriteLine("[{0}] {1} - {2}", m["Index"], m["Name"], m["Status"]);
                //Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
