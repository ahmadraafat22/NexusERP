using Microsoft.EntityFrameworkCore;
using NexusERP.Domain.Common.Enums;
using NexusERP.Domain.Interfaces;
using NexusERP.Infrasructure.Persistence;

namespace NexusERP.Infrasructure.Services
{
    public class CodeGeneratorService : ICodeGeneratorService
    {
        private readonly AppDbContext _context;

        public CodeGeneratorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> GenerateCodeAsync(CodeType type)
        {
            var sequenceName = GetSequenceName(type);
            string prefix = GetPrefix(type);

            await using var command = _context.Database.GetDbConnection().CreateCommand();

            command.CommandText = $" SELECT NEXT VALUE FOR {sequenceName}";

            if (command.Connection.State != System.Data.ConnectionState.Open)
            {
                await command.Connection.OpenAsync();
            }
            var result = await command.ExecuteScalarAsync();
            var number = Convert.ToInt32(result);

            return $"{prefix}-{number:D6}";
        }

        private static string GetSequenceName(CodeType type)
        {   //              CustomerSequence
            return $"{type}Sequence";
        }
        private static string GetPrefix(CodeType type)
        {

            switch (type)
            {
                case CodeType.Customer:
                    return "CUS";
                case CodeType.Supplier:
                    return "SUP";
                default:
                    throw new ArgumentException("not supported type ");
            }
        }

    }
}
