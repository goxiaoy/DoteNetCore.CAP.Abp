This is a repository integrated [CAP](https://github.com/dotnetcore/CAP/) with [ABP](https://github.com/abpframework/abp)

### Storage

#### Use entity framework
```
    PreConfigure<CapOptions>(options =>
    {
        options.UseEntityFramework<YourDbContext>();
    });
```
#### Use mongodb
```
    PreConfigure<CapOptions>(options =>
    {
        options.UseMongoDB("Your ConnectionStrings");  //MongoDB 4.0+ cluster
    });

```

### EventBus

#### Use rabbitMQ
```
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        PreConfigure<CapOptions>(options =>
        {
            options.UseRabbitMQ(rabbitMQOptions =>
            {
                configuration.GetSection("CAP:RabbitMQ").Bind(rabbitMQOptions);
            });

        });
    }
```
#### Use kafka
```
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        PreConfigure<CapOptions>(options =>
        {
            options.UseKafka("ConnectionString");
        });
    }
```



