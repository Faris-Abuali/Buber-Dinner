using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIds(builder);
        ConfigureMenuReviewIds(builder);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(m => m.Id);

        builder
            .Property(m => m.Id)
            .ValueGeneratedNever() // because we are using ValueObjects for Ids to generate them
            .HasConversion(
                id => id.Value,
                id => MenuId.Create(id));

        builder
            .Property(m => m.Name)
            .HasMaxLength(100);

        builder
            .Property(m => m.Description)
            .HasMaxLength(100);

        // Owned Entity Type Configuration
        builder.OwnsOne(m => m.AverageRating);

        // builder.OwnsOne(m => m.AverageRating, averageRatingBuilder =>
        // {
        //     averageRatingBuilder.Property(ar => ar.Value)
        //         .HasColumnName("AverageRating");
        //     
        //     averageRatingBuilder.Property(ar => ar.NumberOfRatings)
        //         .HasColumnName("NumberOfRatings");
        // });


        builder
            .Property(m => m.HostId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                id => HostId.Create(id));

        // Leave Datetime fields take the default values.
    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Sections, sb =>
        {
            sb.ToTable("MenuSections");

            // Foreign Key reference to Menu
            sb
                .WithOwner()
                .HasForeignKey("MenuId");

            // Wa want the primary key to be composite of both MenuSectionId & MenuId
            sb.HasKey("Id", "MenuId");
            // Remember: `Id` comes from the MenuSection entity,
            // and `MenuId` is the foreign key referencing `Menus` table.

            // We want the MenuSection.Id to have the name "MenuSectionId" in the database:
            sb
                .Property(ms => ms.Id)
                .HasColumnName("MenuSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value));

            sb
                .Property(ms => ms.Name)
                .HasMaxLength(100);

            sb
                .Property(ms => ms.Description)
                .HasMaxLength(100);

            // 💃 Time to configure the MenuItems table:
            ConfigureMenuItemsTable(sb);
        });

        // Tell EF Core to use the "private field" as the backing field of the navigation property.
        builder.Metadata
            .FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuItemsTable(OwnedNavigationBuilder<Menu, MenuSection> sb)
    {
        sb.OwnsMany(s => s.Items, menuItemsBuilder =>
        {
            menuItemsBuilder.ToTable("MenuItems");
            //         
            // Foreign Key reference to MenuSection
            menuItemsBuilder
                .WithOwner()
                .HasForeignKey("MenuSectionId", "MenuId");

            // Wa want the primary key to be composite of `MenuSectionId` & `MenuId` & `Id`
            menuItemsBuilder.HasKey("Id", "MenuId", "MenuSectionId");
            // Remember: `Id` comes from the MenuItem entity,
            // and `MenuId` is the foreign key referencing `Menus` table.
            // and `MenuSectionId` is the foreign key referencing `MenuSections` table.

            // We want the MenuItem.Id to have the name "MenuItemId" in the database:
            menuItemsBuilder
                .Property(mi => mi.Id)
                .HasColumnName("MenuItemId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuItemId.Create(value));

            menuItemsBuilder
                .Property(ms => ms.Name)
                .HasMaxLength(100);

            menuItemsBuilder
                .Property(ms => ms.Description)
                .HasMaxLength(100);
        });

        // Tell EF Core to use the "private field" as the backing field of the navigation property.
        sb
            .Navigation(s => s.Items)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .Metadata
            .SetField("_items");
    }

    private void ConfigureMenuDinnerIds(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, dinnerIdsBuilder =>
        {
            dinnerIdsBuilder.ToTable("MenuDinnerIds");

            // We want the Value Object's value to have the name "DinnerId" in the database:
            dinnerIdsBuilder
                .Property(d => d.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();

            // Foreign Key reference to Menu
            dinnerIdsBuilder
                .WithOwner()
                .HasForeignKey("MenuId");

            // primary key: Auto Increment Id
            dinnerIdsBuilder.HasKey("Id");
        });

        // Tell EF Core to use the "private field" as the backing field of the navigation property.
        builder.Metadata
            .FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuReviewIds(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, menuReviewIdsBuilder =>
        {
            menuReviewIdsBuilder.ToTable("MenuReviewIds");

            // We want the Value Object's value to have the name "MenuReviewId" in the database:
            menuReviewIdsBuilder
                .Property(mr => mr.Value)
                .HasColumnName("MenuReviewId")
                .ValueGeneratedNever();

            // Foreign Key reference to Menu
            menuReviewIdsBuilder
                .WithOwner()
                .HasForeignKey("MenuId");

            // primary key: Auto Increment Id
            menuReviewIdsBuilder.HasKey("Id");
        });

        // Tell EF Core to use the "private field" as the backing field of the navigation property.
        builder.Metadata
            .FindNavigation(nameof(Menu.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}