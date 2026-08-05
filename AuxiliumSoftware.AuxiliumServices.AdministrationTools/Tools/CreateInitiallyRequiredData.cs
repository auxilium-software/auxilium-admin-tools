using AuxiliumSoftware.AuxiliumServices.AdministrationTools.Common;
using AuxiliumSoftware.AuxiliumServices.Common.EntityFramework.EntityModels;
using AuxiliumSoftware.AuxiliumServices.Common.Enumerators;
using AuxiliumSoftware.AuxiliumServices.Common.Services;
using AuxiliumSoftware.AuxiliumServices.Common.Services.Implementations;
using AuxiliumSoftware.AuxiliumServices.Common.Utilities;
using Konscious.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Security.Cryptography;
using System.Text.Json;

namespace AuxiliumSoftware.AuxiliumServices.AdministrationTools.Tools;

public sealed class SetInitiallyRequiredData(
    IConfiguration configuration,
    IPasswordService passwordService
) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext context, CancellationToken cancellationToken)
    {

        using var dbContext = MariaDBInteractions.GetDbContext(configuration);

        dbContext.DataEnumerator_Enumerators.Add(new()
        {
            Id = UUIDUtilities.GenerateV5(objectType: DatabaseObjectTypeEnum.System_SettingEntry),
            CreatedAtUtc = DateTime.UtcNow,
            CreatedByUserId = null,
            Scope = AuxiliumServices.Common.EntityFramework.Enumerators.DataEnumeratorScopeEnum.CalendarEventCategory,
            CanonicalName = "/data-enumerator/builtin/calendar-event-category",
            IsActive = true,
        });

        await dbContext.SaveChangesAsync(cancellationToken);

        return 0;
    }
}
