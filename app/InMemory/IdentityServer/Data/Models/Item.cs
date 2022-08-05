using System;

namespace IdentityServer.Data.Models;

public abstract class Item<T>
{
    public abstract string Pk
    {
        get;
    }
    public abstract string Sk
    {
        get;
    }

    public DynamoDbKeys Keys() => new DynamoDbKeys() { PK = this.Pk, SK = this.Sk };

    public abstract T ToItem();
}


public class DynamoDbKeys
{
    public string PK
    {
        get; set;
    }
    public string SK
    {
        get; set;
    }
}