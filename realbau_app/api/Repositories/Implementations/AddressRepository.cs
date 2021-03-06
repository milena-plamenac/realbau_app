using Microsoft.Data.SqlClient;
using realbau_app.api.Models;
using realbau_app.api.Repositories.Interfaces;

namespace realbau_app.api.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        public async Task<IEnumerable<AddressDetails>> GetAddresses()
        {
            List<AddressDetails> result = new List<AddressDetails>();

            try
            {
                using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    con.Open();
                    var cmd = new SqlCommand(@"select a.*, 
                                                h.id as hbId,  h.hbdate, h.hbfrom, h.hbto, h.calldate as hbcalldate, h.finished as hbfinished, h.hbcomment,
                                                t.id as tId, t.tdate, t.meter, t.ready as tready, t.finished as tfinished, t.tcomment,
                                                f.fdate, f.finished as ffinished, f.fcomment,
                                                m.id as mId,  m.mdate, m.mfrom, m.mto, m.calldate as mcalldate, m.finished as mfinished, m.mcomment,
                                                ak.id as aId,  ak.adate, ak.afrom, ak.ato, ak.finished as afinished, ak.acomment,
                                                v.vdate, v.finished as vfinished, v.vcomment
                            from dbo.address a
                            inner
                            join dbo.hausbegehung h on a.id = h.address_id
                            inner
                            join dbo.tiefbau t on a.id = t.address_id
                            inner
                            join dbo.faser f on a.id = f.address_id
                            inner
                            join dbo.montaze m on a.id = m.address_id
                            inner
                            join dbo.aktivirung ak on a.id = ak.address_id
                            inner
                            join dbo.vermessung v on a.id = v.address_id", con);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        AddressDetails address = new AddressDetails();

                        address.id = Convert.IsDBNull(reader["id"]) ? 0 : (int)reader["id"];

                        address.orderdate = Convert.IsDBNull(reader["orderdate"]) ? null : (DateTime?)reader["orderdate"];
                        address.orderid = Convert.IsDBNull(reader["orderid"]) ? null : (int?)reader["orderid"];
                        address.projectcode = Convert.IsDBNull(reader["projectcode"]) ? null : Convert.ToSingle(reader["projectcode"]);
                        address.projectname = Convert.IsDBNull(reader["projectname"]) ? null : (string?)reader["projectname"];
                        address.areapop = Convert.IsDBNull(reader["areapop"]) ? null : (string?)reader["areapop"];
                        address.dp = Convert.IsDBNull(reader["dp"]) ? null : (int?)reader["dp"];
                        address.city = Convert.IsDBNull(reader["city"]) ? null : (string?)reader["city"];
                        address.tzip = Convert.IsDBNull(reader["tzip"]) ? null : (string?)reader["tzip"];
                        address.street = Convert.IsDBNull(reader["street"]) ? null : (string?)reader["street"];
                        address.housenumber = Convert.IsDBNull(reader["housenumber"]) ? null : (int?)reader["housenumber"];
                        address.subnumber = Convert.IsDBNull(reader["subnumber"]) ? null : (string?)reader["subnumber"];
                        address.unit = Convert.IsDBNull(reader["unit"]) ? null : (int?)reader["unit"];
                        address.dpfinish = Convert.IsDBNull(reader["dpfinish"]) ? null : (int?)reader["dpfinish"];
                        address.popfinish = Convert.IsDBNull(reader["popfinish"]) ? null : (int?)reader["popfinish"];
                        address.comment = Convert.IsDBNull(reader["comment"]) ? null : (string?)reader["comment"];
                        address.connectiondate = Convert.IsDBNull(reader["connectiondate"]) ? null : (DateTime?)reader["connectiondate"];
                        address.completiondate = Convert.IsDBNull(reader["completiondate"]) ? null : (DateTime?)reader["completiondate"];
                        address.arsstatus = Convert.IsDBNull(reader["arsstatus"]) ? null : (int?)reader["arsstatus"];
                        address.provider = Convert.IsDBNull(reader["provider"]) ? null : (string?)reader["provider"];
                        address.co_id = Convert.IsDBNull(reader["co_id"]) ? null : (int?)reader["co_id"];
                        address.firstname = Convert.IsDBNull(reader["firstname"]) ? null : (string?)reader["firstname"];
                        address.name = Convert.IsDBNull(reader["name"]) ? null : (string?)reader["name"];
                        address.phone = Convert.IsDBNull(reader["phone"]) ? null : (string?)reader["phone"];
                        address.phone2 = Convert.IsDBNull(reader["phone2"]) ? null : (string?)reader["phone2"];
                        address.email = Convert.IsDBNull(reader["email"]) ? null : (string?)reader["email"];
                        address.status = Convert.IsDBNull(reader["status"]) ? null : (string?)reader["status"];
                        address.servicepackage = Convert.IsDBNull(reader["servicepackage"]) ? null : (int?)reader["servicepackage"];
                        address.zusat = Convert.IsDBNull(reader["zusat"]) ? null : (string?)reader["zusat"];
                        address.bestellnummer = Convert.IsDBNull(reader["bestellnummer"]) ? null : (string?)reader["bestellnummer"];
                        address.IP_ODF = Convert.IsDBNull(reader["IP_ODF"]) ? null : (string?)reader["IP_ODF"];
                        address.IP_Port = Convert.IsDBNull(reader["IP_Port"]) ? null : (string?)reader["IP_Port"];
                        address.TV_ODF = Convert.IsDBNull(reader["TV_ODF"]) ? null : (string?)reader["TV_ODF"];
                        address.kennwort = Convert.IsDBNull(reader["kennwort"]) ? null : (string?)reader["kennwort"];
                        address.subtype = Convert.IsDBNull(reader["subtype"]) ? null : (string?)reader["subtype"];

                        address.hbId = Convert.IsDBNull(reader["hbId"]) ? null : (int?)reader["hbId"];
                        address.hbdate = Convert.IsDBNull(reader["hbdate"]) ? null : (DateTime?)reader["hbdate"];
                        address.hbfrom = Convert.IsDBNull(reader["hbfrom"]) ? null : (DateTime?)reader["hbfrom"];
                        address.hbto = Convert.IsDBNull(reader["hbto"]) ? null : (DateTime?)reader["hbto"];
                        address.hbcalldate = Convert.IsDBNull(reader["hbcalldate"]) ? null : (DateTime?)reader["hbcalldate"];
                        address.hbfinished = Convert.IsDBNull(reader["hbfinished"]) ? null : (int?)reader["hbfinished"];
                        address.hbcomment = Convert.IsDBNull(reader["hbcomment"]) ? null : (string?)reader["hbcomment"];

                        address.tId = Convert.IsDBNull(reader["tId"]) ? null : (int?)reader["tId"];
                        address.tdate = Convert.IsDBNull(reader["tdate"]) ? null : (DateTime?)reader["tdate"];
                        address.meter = Convert.IsDBNull(reader["meter"]) ? null : (int?)reader["meter"];
                        address.tready = Convert.IsDBNull(reader["tready"]) ? null : (int?)reader["tready"];
                        address.tfinished = Convert.IsDBNull(reader["tfinished"]) ? null : (int?)reader["tfinished"];
                        address.tcomment = Convert.IsDBNull(reader["tcomment"]) ? null : (string?)reader["tcomment"];
                        address.fdate = Convert.IsDBNull(reader["fdate"]) ? null : (DateTime?)reader["fdate"];
                        address.ffinished = Convert.IsDBNull(reader["ffinished"]) ? null : (int?)reader["ffinished"];
                        address.fcomment = Convert.IsDBNull(reader["fcomment"]) ? null : (string?)reader["fcomment"];

                        address.mId = Convert.IsDBNull(reader["mId"]) ? null : (int?)reader["mId"];
                        address.mdate = Convert.IsDBNull(reader["mdate"]) ? null : (DateTime?)reader["mdate"];
                        address.mfrom = Convert.IsDBNull(reader["mfrom"]) ? null : (DateTime?)reader["mfrom"];
                        address.mto = Convert.IsDBNull(reader["mto"]) ? null : (DateTime?)reader["mto"];
                        address.mcalldate = Convert.IsDBNull(reader["mcalldate"]) ? null : (DateTime?)reader["mcalldate"];
                        address.mfinished = Convert.IsDBNull(reader["mfinished"]) ? null : (int?)reader["mfinished"];
                        address.mcomment = Convert.IsDBNull(reader["mcomment"]) ? null : (string?)reader["mcomment"];

                        address.aId = Convert.IsDBNull(reader["aId"]) ? null : (int?)reader["aId"];
                        address.adate = Convert.IsDBNull(reader["adate"]) ? null : (DateTime?)reader["adate"];
                        address.afrom = Convert.IsDBNull(reader["afrom"]) ? null : (DateTime?)reader["afrom"];
                        address.ato = Convert.IsDBNull(reader["ato"]) ? null : (DateTime?)reader["ato"];
                        address.afinished = Convert.IsDBNull(reader["afinished"]) ? null : (int?)reader["afinished"];
                        address.acomment = Convert.IsDBNull(reader["acomment"]) ? null : (string?)reader["acomment"];

                        address.vdate = Convert.IsDBNull(reader["vdate"]) ? null : (DateTime?)reader["vdate"];
                        address.vfinished = Convert.IsDBNull(reader["vfinished"]) ? null : (int?)reader["vfinished"];
                        address.vcomment = Convert.IsDBNull(reader["vcomment"]) ? null : (string?)reader["vcomment"];

                        result.Add(address);
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<AddressDetails> GetAddressById(int id)
        {
            AddressDetails address = new AddressDetails();

            try
            {
                using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    con.Open();
                    var cmd = new SqlCommand(@"
                            select a.*, 
                            h.id as hbId,  h.hbdate, h.hbfrom, h.hbto, h.calldate as hbcalldate, h.finished as hbfinished, h.hbcomment,
                            t.id as tId, t.tdate, t.meter, t.ready as tready, t.finished as tfinished, t.tcomment,
                            f.fdate, f.finished as ffinished, f.fcomment,
                            m.id as mId,  m.mdate, m.mfrom, m.mto, m.calldate as mcalldate, m.finished as mfinished, m.mcomment,
                            ak.id as aId,  ak.adate, ak.afrom, ak.ato, ak.finished as afinished, ak.acomment,
                            v.vdate, v.finished as vfinished, v.vcomment
                            from dbo.address a 
                            inner join dbo.hausbegehung h on a.id = h.address_id 
                            inner join dbo.tiefbau t on a.id = t.address_id
                            inner join dbo.faser f on a.id = f.address_id
                            inner join dbo.montaze m on a.id = m.address_id
                            inner join dbo.aktivirung ak on a.id = ak.address_id
                            inner join dbo.vermessung v on a.id = v.address_id
                            where a.id = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    if (reader.Read())
                    {
                        address.id = Convert.IsDBNull(reader["id"]) ? 0 : (int)reader["id"];
                        address.orderdate = Convert.IsDBNull(reader["orderdate"]) ? null : (DateTime?)reader["orderdate"];
                        address.orderid = Convert.IsDBNull(reader["orderid"]) ? null : (int?)reader["orderid"];
                        address.projectcode = Convert.IsDBNull(reader["projectcode"]) ? null : Convert.ToSingle(reader["projectcode"]);
                        address.projectname = Convert.IsDBNull(reader["projectname"]) ? null : (string?)reader["projectname"];
                        address.areapop = Convert.IsDBNull(reader["areapop"]) ? null : (string?)reader["areapop"];
                        address.dp = Convert.IsDBNull(reader["dp"]) ? null : (int?)reader["dp"];
                        address.city = Convert.IsDBNull(reader["city"]) ? null : (string?)reader["city"];
                        address.tzip = Convert.IsDBNull(reader["tzip"]) ? null : (string?)reader["tzip"];
                        address.street = Convert.IsDBNull(reader["street"]) ? null : (string?)reader["street"];
                        address.housenumber = Convert.IsDBNull(reader["housenumber"]) ? null : (int?)reader["housenumber"];
                        address.subnumber = Convert.IsDBNull(reader["subnumber"]) ? null : (string?)reader["subnumber"];
                        address.unit = Convert.IsDBNull(reader["unit"]) ? null : (int?)reader["unit"];
                        address.dpfinish = Convert.IsDBNull(reader["dpfinish"]) ? null : (int?)reader["dpfinish"];
                        address.popfinish = Convert.IsDBNull(reader["popfinish"]) ? null : (int?)reader["popfinish"];
                        address.comment = Convert.IsDBNull(reader["comment"]) ? null : (string?)reader["comment"];
                        address.connectiondate = Convert.IsDBNull(reader["connectiondate"]) ? null : (DateTime?)reader["connectiondate"];
                        address.completiondate = Convert.IsDBNull(reader["completiondate"]) ? null : (DateTime?)reader["completiondate"];
                        address.arsstatus = Convert.IsDBNull(reader["arsstatus"]) ? null : (int?)reader["arsstatus"];
                        address.provider = Convert.IsDBNull(reader["provider"]) ? null : (string?)reader["provider"];
                        address.co_id = Convert.IsDBNull(reader["co_id"]) ? null : (int?)reader["co_id"];
                        address.firstname = Convert.IsDBNull(reader["firstname"]) ? null : (string?)reader["firstname"];
                        address.name = Convert.IsDBNull(reader["name"]) ? null : (string?)reader["name"];
                        address.phone = Convert.IsDBNull(reader["phone"]) ? null : (string?)reader["phone"];
                        address.phone2 = Convert.IsDBNull(reader["phone2"]) ? null : (string?)reader["phone2"];
                        address.email = Convert.IsDBNull(reader["email"]) ? null : (string?)reader["email"];
                        address.status = Convert.IsDBNull(reader["status"]) ? null : (string?)reader["status"];
                        address.servicepackage = Convert.IsDBNull(reader["servicepackage"]) ? null : (int?)reader["servicepackage"];
                        address.zusat = Convert.IsDBNull(reader["zusat"]) ? null : (string?)reader["zusat"];
                        address.bestellnummer = Convert.IsDBNull(reader["bestellnummer"]) ? null : (string?)reader["bestellnummer"];
                        address.IP_ODF = Convert.IsDBNull(reader["IP_ODF"]) ? null : (string?)reader["IP_ODF"];
                        address.IP_Port = Convert.IsDBNull(reader["IP_Port"]) ? null : (string?)reader["IP_Port"];
                        address.TV_ODF = Convert.IsDBNull(reader["TV_ODF"]) ? null : (string?)reader["TV_ODF"];
                        address.kennwort = Convert.IsDBNull(reader["kennwort"]) ? null : (string?)reader["kennwort"];
                        address.subtype = Convert.IsDBNull(reader["subtype"]) ? null : (string?)reader["subtype"];

                        address.hbId = Convert.IsDBNull(reader["hbId"]) ? null : (int?)reader["hbId"];
                        address.hbdate = Convert.IsDBNull(reader["hbdate"]) ? null : (DateTime?)reader["hbdate"];
                        address.hbfrom = Convert.IsDBNull(reader["hbfrom"]) ? null : (DateTime?)reader["hbfrom"];
                        address.hbto = Convert.IsDBNull(reader["hbto"]) ? null : (DateTime?)reader["hbto"];
                        address.hbcalldate = Convert.IsDBNull(reader["hbcalldate"]) ? null : (DateTime?)reader["hbcalldate"];
                        address.hbfinished = Convert.IsDBNull(reader["hbfinished"]) ? null : (int?)reader["hbfinished"];
                        address.hbcomment = Convert.IsDBNull(reader["hbcomment"]) ? null : (string?)reader["hbcomment"];

                        address.tId = Convert.IsDBNull(reader["tId"]) ? null : (int?)reader["tId"];
                        address.tdate = Convert.IsDBNull(reader["tdate"]) ? null : (DateTime?)reader["tdate"];
                        address.meter = Convert.IsDBNull(reader["meter"]) ? null : (int?)reader["meter"];
                        address.tready = Convert.IsDBNull(reader["tready"]) ? null : (int?)reader["tready"];
                        address.tfinished = Convert.IsDBNull(reader["tfinished"]) ? null : (int?)reader["tfinished"];
                        address.tcomment = Convert.IsDBNull(reader["tcomment"]) ? null : (string?)reader["tcomment"];
                        address.fdate = Convert.IsDBNull(reader["fdate"]) ? null : (DateTime?)reader["fdate"];
                        address.ffinished = Convert.IsDBNull(reader["ffinished"]) ? null : (int?)reader["ffinished"];
                        address.fcomment = Convert.IsDBNull(reader["fcomment"]) ? null : (string?)reader["fcomment"];

                        address.mId = Convert.IsDBNull(reader["mId"]) ? null : (int?)reader["mId"];
                        address.mdate = Convert.IsDBNull(reader["mdate"]) ? null : (DateTime?)reader["mdate"];
                        address.mfrom = Convert.IsDBNull(reader["mfrom"]) ? null : (DateTime?)reader["mfrom"];
                        address.mto = Convert.IsDBNull(reader["mto"]) ? null : (DateTime?)reader["mto"];
                        address.mcalldate = Convert.IsDBNull(reader["mcalldate"]) ? null : (DateTime?)reader["mcalldate"];
                        address.mfinished = Convert.IsDBNull(reader["mfinished"]) ? null : (int?)reader["mfinished"];
                        address.mcomment = Convert.IsDBNull(reader["mcomment"]) ? null : (string?)reader["mcomment"];

                        address.aId = Convert.IsDBNull(reader["aId"]) ? null : (int?)reader["aId"];
                        address.adate = Convert.IsDBNull(reader["adate"]) ? null : (DateTime?)reader["adate"];
                        address.afrom = Convert.IsDBNull(reader["afrom"]) ? null : (DateTime?)reader["afrom"];
                        address.ato = Convert.IsDBNull(reader["ato"]) ? null : (DateTime?)reader["ato"];
                        address.afinished = Convert.IsDBNull(reader["afinished"]) ? null : (int?)reader["afinished"];
                        address.acomment = Convert.IsDBNull(reader["acomment"]) ? null : (string?)reader["acomment"];

                        address.vdate = Convert.IsDBNull(reader["vdate"]) ? null : (DateTime?)reader["vdate"];
                        address.vfinished = Convert.IsDBNull(reader["vfinished"]) ? null : (int?)reader["vfinished"];
                        address.vcomment = Convert.IsDBNull(reader["vcomment"]) ? null : (string?)reader["vcomment"];
                    }
                }

                return address;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<AddressDetails> GetAddressByInfo(string? city, string? tzip, string? street, int? housenumber, string? subnumber, int? unit)
        {
            AddressDetails address = new AddressDetails();

            try
            {
                using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    con.Open();
                    var cmd = new SqlCommand(@"select a.*, 
                                                h.id as hbId,  h.hbdate, h.hbfrom, h.hbto, h.calldate as hbcalldate, h.finished as hbfinished, h.hbcomment,
                                                t.id as tId, t.tdate, t.meter, t.ready as tready, t.finished as tfinished, t.tcomment,
                                                f.fdate, f.finished as ffinished, f.fcomment,
                                                m.id as mId,  m.mdate, m.mfrom, m.mto, m.calldate as mcalldate, m.finished as mfinished, m.mcomment,
                                                ak.id as aId,  ak.adate, ak.afrom, ak.ato, ak.finished as afinished, ak.acomment,
                                                v.vdate, v.finished as vfinished, v.vcomment
                                                from dbo.address a 
                                                inner join dbo.hausbegehung h on a.id = h.address_id 
                                                inner join dbo.tiefbau t on a.id = t.address_id
                                                inner join dbo.faser f on a.id = f.address_id
                                                inner join dbo.montaze m on a.id = m.address_id
                                                inner join dbo.aktivirung ak on a.id = ak.address_id
                                                inner join dbo.vermessung v on a.id = v.address_id
                                                where ((@city is not null and a.city = @city) or @city is null)  
                                                and ((@tzip is not null and a.tzip = @tzip) or @tzip is null) 
                                                and ((@street is not null and a.street = @street) or @street is null) 
                                                and ((@housenumber is not null and a.housenumber = @housenumber) or @housenumber is null) 
                                                and ((@subnumber is not null and a.subnumber = @subnumber) or @subnumber is null) 
                                                and ((@unit is not null and a.unit = @unit) or @unit is null)", con);
                    cmd.Parameters.AddWithValue("@city", (String.IsNullOrEmpty(city)) ? DBNull.Value : city);
                    cmd.Parameters.AddWithValue("@tzip", (String.IsNullOrEmpty(tzip)) ? DBNull.Value : tzip);
                    cmd.Parameters.AddWithValue("@street", (String.IsNullOrEmpty(street)) ? DBNull.Value : street);
                    cmd.Parameters.AddWithValue("@housenumber", (housenumber == null) ? DBNull.Value : housenumber);
                    cmd.Parameters.AddWithValue("@subnumber", (String.IsNullOrEmpty(subnumber)) ? DBNull.Value : subnumber);
                    cmd.Parameters.AddWithValue("@unit", (unit == null) ? DBNull.Value : unit);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    if (reader.Read())
                    {
                        address.id = Convert.IsDBNull(reader["id"]) ? 0 : (int)reader["id"];
                        address.orderdate = Convert.IsDBNull(reader["orderdate"]) ? null : (DateTime?)reader["orderdate"];
                        address.orderid = Convert.IsDBNull(reader["orderid"]) ? null : (int?)reader["orderid"];
                        address.projectcode = Convert.IsDBNull(reader["projectcode"]) ? null : Convert.ToSingle(reader["projectcode"]);
                        address.projectname = Convert.IsDBNull(reader["projectname"]) ? null : (string?)reader["projectname"];
                        address.areapop = Convert.IsDBNull(reader["areapop"]) ? null : (string?)reader["areapop"];
                        address.dp = Convert.IsDBNull(reader["dp"]) ? null : (int?)reader["dp"];
                        address.city = Convert.IsDBNull(reader["city"]) ? null : (string?)reader["city"];
                        address.tzip = Convert.IsDBNull(reader["tzip"]) ? null : (string?)reader["tzip"];
                        address.street = Convert.IsDBNull(reader["street"]) ? null : (string?)reader["street"];
                        address.housenumber = Convert.IsDBNull(reader["housenumber"]) ? null : (int?)reader["housenumber"];
                        address.subnumber = Convert.IsDBNull(reader["subnumber"]) ? null : (string?)reader["subnumber"];
                        address.unit = Convert.IsDBNull(reader["unit"]) ? null : (int?)reader["unit"];
                        address.dpfinish = Convert.IsDBNull(reader["dpfinish"]) ? null : (int?)reader["dpfinish"];
                        address.popfinish = Convert.IsDBNull(reader["popfinish"]) ? null : (int?)reader["popfinish"];
                        address.comment = Convert.IsDBNull(reader["comment"]) ? null : (string?)reader["comment"];
                        address.connectiondate = Convert.IsDBNull(reader["connectiondate"]) ? null : (DateTime?)reader["connectiondate"];
                        address.completiondate = Convert.IsDBNull(reader["completiondate"]) ? null : (DateTime?)reader["completiondate"];
                        address.arsstatus = Convert.IsDBNull(reader["arsstatus"]) ? null : (int?)reader["arsstatus"];
                        address.provider = Convert.IsDBNull(reader["provider"]) ? null : (string?)reader["provider"];
                        address.co_id = Convert.IsDBNull(reader["co_id"]) ? null : (int?)reader["co_id"];
                        address.firstname = Convert.IsDBNull(reader["firstname"]) ? null : (string?)reader["firstname"];
                        address.name = Convert.IsDBNull(reader["name"]) ? null : (string?)reader["name"];
                        address.phone = Convert.IsDBNull(reader["phone"]) ? null : (string?)reader["phone"];
                        address.phone2 = Convert.IsDBNull(reader["phone2"]) ? null : (string?)reader["phone2"];
                        address.email = Convert.IsDBNull(reader["email"]) ? null : (string?)reader["email"];
                        address.status = Convert.IsDBNull(reader["status"]) ? null : (string?)reader["status"];
                        address.servicepackage = Convert.IsDBNull(reader["servicepackage"]) ? null : (int?)reader["servicepackage"];
                        address.zusat = Convert.IsDBNull(reader["zusat"]) ? null : (string?)reader["zusat"];
                        address.bestellnummer = Convert.IsDBNull(reader["bestellnummer"]) ? null : (string?)reader["bestellnummer"];
                        address.IP_ODF = Convert.IsDBNull(reader["IP_ODF"]) ? null : (string?)reader["IP_ODF"];
                        address.IP_Port = Convert.IsDBNull(reader["IP_Port"]) ? null : (string?)reader["IP_Port"];
                        address.TV_ODF = Convert.IsDBNull(reader["TV_ODF"]) ? null : (string?)reader["TV_ODF"];
                        address.kennwort = Convert.IsDBNull(reader["kennwort"]) ? null : (string?)reader["kennwort"];
                        address.subtype = Convert.IsDBNull(reader["subtype"]) ? null : (string?)reader["subtype"];

                        address.hbId = Convert.IsDBNull(reader["hbId"]) ? null : (int?)reader["hbId"];
                        address.hbdate = Convert.IsDBNull(reader["hbdate"]) ? null : (DateTime?)reader["hbdate"];
                        address.hbfrom = Convert.IsDBNull(reader["hbfrom"]) ? null : (DateTime?)reader["hbfrom"];
                        address.hbto = Convert.IsDBNull(reader["hbto"]) ? null : (DateTime?)reader["hbto"];
                        address.hbcalldate = Convert.IsDBNull(reader["hbcalldate"]) ? null : (DateTime?)reader["hbcalldate"];
                        address.hbfinished = Convert.IsDBNull(reader["hbfinished"]) ? null : (int?)reader["hbfinished"];
                        address.hbcomment = Convert.IsDBNull(reader["hbcomment"]) ? null : (string?)reader["hbcomment"];

                        address.tId = Convert.IsDBNull(reader["tId"]) ? null : (int?)reader["tId"];
                        address.tdate = Convert.IsDBNull(reader["tdate"]) ? null : (DateTime?)reader["tdate"];
                        address.meter = Convert.IsDBNull(reader["meter"]) ? null : (int?)reader["meter"];
                        address.tready = Convert.IsDBNull(reader["tready"]) ? null : (int?)reader["tready"];
                        address.tfinished = Convert.IsDBNull(reader["tfinished"]) ? null : (int?)reader["tfinished"];
                        address.tcomment = Convert.IsDBNull(reader["tcomment"]) ? null : (string?)reader["tcomment"];
                        address.fdate = Convert.IsDBNull(reader["fdate"]) ? null : (DateTime?)reader["fdate"];
                        address.ffinished = Convert.IsDBNull(reader["ffinished"]) ? null : (int?)reader["ffinished"];
                        address.fcomment = Convert.IsDBNull(reader["fcomment"]) ? null : (string?)reader["fcomment"];

                        address.mId = Convert.IsDBNull(reader["mId"]) ? null : (int?)reader["mId"];
                        address.mdate = Convert.IsDBNull(reader["mdate"]) ? null : (DateTime?)reader["mdate"];
                        address.mfrom = Convert.IsDBNull(reader["mfrom"]) ? null : (DateTime?)reader["mfrom"];
                        address.mto = Convert.IsDBNull(reader["mto"]) ? null : (DateTime?)reader["mto"];
                        address.mcalldate = Convert.IsDBNull(reader["mcalldate"]) ? null : (DateTime?)reader["mcalldate"];
                        address.mfinished = Convert.IsDBNull(reader["mfinished"]) ? null : (int?)reader["mfinished"];
                        address.mcomment = Convert.IsDBNull(reader["mcomment"]) ? null : (string?)reader["mcomment"];

                        address.aId = Convert.IsDBNull(reader["aId"]) ? null : (int?)reader["aId"];
                        address.adate = Convert.IsDBNull(reader["adate"]) ? null : (DateTime?)reader["adate"];
                        address.afrom = Convert.IsDBNull(reader["afrom"]) ? null : (DateTime?)reader["afrom"];
                        address.ato = Convert.IsDBNull(reader["ato"]) ? null : (DateTime?)reader["ato"];
                        address.afinished = Convert.IsDBNull(reader["afinished"]) ? null : (int?)reader["afinished"];
                        address.acomment = Convert.IsDBNull(reader["acomment"]) ? null : (string?)reader["acomment"];

                        address.vdate = Convert.IsDBNull(reader["vdate"]) ? null : (DateTime?)reader["vdate"];
                        address.vfinished = Convert.IsDBNull(reader["vfinished"]) ? null : (int?)reader["vfinished"];
                        address.vcomment = Convert.IsDBNull(reader["vcomment"]) ? null : (string?)reader["vcomment"];
                    }
                }

                return address;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<AddressDB> Insert(AddressDB address)
        {
            try
            {
                using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    con.Open();
                    var cmd = new SqlCommand(@"insert into dbo.address (
                                           [orderdate]      ,[orderid]      ,[projectcode]      ,[projectname]      ,[areapop]      ,[dp]      ,[city]      ,[tzip]
                                          ,[street]      ,[housenumber]      ,[subnumber]       ,[unit]      ,[dpfinish]      ,[popfinish]      ,[comment]      
                                          ,[arsstatus]      ,[provider]      ,[co_id]      ,[firstname]      ,[name]      ,[phone]      ,[phone2]
                                          ,[email]      ,[status]      ,[servicepackage]      ,[zusat]      ,[bestellnummer]      ,[IP_ODF]      ,[IP_Port]
                                          ,[TV_ODF]      ,[kennwort]      ,[subtype])
                                            OUTPUT INSERTED.[ID]
                                            values
                                            (@orderdate      ,@orderid      ,@projectcode      ,@projectname      ,@areapop      ,@dp      ,@city      ,@tzip
                                          ,@street      ,@housenumber      ,@subnumber          ,@unit      ,@dpfinish      ,@popfinish      ,@comment      
                                          ,@arsstatus      ,@provider      ,@co_id      ,@firstname      ,@name      ,@phone
                                          ,@phone2      ,@email      ,@status      ,@servicepackage      ,@zusat      ,@bestellnummer      ,@IP_ODF      ,@IP_Port
                                          ,@TV_ODF      ,@kennwort      ,@subtype)", con);
                    cmd.Parameters.AddWithValue("@orderdate", (address.orderdate != null) ? address.orderdate : DBNull.Value);
                    cmd.Parameters.AddWithValue("@orderid", (address.orderid != null) ? address.orderid : DBNull.Value);
                    cmd.Parameters.AddWithValue("@projectcode", (address.projectcode != null) ? address.projectcode : DBNull.Value);
                    cmd.Parameters.AddWithValue("@projectname", (address.projectname != null) ? address.projectname : DBNull.Value);
                    cmd.Parameters.AddWithValue("@areapop", (address.areapop != null) ? address.areapop : DBNull.Value);
                    cmd.Parameters.AddWithValue("@dp", (address.dp != null) ? address.dp : DBNull.Value);
                    cmd.Parameters.AddWithValue("@city", (address.city != null) ? address.city : DBNull.Value);
                    cmd.Parameters.AddWithValue("@tzip", (address.tzip != null) ? address.tzip : DBNull.Value);
                    cmd.Parameters.AddWithValue("@street", (address.street != null) ? address.street : DBNull.Value);
                    cmd.Parameters.AddWithValue("@housenumber", (address.housenumber != null) ? address.housenumber : DBNull.Value);
                    cmd.Parameters.AddWithValue("@subnumber", (address.subnumber != null) ? address.subnumber : DBNull.Value);
                    cmd.Parameters.AddWithValue("@unit", (address.unit != null) ? address.unit : DBNull.Value);
                    cmd.Parameters.AddWithValue("@dpfinish", (address.dpfinish != null) ? address.dpfinish : DBNull.Value);
                    cmd.Parameters.AddWithValue("@popfinish", (address.popfinish != null) ? address.popfinish : DBNull.Value);
                    cmd.Parameters.AddWithValue("@comment", (address.comment != null) ? address.comment : DBNull.Value);
                    //cmd.Parameters.AddWithValue("@connectiondate", null);
                    //cmd.Parameters.AddWithValue("@completiondate", null);
                    cmd.Parameters.AddWithValue("@arsstatus", (address.arsstatus != null) ? address.arsstatus : DBNull.Value);
                    cmd.Parameters.AddWithValue("@provider", (address.provider != null) ? address.provider : DBNull.Value);
                    cmd.Parameters.AddWithValue("@co_id", (address.co_id != null) ? address.co_id : DBNull.Value);
                    cmd.Parameters.AddWithValue("@firstname", (address.firstname != null) ? address.firstname : DBNull.Value);
                    cmd.Parameters.AddWithValue("@name", (address.name != null) ? address.name : DBNull.Value);
                    cmd.Parameters.AddWithValue("@phone", (address.phone != null) ? address.phone : DBNull.Value);
                    cmd.Parameters.AddWithValue("@phone2", (address.phone2 != null) ? address.phone2 : DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (address.email != null) ? address.email : DBNull.Value);
                    cmd.Parameters.AddWithValue("@status", (address.status != null) ? address.status : DBNull.Value);
                    cmd.Parameters.AddWithValue("@servicepackage", (address.servicepackage != null) ? address.servicepackage : DBNull.Value);
                    cmd.Parameters.AddWithValue("@zusat", (address.zusat != null) ? address.zusat : DBNull.Value);
                    cmd.Parameters.AddWithValue("@bestellnummer", (address.bestellnummer != null) ? address.bestellnummer : DBNull.Value);
                    cmd.Parameters.AddWithValue("@IP_ODF", (address.IP_ODF != null) ? address.IP_ODF : DBNull.Value);
                    cmd.Parameters.AddWithValue("@IP_Port", (address.IP_Port != null) ? address.IP_Port : DBNull.Value);
                    cmd.Parameters.AddWithValue("@TV_ODF", (address.TV_ODF != null) ? address.TV_ODF : DBNull.Value);
                    cmd.Parameters.AddWithValue("@kennwort", (address.kennwort != null) ? address.kennwort : DBNull.Value);
                    cmd.Parameters.AddWithValue("@subtype", (address.subtype != null) ? address.subtype : DBNull.Value);

                    var addressId = (Int32)cmd.ExecuteScalar(); //Convert.ToInt32(cmd.ExecuteScalar());
                    address.id = addressId;

                    var hbCmd = new SqlCommand(@"insert into dbo.hausbegehung (address_id, finished) values (@address_id, @finished)", con);
                    hbCmd.Parameters.AddWithValue("@address_id", addressId);
                    hbCmd.Parameters.AddWithValue("@finished", 0);
                    var hbCmdRes = await hbCmd.ExecuteNonQueryAsync();

                    var tCmd = new SqlCommand(@"insert into dbo.tiefbau (address_id, ready, finished) values (@address_id, @ready, @finished)", con);
                    tCmd.Parameters.AddWithValue("@address_id", addressId);
                    tCmd.Parameters.AddWithValue("@ready", 0);
                    tCmd.Parameters.AddWithValue("@finished", 0);
                    var tCmdRes = await tCmd.ExecuteNonQueryAsync();

                    var fCmd = new SqlCommand(@"insert into dbo.faser (address_id, finished) values (@address_id, @finished)", con);
                    fCmd.Parameters.AddWithValue("@address_id", addressId);
                    fCmd.Parameters.AddWithValue("@finished", 0);
                    var fCmdRes = await fCmd.ExecuteNonQueryAsync();

                    var mCmd = new SqlCommand(@"insert into dbo.montaze (address_id, finished) values (@address_id, @finished)", con);
                    mCmd.Parameters.AddWithValue("@address_id", addressId);
                    mCmd.Parameters.AddWithValue("@finished", 0);
                    var mCmdRes = await mCmd.ExecuteNonQueryAsync();

                    var aCmd = new SqlCommand(@"insert into dbo.aktivirung (address_id, finished) values (@address_id, @finished)", con);
                    aCmd.Parameters.AddWithValue("@address_id", addressId);
                    aCmd.Parameters.AddWithValue("@finished", 0);
                    var aCmdRes = await aCmd.ExecuteNonQueryAsync();

                    var vCmd = new SqlCommand(@"insert into dbo.vermessung (address_id, finished) values (@address_id, @finished)", con);
                    vCmd.Parameters.AddWithValue("@address_id", addressId);
                    vCmd.Parameters.AddWithValue("@finished", 0);
                    var vCmdRes = await vCmd.ExecuteNonQueryAsync();
                }

                return address;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<int> CheckAddressRnc(string city, string tzip, string street, int housenumber, string subnumber, int unit, int newrnc)
        {
            try
            {
                var exists = 0;
                using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    con.Open();
                    var cmd = new SqlCommand(@"select * from dbo.address 
                                                where city = @city and tzip = @tzip and street = @street 
                                                and housenumber = @housenumber and subnumber = @subnumber and unit = @unit", con);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@tzip", tzip);
                    cmd.Parameters.AddWithValue("@street", street);
                    cmd.Parameters.AddWithValue("@housenumber", housenumber);
                    cmd.Parameters.AddWithValue("@subnumber", subnumber);
                    cmd.Parameters.AddWithValue("@unit", unit);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    if (reader.Read())
                    {
                        exists = 1;
                    }

                    reader.Close();
                }

                if (exists == 1)
                    using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                    {
                        con.Open();
                        var cmd = new SqlCommand(@"update address set arsstatus = @arsstatus 
                                                    where city = @city and tzip = @tzip and street = @street 
                                                    and housenumber = @housenumber and subnumber = @subnumber and unit = @unit", con);

                        cmd.Parameters.AddWithValue("@city", city);
                        cmd.Parameters.AddWithValue("@tzip", tzip);
                        cmd.Parameters.AddWithValue("@street", street);
                        cmd.Parameters.AddWithValue("@housenumber", housenumber);
                        cmd.Parameters.AddWithValue("@subnumber", subnumber);
                        cmd.Parameters.AddWithValue("@unit", unit);
                        cmd.Parameters.AddWithValue("@arsstatus", newrnc);

                        int result = await cmd.ExecuteNonQueryAsync();
                    }

                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<IEnumerable<AddressDetails>> Filter(FilterModel filterModel)
        {
            List<AddressDetails> result = new List<AddressDetails>();

            try
            {
                using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    con.Open();
                    var cmd = new SqlCommand(@"select a.*, 
                                                h.id as hbId,  h.hbdate, h.hbfrom, h.hbto, h.calldate as hbcalldate, h.finished as hbfinished, h.hbcomment,
                                                t.id as tId, t.tdate, t.meter, t.ready as tready, t.finished as tfinished, t.tcomment,
                                                f.fdate, f.finished as ffinished, f.fcomment,
                                                m.id as mId,  m.mdate, m.mfrom, m.mto, m.calldate as mcalldate, m.finished as mfinished, m.mcomment,
                                                ak.id as aId,  ak.adate, ak.afrom, ak.ato, ak.finished as afinished, ak.acomment,
                                                v.vdate, v.finished as vfinished, v.vcomment
                            from dbo.address a
                            inner
                            join dbo.hausbegehung h on a.id = h.address_id
                            inner
                            join dbo.tiefbau t on a.id = t.address_id
                            inner
                            join dbo.faser f on a.id = f.address_id
                            inner
                            join dbo.montaze m on a.id = m.address_id
                            inner
                            join dbo.aktivirung ak on a.id = ak.address_id
                            inner
                            join dbo.vermessung v on a.id = v.address_id
                            where 
                                ((@city is not null and a.city = @city) or (@city is null)) 
                                and ((@pop is not null and a.areapop = @pop) or (@pop is null)) 
                                and h.finished = @hbfinished
                                and t.finished = @tfinished
                                and f.finished = @ffinished
                                and m.finished = @mfinished
                                and ak.finished = @afinished
                                and v.finished = @vfinished", con);

                    cmd.Parameters.AddWithValue("@city", (filterModel.city == null) ? DBNull.Value : filterModel.city);
                    cmd.Parameters.AddWithValue("@pop", (filterModel.pop == null) ? DBNull.Value : filterModel.pop);
                    cmd.Parameters.AddWithValue("@hbfinished", (filterModel.hbfinished == null) ? DBNull.Value : filterModel.hbfinished);
                    cmd.Parameters.AddWithValue("@tfinished", (filterModel.tfinished == null) ? DBNull.Value : filterModel.tfinished);
                    cmd.Parameters.AddWithValue("@ffinished", (filterModel.ffinished == null) ? DBNull.Value : filterModel.ffinished);
                    cmd.Parameters.AddWithValue("@mfinished", (filterModel.mfinished == null) ? DBNull.Value : filterModel.mfinished);
                    cmd.Parameters.AddWithValue("@afinished", (filterModel.afinished == null) ? DBNull.Value : filterModel.afinished);
                    cmd.Parameters.AddWithValue("@vfinished", (filterModel.vfinished == null) ? DBNull.Value : filterModel.vfinished);

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        AddressDetails address = new AddressDetails();

                        address.id = Convert.IsDBNull(reader["id"]) ? 0 : (int)reader["id"];
                        address.orderdate = Convert.IsDBNull(reader["orderdate"]) ? null : (DateTime?)reader["orderdate"];
                        address.orderid = Convert.IsDBNull(reader["orderid"]) ? null : (int?)reader["orderid"];
                        address.projectcode = Convert.IsDBNull(reader["projectcode"]) ? null : Convert.ToSingle(reader["projectcode"]);
                        address.projectname = Convert.IsDBNull(reader["projectname"]) ? null : (string?)reader["projectname"];
                        address.areapop = Convert.IsDBNull(reader["areapop"]) ? null : (string?)reader["areapop"];
                        address.dp = Convert.IsDBNull(reader["dp"]) ? null : (int?)reader["dp"];
                        address.city = Convert.IsDBNull(reader["city"]) ? null : (string?)reader["city"];
                        address.tzip = Convert.IsDBNull(reader["tzip"]) ? null : (string?)reader["tzip"];
                        address.street = Convert.IsDBNull(reader["street"]) ? null : (string?)reader["street"];
                        address.housenumber = Convert.IsDBNull(reader["housenumber"]) ? null : (int?)reader["housenumber"];
                        address.subnumber = Convert.IsDBNull(reader["subnumber"]) ? null : (string?)reader["subnumber"];
                        address.unit = Convert.IsDBNull(reader["unit"]) ? null : (int?)reader["unit"];
                        address.dpfinish = Convert.IsDBNull(reader["dpfinish"]) ? null : (int?)reader["dpfinish"];
                        address.popfinish = Convert.IsDBNull(reader["popfinish"]) ? null : (int?)reader["popfinish"];
                        address.comment = Convert.IsDBNull(reader["comment"]) ? null : (string?)reader["comment"];
                        address.connectiondate = Convert.IsDBNull(reader["connectiondate"]) ? null : (DateTime?)reader["connectiondate"];
                        address.completiondate = Convert.IsDBNull(reader["completiondate"]) ? null : (DateTime?)reader["completiondate"];
                        address.arsstatus = Convert.IsDBNull(reader["arsstatus"]) ? null : (int?)reader["arsstatus"];
                        address.provider = Convert.IsDBNull(reader["provider"]) ? null : (string?)reader["provider"];
                        address.co_id = Convert.IsDBNull(reader["co_id"]) ? null : (int?)reader["co_id"];
                        address.firstname = Convert.IsDBNull(reader["firstname"]) ? null : (string?)reader["firstname"];
                        address.name = Convert.IsDBNull(reader["name"]) ? null : (string?)reader["name"];
                        address.phone = Convert.IsDBNull(reader["phone"]) ? null : (string?)reader["phone"];
                        address.phone2 = Convert.IsDBNull(reader["phone2"]) ? null : (string?)reader["phone2"];
                        address.email = Convert.IsDBNull(reader["email"]) ? null : (string?)reader["email"];
                        address.status = Convert.IsDBNull(reader["status"]) ? null : (string?)reader["status"];
                        address.servicepackage = Convert.IsDBNull(reader["servicepackage"]) ? null : (int?)reader["servicepackage"];
                        address.zusat = Convert.IsDBNull(reader["zusat"]) ? null : (string?)reader["zusat"];
                        address.bestellnummer = Convert.IsDBNull(reader["bestellnummer"]) ? null : (string?)reader["bestellnummer"];
                        address.IP_ODF = Convert.IsDBNull(reader["IP_ODF"]) ? null : (string?)reader["IP_ODF"];
                        address.IP_Port = Convert.IsDBNull(reader["IP_Port"]) ? null : (string?)reader["IP_Port"];
                        address.TV_ODF = Convert.IsDBNull(reader["TV_ODF"]) ? null : (string?)reader["TV_ODF"];
                        address.kennwort = Convert.IsDBNull(reader["kennwort"]) ? null : (string?)reader["kennwort"];
                        address.subtype = Convert.IsDBNull(reader["subtype"]) ? null : (string?)reader["subtype"];

                        address.hbId = Convert.IsDBNull(reader["hbId"]) ? null : (int?)reader["hbId"];
                        address.hbdate = Convert.IsDBNull(reader["hbdate"]) ? null : (DateTime?)reader["hbdate"];
                        address.hbfrom = Convert.IsDBNull(reader["hbfrom"]) ? null : (DateTime?)reader["hbfrom"];
                        address.hbto = Convert.IsDBNull(reader["hbto"]) ? null : (DateTime?)reader["hbto"];
                        address.hbcalldate = Convert.IsDBNull(reader["hbcalldate"]) ? null : (DateTime?)reader["hbcalldate"];
                        address.hbfinished = Convert.IsDBNull(reader["hbfinished"]) ? null : (int?)reader["hbfinished"];
                        address.hbcomment = Convert.IsDBNull(reader["hbcomment"]) ? null : (string?)reader["hbcomment"];

                        address.tId = Convert.IsDBNull(reader["tId"]) ? null : (int?)reader["tId"];
                        address.tdate = Convert.IsDBNull(reader["tdate"]) ? null : (DateTime?)reader["tdate"];
                        address.meter = Convert.IsDBNull(reader["meter"]) ? null : (int?)reader["meter"];
                        address.tready = Convert.IsDBNull(reader["tready"]) ? null : (int?)reader["tready"];
                        address.tfinished = Convert.IsDBNull(reader["tfinished"]) ? null : (int?)reader["tfinished"];
                        address.tcomment = Convert.IsDBNull(reader["tcomment"]) ? null : (string?)reader["tcomment"];
                        address.fdate = Convert.IsDBNull(reader["fdate"]) ? null : (DateTime?)reader["fdate"];
                        address.ffinished = Convert.IsDBNull(reader["ffinished"]) ? null : (int?)reader["ffinished"];
                        address.fcomment = Convert.IsDBNull(reader["fcomment"]) ? null : (string?)reader["fcomment"];

                        address.mId = Convert.IsDBNull(reader["mId"]) ? null : (int?)reader["mId"];
                        address.mdate = Convert.IsDBNull(reader["mdate"]) ? null : (DateTime?)reader["mdate"];
                        address.mfrom = Convert.IsDBNull(reader["mfrom"]) ? null : (DateTime?)reader["mfrom"];
                        address.mto = Convert.IsDBNull(reader["mto"]) ? null : (DateTime?)reader["mto"];
                        address.mcalldate = Convert.IsDBNull(reader["mcalldate"]) ? null : (DateTime?)reader["mcalldate"];
                        address.mfinished = Convert.IsDBNull(reader["mfinished"]) ? null : (int?)reader["mfinished"];
                        address.mcomment = Convert.IsDBNull(reader["mcomment"]) ? null : (string?)reader["mcomment"];

                        address.aId = Convert.IsDBNull(reader["aId"]) ? null : (int?)reader["aId"];
                        address.adate = Convert.IsDBNull(reader["adate"]) ? null : (DateTime?)reader["adate"];
                        address.afrom = Convert.IsDBNull(reader["afrom"]) ? null : (DateTime?)reader["afrom"];
                        address.ato = Convert.IsDBNull(reader["ato"]) ? null : (DateTime?)reader["ato"];
                        address.afinished = Convert.IsDBNull(reader["afinished"]) ? null : (int?)reader["afinished"];
                        address.acomment = Convert.IsDBNull(reader["acomment"]) ? null : (string?)reader["acomment"];

                        address.vdate = Convert.IsDBNull(reader["vdate"]) ? null : (DateTime?)reader["vdate"];
                        address.vfinished = Convert.IsDBNull(reader["vfinished"]) ? null : (int?)reader["vfinished"];
                        address.vcomment = Convert.IsDBNull(reader["vcomment"]) ? null : (string?)reader["vcomment"];

                        result.Add(address);

                    }
                }
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
