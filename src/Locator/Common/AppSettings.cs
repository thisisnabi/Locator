namespace Locator.Common;

public class AppSettings
{
    public MongoDbSetting MongoDbSetting { get; set; } = null!;

    public Features Features { get; set; } = null!;

    public RabbitMqConfigurations RabbitMqConfigurations { get; set; }
}

public class MongoDbSetting
{
    public string Host { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;
}


public partial class Features
{

}


public class RabbitMqConfigurations
{
    public string Host { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
