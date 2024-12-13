using Volo.Abp.Identity;

namespace B3G.Intranet;

public static class IntranetConsts
{
    public const string DbTablePrefix = "App";
    public const string DbSchema = null;
    public const string AdminEmailDefaultValue = IdentityDataSeedContributor.AdminEmailDefaultValue;
    public const string AdminPasswordDefaultValue = IdentityDataSeedContributor.AdminPasswordDefaultValue;
}
