namespace IdentityServer.Data.Models;

public class Organization : Item<Organization>
{
    public string Name
    {
        get; set;
    }
    public string Description
    {
        get; set;
    }

    public Organization(string name, string description = "")
    {
        Name = name;
        Description = description;
    }

    public override string Pk => $"ORG#${this.Name}";

    public override string Sk => $"ORG#${this.Name}";


    public override Organization ToItem()
    {
        return this;
    }
}
