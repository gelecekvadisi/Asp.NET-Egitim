//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PortfolioProject.Models.Entity
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public partial class Portfolio
	{
		public int ID { get; set; }
		[Required(ErrorMessage = "Bu alan� bo� ge�emezsiniz")]
		public string Title { get; set; }
		[Required(ErrorMessage = "Bu alan� bo� ge�emezsiniz")]
		[StringLength(100, ErrorMessage = "L�tfen en fazla 100 karakterlik veri giri�i yap�n�z")]
		public string Image { get; set; }
		public Nullable<System.DateTime> AddDate { get; set; }
	}
}
