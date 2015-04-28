﻿/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/
using ScriptEngine.Environment;
using ScriptEngine.Machine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ScriptEngine.Compiler
{
    public class ModulePersistor
    {
        IFormatter _formatter;

        public ModulePersistor (IFormatter format)
	    {
            _formatter = format;
	    }

        public void Save(ScriptModuleHandle module, Stream output)
        {
            _formatter.Serialize(output, FromHandle(module));
        }

        public ScriptModuleHandle Read(Stream input)
        {
            var moduleImage = (ModuleImage)_formatter.Deserialize(input);
            return new ScriptModuleHandle()
            {
                Module = moduleImage
            };
        }

        private ModuleImage FromHandle(ScriptModuleHandle module)
        {
            return module.Module;
        }
    }
}
