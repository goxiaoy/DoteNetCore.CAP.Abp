using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.Modularity;

namespace DotNetCore.CAP.Abp
{

    [DependsOn(typeof(AbpEventBusModule))]
    public class CapModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            context.Services.AddCap(x =>
            {
                configuration.GetSection("CAP").Bind(x);
                context.Services.ExecutePreConfiguredActions<CapOptions>(x);
            });
        }


    }
}
