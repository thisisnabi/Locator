namespace Locator.Common;

public class AppSettings
{
    public MongoDbSetting MongoDbSetting { get; set; } = null!;

    public Features Features { get; set; } = null!;
}

public class MongoDbSetting
{
    public string Host { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;
}


public partial class Features
{ 

}