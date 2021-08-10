using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ViGraph.Models
{
	public enum Language
	{
		TR,
		EN
	}

	public class AppUser : IdentityUser
	{
		[Required]
		[MaxLength(255)]
		public string FullName { get; set; }

		[Column(TypeName = "enum('TR','EN')")]
		public Language Language { get; set; }

		public DateTime? LastLogin { get; set; } = null;

		public string LastLoginIP { get; set; } = null;

		public DateTime? LastLogout { get; set; } = null;

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		public DateTime? UpdatedAt { get; set; } = null;

		public DateTime? DeletedAt { get; set; } = null;
	}
}
