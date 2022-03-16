using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace interview_test_angular.Configuration
{
    public class AutoFacModule : Autofac.Module
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacModule"/> class.
        /// </summary>
        /// <param name="configuration">The Configuration.</param>
        /// <param name="logger">The Logger.</param>
        public AutoFacModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // Registers classes that will read from the appsettings or config store
            RegisterApplicationConfig(builder, configuration);
        }

        /// <inheritdoc />
        protected void RegisterApplicationConfig(ContainerBuilder builder, IConfiguration configuration)
        {
            // Registration of mediatr which is a direct concern of this API 
            builder.RegisterMediatR(typeof(Mediatr.InjectionPlaceholder).GetTypeInfo().Assembly);

            builder.RegisterApplicationConfig(configuration);
        }

        protected IEnumerable<Type> RegisterAdditionalDependencies()
        {
            var dependencies = RegisterAdditionalDependencies().ToList();

            dependencies.Add(typeof(Mediatr.InjectionPlaceholder));

            return dependencies;
        }
    }
}
