﻿using NixWebApplication.DAL.Interfaces;
using NixWebApplication.DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixWebApplication.BLL.Infrastructure
{
    public class DependencyModule : NinjectModule
    {
        private string connectionString;

        public DependencyModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IWorkUnit>().To<EFWorkUnit>().WithConstructorArgument(connectionString);
        }
    }
}
