﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HackNet.Data
{
	public partial class UserKeyStore
	{
		[Key]
		[ForeignKey("User")]
		public int UserId { get; set; } 

		public string RsaPub { get; set; } // Blank array if not enabled

		public byte[] RsaPriv { get; set; } // Blank array if not enabled

		public byte[] AesIv { get; set; } // Blank array if not enabled

		public byte[] DesIv { get; set; }

		public string TOTPSecret { get; set; } // Null if not enabled

		// Foreign key references
		public virtual Users User { get; set; }

	}
}