using System.Security.Claims;
using Core.Abstractions;
using Core.Enums;

namespace Web.Authentication;

public class UserContext : IUserContext
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="httpContextAccessor">Http контекст</param>
		public UserContext(IHttpContextAccessor httpContextAccessor)
			=> _httpContextAccessor = httpContextAccessor;

		/// <inheritdoc/>
		public long CurrentUserId => long.TryParse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId)
			? userId
			: 0;

		/// <inheritdoc />
		public string? Username => User?.FindFirst(ClaimNames.Username)?.Value;

		/// <inheritdoc />
		public string? Email => User?.FindFirst(ClaimTypes.Email)?.Value;

		/// <inheritdoc />
		public string? DisplayName => User?.FindFirst(ClaimNames.DisplayName)?.Value;
		
		/// <inheritdoc />
		public ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;
	}
