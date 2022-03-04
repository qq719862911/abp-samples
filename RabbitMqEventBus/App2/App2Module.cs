using Volo.Abp.Autofac;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;
using Volo.Abp.RabbitMQ;

namespace App2
{
    [DependsOn(
        typeof(AbpEventBusRabbitMqModule),
        typeof(AbpAutofacModule)
        )]
    public class App2Module : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpRabbitMqOptions>(options =>
            {
                
               
                options.Connections.Default.DispatchConsumersAsync = true;
                options.Connections.Default.HostName = "192.168.26.106";
                
                options.Connections.Default.UserName = "haiyiguo";
                options.Connections.Default.Password = "haiyiguo";
                options.Connections.Default.VirtualHost = "/";
                options.Connections.Default.Port = 5672;
                // if the port is default ,not to set, the default port is 5672 rather web port 15672
            });
            Configure<AbpRabbitMqEventBusOptions>(options =>
            {
                options.ClientName = "TestApp2";
                options.ExchangeName = "TestMessages";
            });
        }
    }
}