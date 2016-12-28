﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HackNet.Data
{
	public partial class Logs
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string LogId { get; set; }

		[Required]
		public int Severity { get; set;}

		[Required]
		public int Type { get; set; }

		public DateTime Timestamp { get; set; }

		public string IpAddress { get; set; }

		[Required]
		public string Description { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }

		// Foreign key references
		public virtual Users User { get; set; }
    }


}