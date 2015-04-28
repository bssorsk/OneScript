﻿/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StandaloneRunner
{
    class Program
    {
        static int Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            return Run(args);

        }

        private static int Run(string[] args)
        {
            var sp = new StandaloneProcess();
            sp.CommandLineArguments = args;
            return sp.Run();
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string resourceName = "StandaloneRunner." + new AssemblyName(args.Name).Name + ".dll";

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                byte[] asmData = new byte[stream.Length];
                stream.Read(asmData, 0, asmData.Length);
                return Assembly.Load(asmData);
            }

        }
    }
}
