

namespace eCommerce.Core.DTO
{
    public record AuthencationResponse
    (Guid UserID, string? Email, string? PersonName, string? Gender, string? Token, bool Sucess)
    {
        public AuthencationResponse() : this(default, default, default, default, default, default)
        { 
        
        }
    };
}
