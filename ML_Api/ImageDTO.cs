using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ML_Api
{
	public class ImageDTO
	{
		[Required]
		public int version { get; set; }

		[Required]
		public string base64 { get; set; }
	}
}
