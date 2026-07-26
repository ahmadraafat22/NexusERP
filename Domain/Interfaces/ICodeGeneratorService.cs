using NexusERP.Domain.Common.Enums;

namespace NexusERP.Domain.Interfaces
{
    public interface ICodeGeneratorService
    {
        Task<string> GenerateCodeAsync(CodeType type);
    }
}
