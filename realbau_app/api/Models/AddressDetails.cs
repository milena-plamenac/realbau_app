namespace realbau_app.api.Models
{
	public class AddressDetails
	{
		public int? id { get; set; }
		public DateTime? orderdate { get; set; }
		public int? orderid { get; set; }
		public float? projectcode { get; set; }
		public string? projectname { get; set; }
		public string? areapop { get; set; }
		public int? dp { get; set; }
		public string? city { get; set; }
		public string? tzip { get; set; }
		public string? street { get; set; }
		public int? housenumber { get; set; }
		public int? unit { get; set; }
		public int? dpfinish { get; set; }
		public int? popfinish { get; set; }
		public string? comment { get; set; }
		public DateTime? connectiondate { get; set; }
		public DateTime? completiondate { get; set; }
		public int? arsstatus { get; set; }
		public string? provider { get; set; }
		public int? co_id { get; set; }
		public string? firstname { get; set; }
		public string? name { get; set; }
		public string? phone { get; set; }
		public string? phone2 { get; set; }
		public string? email { get; set; }
		public string? status { get; set; }
		public int? servicepackage { get; set; }
		public string? zusat { get; set; }
		public string? bestellnummer { get; set; }
		public string? IP_ODF { get; set; }
		public string? IP_Port { get; set; }
		public string? TV_ODF { get; set; }
		public string? kennwort { get; set; }
		public string? subtype { get; set; }

		public int? hbId { get; set; }
		public DateOnly? hbdate { get; set; }
		public TimeSpan? hbfrom { get; set; }
		public TimeSpan? hbto { get; set; }
		public DateTime? hbcalldate { get; set; }
		public int? hbfinished { get; set; }

		public int? tId { get; set; }
		public DateTime? tdate { get; set; }
		public int? meter { get; set; }
		public int? tfinished { get; set; }


		public DateTime? fdate { get; set; }
		public int? ffinished { get; set; }

		public int? mId { get; set; }
		public DateOnly? mdate { get; set; }
		public TimeSpan? mfrom { get; set; }
		public TimeSpan? mto { get; set; }
		public DateTime? mcalldate { get; set; }
		public int? mfinished { get; set; }

		public int? aId { get; set; }
		public DateOnly? adate { get; set; }
		public TimeSpan? afrom { get; set; }
		public TimeSpan? ato { get; set; }
		public int? afinished { get; set; }


	}
}
