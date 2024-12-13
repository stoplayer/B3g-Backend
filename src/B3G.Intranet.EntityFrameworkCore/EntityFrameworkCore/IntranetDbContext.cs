using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Saas.Editions;
using Volo.Saas.Tenants;
using Volo.Abp.Gdpr;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using B3G.Intranet.Clients;
using B3G.Intranet.Projects;
using B3G.Intranet.Tasks;
using B3G.Intranet.CRAs;

namespace B3G.Intranet.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityProDbContext))]
[ReplaceDbContext(typeof(ISaasDbContext))]
[ConnectionStringName("Default")]
public class IntranetDbContext :
    AbpDbContext<IntranetDbContext>,
    IIdentityProDbContext,
    ISaasDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // SaaS
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Edition> Editions { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public DbSet<Client> Clients { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<CRA> CRAs { get; set; }
    public DbSet<EmployeeTask> EmployeeTasks { get; set; }




    public IntranetDbContext(DbContextOptions<IntranetDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentityPro();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureLanguageManagement();
        builder.ConfigureSaas();
        builder.ConfigureTextTemplateManagement();
        builder.ConfigureBlobStoring();
        builder.ConfigureGdpr();

        /* Configure your own tables/entities inside here */

        builder.Entity<Client>(b =>
        {
            b.ToTable(IntranetConsts.DbTablePrefix + "Clients",
                IntranetConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });

        builder.Entity<Project>(b =>         
        {
            b.ToTable(IntranetConsts.DbTablePrefix + "Projects",
                IntranetConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.ClientId).IsRequired();
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            b.Property(x => x.Description).HasMaxLength(2048);
            b.Property(x => x.Budget).IsRequired();
            b.Property(x => x.EstimatedEndDate).IsRequired();
        });

        builder.Entity<TaskItem>(b =>
         {
                b.ToTable(IntranetConsts.DbTablePrefix + "Tasks",
                    IntranetConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.ProjectId).IsRequired();
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
                b.Property(x => x.Description).IsRequired().HasMaxLength(1024);
                b.Property(x => x.EstimatedEndDate).IsRequired();
                b.Property(x => x.EndDate).IsRequired();
                b.Property(x => x.Status).IsRequired();
        });

        builder.Entity<CRA>(b =>
        {
            b.ToTable(IntranetConsts.DbTablePrefix + "CRAs",
                IntranetConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.TaskId).IsRequired();
            b.Property(x => x.EmployeeId).IsRequired();
            b.Property(x => x.TimeSpent).IsRequired();
            b.Property(x => x.TimeStamp).IsRequired();
        });

        builder.Entity<EmployeeTask>(b =>
        {
            b.HasKey(et => new { et.TaskId, et.EmployeeId });
        });

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(IntranetConsts.DbTablePrefix + "YourEntities", IntranetConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
