using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace SampleAPI.Services.Registry
{
    public class ServicesStructureMapRegistry : StructureMap.Registry
    {
        public ServicesStructureMapRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.AddAllTypesOf(typeof(IRequestHandler<,>));
                scan.AddAllTypesOf(typeof(IAsyncRequestHandler<>));
                scan.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>)); // Handlers with a response
                scan.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>)); // Async Handlers with a response
            });
        }
    }
}
