using System;

namespace ViGraph.Models.DTO
{
	public class AppUserDTO
	{
		public int Id { get; set; }

		public string FullName { get; set; }

		public string Email { get; set; }

		public string RoleName { get; set; }

		public string RoleSef { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? DeletedAt { get; set; } = null;

		public string ActionsHTML { get; set; }
	}
}
