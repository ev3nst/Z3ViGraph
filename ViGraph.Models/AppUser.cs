﻿using System;
using System.Collections.Generic;
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

	public class AppUser : IdentityUser<int>
	{
		[Required]
		[MaxLength(255)]
		public string FullName { get; set; }

		[Column(TypeName = "enum('TR','EN')")]
		public Language Language { get; set; } = Language.TR;

		public DateTime? LastLogin { get; set; } = null;

		public string LastLoginIP { get; set; } = null;

		public DateTime? LastLogout { get; set; } = null;

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		public DateTime? UpdatedAt { get; set; } = null;

		public DateTime? DeletedAt { get; set; } = null;

        public virtual ICollection<AppUserRole> UserRoles { get; set; }

        #region Ignored Default Fields
		[NotMapped]
		public override string NormalizedEmail { get; set; }

		[NotMapped]
		public override bool EmailConfirmed { get; set; }

		[NotMapped]
		public override string ConcurrencyStamp { get; set; }

		[NotMapped]
		public override string PhoneNumber { get; set; }

		[NotMapped]
		public override bool PhoneNumberConfirmed { get; set; }

		[NotMapped]
		public override bool TwoFactorEnabled { get; set; }

		[NotMapped]
		public override int AccessFailedCount { get; set; }
        #endregion
	}
}
