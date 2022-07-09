using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using realbau_app.api.Models;
using System.Net;
using System.Net.Mail;

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDB>>> GetAddresses()
        {
            try
            {
                List<AddressDB> result = new List<AddressDB>();
                using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from dbo.address", con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AddressDB addressDB = new AddressDB();


                        addressDB.id = Convert.IsDBNull(reader["id"]) ? null : (int?)reader["id"];

                        addressDB.orderdate = Convert.IsDBNull(reader["orderdate"]) ? null : (DateTime?)reader["orderdate"];
                        addressDB.orderid = Convert.IsDBNull(reader["orderid"]) ? null : (int?)reader["orderid"];
                        addressDB.projectcode = Convert.IsDBNull(reader["projectcode"]) ? null : Convert.ToSingle(reader["projectcode"]);

                        addressDB.projectname = Convert.IsDBNull(reader["projectname"]) ? null : (string?)reader["projectname"];
                        addressDB.areapop = Convert.IsDBNull(reader["areapop"]) ? null : (string?)reader["areapop"];
                        addressDB.dp = Convert.IsDBNull(reader["dp"]) ? null : (int?)reader["dp"];
                        addressDB.city = Convert.IsDBNull(reader["city"]) ? null : (string?)reader["city"];
                        addressDB.tzip = Convert.IsDBNull(reader["tzip"]) ? null : (string?)reader["tzip"];
                        addressDB.street = Convert.IsDBNull(reader["street"]) ? null : (string?)reader["street"];

                        addressDB.housenumber = Convert.IsDBNull(reader["housenumber"]) ? null : (int?)reader["housenumber"];

                        addressDB.unit = Convert.IsDBNull(reader["unit"]) ? null : (int?)reader["unit"];

                        addressDB.dpfinish = Convert.IsDBNull(reader["dpfinish"]) ? null : (int?)reader["dpfinish"];

                        addressDB.popfinish = Convert.IsDBNull(reader["popfinish"]) ? null : (int?)reader["popfinish"];

                        addressDB.comment = Convert.IsDBNull(reader["comment"]) ? null : (string?)reader["comment"];
                        addressDB.connectiondate = Convert.IsDBNull(reader["connectiondate"]) ? null : (DateTime?)reader["connectiondate"];

                        addressDB.completiondate = Convert.IsDBNull(reader["completiondate"]) ? null : (DateTime?)reader["completiondate"];

                        addressDB.arsstatus = Convert.IsDBNull(reader["arsstatus"]) ? null : (int?)reader["arsstatus"];
                        addressDB.provider = Convert.IsDBNull(reader["provider"]) ? null : (string?)reader["provider"];
                        addressDB.co_id = Convert.IsDBNull(reader["co_id"]) ? null : (int?)reader["co_id"];
                        addressDB.firstname = Convert.IsDBNull(reader["firstname"]) ? null : (string?)reader["firstname"];

                        addressDB.name = Convert.IsDBNull(reader["name"]) ? null : (string?)reader["name"];
                        addressDB.phone = Convert.IsDBNull(reader["phone"]) ? null : (string?)reader["phone"];

                        addressDB.phone2 = Convert.IsDBNull(reader["phone2"]) ? null : (string?)reader["phone2"];
                        addressDB.email = Convert.IsDBNull(reader["email"]) ? null : (string?)reader["email"];
                        addressDB.status = Convert.IsDBNull(reader["status"]) ? null : (string?)reader["status"];

                        addressDB.servicepackage = Convert.IsDBNull(reader["servicepackage"]) ? null : (int?)reader["servicepackage"];
                        addressDB.zusat = Convert.IsDBNull(reader["zusat"]) ? null : (string?)reader["zusat"];
                        addressDB.bestellnummer = Convert.IsDBNull(reader["bestellnummer"]) ? null : (string?)reader["bestellnummer"];

                        addressDB.IP_ODF = Convert.IsDBNull(reader["IP_ODF"]) ? null : (string?)reader["IP_ODF"];

                        addressDB.IP_Port = Convert.IsDBNull(reader["IP_Port"]) ? null : (string?)reader["IP_Port"];

                        addressDB.TV_ODF = Convert.IsDBNull(reader["TV_ODF"]) ? null : (string?)reader["TV_ODF"];
                        addressDB.kennwort = Convert.IsDBNull(reader["kennwort"]) ? null : (string?)reader["kennwort"];
                        addressDB.subtype = Convert.IsDBNull(reader["subtype"]) ? null : (string?)reader["subtype"];

                        result.Add(addressDB);

                        //Korisnik k = new Korisnik();
                        //k.ORDERDATE = Convert.IsDBNull(reader["ORDERDATE"]) ? null : (DateTime?)reader["ORDERDATE"]; ;
                        //k.ORDERID = Convert.IsDBNull(reader["ORDERID"]) ? null : (int?)reader["ORDERID"];
                        ////k.PROJECTCODE = Convert.IsDBNull(reader["PROJECTCODE"]) ? null : (string?)reader["PROJECTCODE"];
                        //k.AREAPOP = Convert.IsDBNull(reader["AREAPOP"]) ? null : (string?)reader["AREAPOP"];
                        //k.DP = Convert.IsDBNull(reader["DP"]) ? null : (int?)reader["DP"];
                        //k.CITY = Convert.IsDBNull(reader["CITY"]) ? null : (string?)reader["CITY"];
                        //k.TZIP = Convert.IsDBNull(reader["TZIP"]) ? null : (string?)reader["TZIP"];
                        //k.STREET = Convert.IsDBNull(reader["STREET"]) ? null : (string?)reader["STREET"];
                        //k.HAUSNUMMER = Convert.IsDBNull(reader["HAUSNUMMER"]) ? null : (int?)reader["HAUSNUMMER"];
                        //k.EINHEIT = Convert.IsDBNull(reader["EINHEIT"]) ? null : (int?)reader["EINHEIT"];
                        //k.TIEFBAUDatum = Convert.IsDBNull(reader["TIEFBAUDatum"]) ? null : (DateTime?)reader["TIEFBAUDatum"];
                        //k.TIEFBAUFINISH = Convert.IsDBNull(reader["TIEFBAUFINISH"]) ? null : (string?)reader["TIEFBAUFINISH"];
                        //k.METER = Convert.IsDBNull(reader["METER"]) ? null : (int?)reader["METER"]; ;
                        //k.TFVOM = Convert.IsDBNull(reader["TFVOM"]) ? null : (string?)reader["TFVOM"];
                        //k.FASERDatum = Convert.IsDBNull(reader["FASERDatum"]) ? null : (DateTime?)reader["FASERDatum"];
                        //k.FFINISH = Convert.IsDBNull(reader["FFINISH"]) ? null : (string?)reader["FFINISH"];
                        //k.FVOM = Convert.IsDBNull(reader["FVOM"]) ? null : (string?)reader["FVOM"];
                        //k.DPFinish = Convert.IsDBNull(reader["DPFinish"]) ? null : (string?)reader["DPFinish"];
                        //k.POPFinish = Convert.IsDBNull(reader["POPFinish"]) ? null : (string?)reader["POPFinish"];
                        //k.HBDatum = Convert.IsDBNull(reader["HBDatum"]) ? null : (string?)reader["HBDatum"];
                        //k.HBTermin = Convert.IsDBNull(reader["HBTermin"]) ? null : (string?)reader["HBTermin"];
                        //k.HBCALLDATE = Convert.IsDBNull(reader["HBCALLDATE"]) ? null : (DateTime?)reader["HBCALLDATE"];
                        //k.HAUSBDate = Convert.IsDBNull(reader["HAUSBDate"]) ? null : (DateTime?)reader["HAUSBDate"];
                        //k.HBFinish = Convert.IsDBNull(reader["HBFinIsh"]) ? null : (string?)reader["HBFinish"];
                        //k.HBVOM = Convert.IsDBNull(reader["HBVOM"]) ? null : (string?)reader["HBVOM"];
                        //k.MDATUM = Convert.IsDBNull(reader["MDATUM"]) ? null : (DateTime?)reader["MDATUM"];
                        //k.MTERMIN = Convert.IsDBNull(reader["MTERMIN"]) ? null : (string?)reader["MTERMIN"];
                        //k.CALLMDate = Convert.IsDBNull(reader["CALLMDate"]) ? null : (DateTime?)reader["CALLMDate"];
                        //k.MFINISH = Convert.IsDBNull(reader["MFINISH"]) ? null : (string?)reader["MFINISH"];
                        //k.MONTAZEDATUM = Convert.IsDBNull(reader["MONTAZEDATUM"]) ? null : (DateTime?)reader["MONTAZEDATUM"];
                        //k.MVOM = Convert.IsDBNull(reader["MVOM"]) ? null : (string?)reader["MVOM"];
                        //k.ADATUM = Convert.IsDBNull(reader["ADATUM"]) ? null : (DateTime?)reader["ADATUM"];
                        //k.AKTIVIRUNGTERMIN = Convert.IsDBNull(reader["AKTIVIRUNGTERMIN"]) ? null : (string?)reader["AKTIVIRUNGTERMIN"];
                        //k.AKTIVIRUNGFINISH = Convert.IsDBNull(reader["AKTIVIRUNGFINISH"]) ? null : (string?)reader["AKTIVIRUNGFINISH"];
                        //k.AKTIVIRUNGDATUM = Convert.IsDBNull(reader["AKTIVIRUNGDATUM"]) ? null : (DateTime?)reader["AKTIVIRUNGDATUM"];
                        //k.AVOM = Convert.IsDBNull(reader["AVOM"]) ? null : (string?)reader["AVOM"];
                        //k.TDatum = Convert.IsDBNull(reader["TDatum"]) ? null : (DateTime?)reader["TDatum"];
                        //k.TICKETTERMIN = Convert.IsDBNull(reader["TICKETTERMIN"]) ? null : (string?)reader["TICKETTERMIN"];
                        //k.TICKETFINISH = Convert.IsDBNull(reader["TICKETFINISH"]) ? null : (string?)reader["TICKETFINISH"];
                        //k.TICKETDATUM = Convert.IsDBNull(reader["TICKETDATUM"]) ? null : (DateTime?)reader["TICKETDATUM"];
                        //k.TCALLDATE = Convert.IsDBNull(reader["TCALLDATE"]) ? null : (DateTime?)reader["TCALLDATE"];
                        //k.TICKETVOM = Convert.IsDBNull(reader["TICKETVOM"]) ? null : (string?)reader["TICKETVOM"];
                        //k.COMMENT = Convert.IsDBNull(reader["COMMENT"]) ? null : (string?)reader["COMMENT"];
                        //k.CONNECTIONDATE = Convert.IsDBNull(reader["CONNECTIONDATE"]) ? null : (DateTime?)reader["CONNECTIONDATE"];
                        //k.COMPLETIONDATE = Convert.IsDBNull(reader["COMPLETIONDATE"]) ? null : (DateTime?)reader["COMPLETIONDATE"];
                        //k.ARSTATUS = Convert.IsDBNull(reader["ARSTATUS"]) ? null : (int?)reader["ARSTATUS"]; ;
                        //k.PROVIDER = Convert.IsDBNull(reader["PROVIDER"]) ? null : (string?)reader["PROVIDER"];
                        //k.CO_ID = Convert.IsDBNull(reader["CO_ID"]) ? null : (int?)reader["CO_ID"]; ;
                        //k.FIRSTNAME = Convert.IsDBNull(reader["FIRSTNAME"]) ? null : (string?)reader["FIRSTNAME"];
                        //k.NAME = Convert.IsDBNull(reader["NAME"]) ? null : (string?)reader["NAME"];
                        //k.PHONE = Convert.IsDBNull(reader["PHONE"]) ? null : (string?)reader["PHONE"];
                        //k.EMAIL = Convert.IsDBNull(reader["EMAIL"]) ? null : (string?)reader["EMAIL"];
                        //k.STATUS = Convert.IsDBNull(reader["STATUS"]) ? null : (string?)reader["STATUS"];
                        //k.ServisPaket = Convert.IsDBNull(reader["ServisPaket"]) ? null : (string?)reader["ServisPaket"];
                        //k.ZUSAT = Convert.IsDBNull(reader["ZUSAT"]) ? null : (string?)reader["ZUSAT"];
                        //k.VermessungFinish = Convert.IsDBNull(reader["VermessungFinish"]) ? null : (string?)reader["VermessungFinish"];
                        //k.VermessungDatum = Convert.IsDBNull(reader["VermessungDatum"]) ? null : (DateTime?)reader["VermessungDatum"]; ;
                        //k.VermessungVom = Convert.IsDBNull(reader["VermessungVom"]) ? null : (string?)reader["VermessungVom"];

                        //result.Add(k);
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                var p = 0;
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDetails>> GetAddress(int id)
        {
            List<AddressDB> result = new List<AddressDB>();
            AddressDetails addressDB = new AddressDetails();
            using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                con.Open();
                var cmd = new SqlCommand(@"
                            select a.*, 
                            h.id as hbId,  h.hbdate, h.hbfrom, h.hbto, h.calldate as hbcalldate, h.finished as hbfinished, h.hbcomment,
                            t.id as tId, t.tdate, t.meter, t.finished as tfinished, t.tcomment,
                            f.fdate, f.finished as ffinished, f.fcomment,
                            m.id as mId,  m.mdate, m.mfrom, m.mto, m.calldate as mcalldate, m.finished as mfinished, m.mcomment,
                            ak.id as aId,  ak.adate, ak.afrom, ak.ato, ak.finished as afinished, ak.acomment
                            from dbo.address a 
                            inner join dbo.hausbegehung h on a.id = h.address_id 
                            inner join dbo.tiefbau t on a.id = t.address_id
                            inner join dbo.faser f on a.id = f.address_id
                            inner join dbo.montaze m on a.id = m.address_id
                            inner join dbo.aktivirung ak on a.id = ak.address_id
                            where a.id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                //cmd.Parameters.AddWithValue("@tzip", tzip);
                //cmd.Parameters.AddWithValue("@street", street);
                //cmd.Parameters.AddWithValue("@housenumber", housenumber);
                //cmd.Parameters.AddWithValue("@unit", unit);
                SqlDataReader reader = cmd.ExecuteReader();



                if (reader.Read())
                {
                    //return 1;



                    addressDB.id = Convert.IsDBNull(reader["id"]) ? null : (int?)reader["id"];

                    addressDB.orderdate = Convert.IsDBNull(reader["orderdate"]) ? null : (DateTime?)reader["orderdate"];
                    addressDB.orderid = Convert.IsDBNull(reader["orderid"]) ? null : (int?)reader["orderid"];
                    addressDB.projectcode = Convert.IsDBNull(reader["projectcode"]) ? null : Convert.ToSingle(reader["projectcode"]);

                    addressDB.projectname = Convert.IsDBNull(reader["projectname"]) ? null : (string?)reader["projectname"];
                    addressDB.areapop = Convert.IsDBNull(reader["areapop"]) ? null : (string?)reader["areapop"];
                    addressDB.dp = Convert.IsDBNull(reader["dp"]) ? null : (int?)reader["dp"];
                    addressDB.city = Convert.IsDBNull(reader["city"]) ? null : (string?)reader["city"];
                    addressDB.tzip = Convert.IsDBNull(reader["tzip"]) ? null : (string?)reader["tzip"];
                    addressDB.street = Convert.IsDBNull(reader["street"]) ? null : (string?)reader["street"];

                    addressDB.housenumber = Convert.IsDBNull(reader["housenumber"]) ? null : (int?)reader["housenumber"];

                    addressDB.unit = Convert.IsDBNull(reader["unit"]) ? null : (int?)reader["unit"];

                    addressDB.dpfinish = Convert.IsDBNull(reader["dpfinish"]) ? null : (int?)reader["dpfinish"];

                    addressDB.popfinish = Convert.IsDBNull(reader["popfinish"]) ? null : (int?)reader["popfinish"];

                    addressDB.comment = Convert.IsDBNull(reader["comment"]) ? null : (string?)reader["comment"];
                    addressDB.connectiondate = Convert.IsDBNull(reader["connectiondate"]) ? null : (DateTime?)reader["connectiondate"];

                    addressDB.completiondate = Convert.IsDBNull(reader["completiondate"]) ? null : (DateTime?)reader["completiondate"];

                    addressDB.arsstatus = Convert.IsDBNull(reader["arsstatus"]) ? null : (int?)reader["arsstatus"];
                    addressDB.provider = Convert.IsDBNull(reader["provider"]) ? null : (string?)reader["provider"];
                    addressDB.co_id = Convert.IsDBNull(reader["co_id"]) ? null : (int?)reader["co_id"];
                    addressDB.firstname = Convert.IsDBNull(reader["firstname"]) ? null : (string?)reader["firstname"];

                    addressDB.name = Convert.IsDBNull(reader["name"]) ? null : (string?)reader["name"];
                    addressDB.phone = Convert.IsDBNull(reader["phone"]) ? null : (string?)reader["phone"];

                    addressDB.phone2 = Convert.IsDBNull(reader["phone2"]) ? null : (string?)reader["phone2"];
                    addressDB.email = Convert.IsDBNull(reader["email"]) ? null : (string?)reader["email"];
                    addressDB.status = Convert.IsDBNull(reader["status"]) ? null : (string?)reader["status"];

                    addressDB.servicepackage = Convert.IsDBNull(reader["servicepackage"]) ? null : (int?)reader["servicepackage"];
                    addressDB.zusat = Convert.IsDBNull(reader["zusat"]) ? null : (string?)reader["zusat"];
                    addressDB.bestellnummer = Convert.IsDBNull(reader["bestellnummer"]) ? null : (string?)reader["bestellnummer"];

                    addressDB.IP_ODF = Convert.IsDBNull(reader["IP_ODF"]) ? null : (string?)reader["IP_ODF"];

                    addressDB.IP_Port = Convert.IsDBNull(reader["IP_Port"]) ? null : (string?)reader["IP_Port"];

                    addressDB.TV_ODF = Convert.IsDBNull(reader["TV_ODF"]) ? null : (string?)reader["TV_ODF"];
                    addressDB.kennwort = Convert.IsDBNull(reader["kennwort"]) ? null : (string?)reader["kennwort"];
                    addressDB.subtype = Convert.IsDBNull(reader["subtype"]) ? null : (string?)reader["subtype"];

                    addressDB.hbId = Convert.IsDBNull(reader["hbId"]) ? null : (int?)reader["hbId"];
                    addressDB.hbdate = Convert.IsDBNull(reader["hbdate"]) ? null : (DateTime?)reader["hbdate"];
                    addressDB.hbfrom = Convert.IsDBNull(reader["hbfrom"]) ? null : (DateTime?)reader["hbfrom"];
                    addressDB.hbto = Convert.IsDBNull(reader["hbto"]) ? null : (DateTime?)reader["hbto"];
                    addressDB.hbcalldate = Convert.IsDBNull(reader["hbcalldate"]) ? null : (DateTime?)reader["hbcalldate"];
                    addressDB.hbfinished = Convert.IsDBNull(reader["hbfinished"]) ? null : (int?)reader["hbfinished"];
                    addressDB.hbcomment = Convert.IsDBNull(reader["hbcomment"]) ? null : (string?)reader["hbcomment"];

                    addressDB.tId = Convert.IsDBNull(reader["tId"]) ? null : (int?)reader["tId"];
                    addressDB.tdate = Convert.IsDBNull(reader["tdate"]) ? null : (DateTime?)reader["tdate"];
                    addressDB.meter = Convert.IsDBNull(reader["meter"]) ? null : (int?)reader["meter"];
                    addressDB.tfinished = Convert.IsDBNull(reader["tfinished"]) ? null : (int?)reader["tfinished"];
                    addressDB.tcomment = Convert.IsDBNull(reader["tcomment"]) ? null : (string?)reader["tcomment"];

                    addressDB.fdate = Convert.IsDBNull(reader["fdate"]) ? null : (DateTime?)reader["fdate"];
                    addressDB.ffinished = Convert.IsDBNull(reader["ffinished"]) ? null : (int?)reader["ffinished"];
                    addressDB.fcomment = Convert.IsDBNull(reader["fcomment"]) ? null : (string?)reader["fcomment"];

                    addressDB.mId = Convert.IsDBNull(reader["mId"]) ? null : (int?)reader["mId"];
                    addressDB.mdate = Convert.IsDBNull(reader["mdate"]) ? null : (DateTime?)reader["mdate"];
                    addressDB.mfrom = Convert.IsDBNull(reader["mfrom"]) ? null : (DateTime?)reader["mfrom"];
                    addressDB.mto = Convert.IsDBNull(reader["mto"]) ? null : (DateTime?)reader["mto"];
                    addressDB.mcalldate = Convert.IsDBNull(reader["mcalldate"]) ? null : (DateTime?)reader["mcalldate"];
                    addressDB.mfinished = Convert.IsDBNull(reader["mfinished"]) ? null : (int?)reader["mfinished"];
                    addressDB.mcomment = Convert.IsDBNull(reader["mcomment"]) ? null : (string?)reader["mcomment"];

                    addressDB.aId = Convert.IsDBNull(reader["aId"]) ? null : (int?)reader["aId"];
                    addressDB.adate = Convert.IsDBNull(reader["adate"]) ? null : (DateTime?)reader["adate"];
                    addressDB.afrom = Convert.IsDBNull(reader["afrom"]) ? null : (DateTime?)reader["afrom"];
                    addressDB.ato = Convert.IsDBNull(reader["ato"]) ? null : (DateTime?)reader["ato"];
                    addressDB.afinished = Convert.IsDBNull(reader["afinished"]) ? null : (int?)reader["afinished"];
                    addressDB.acomment = Convert.IsDBNull(reader["acomment"]) ? null : (string?)reader["acomment"];

                    //Korisnik k = new Korisnik();
                    //k.ORDERDATE = Convert.IsDBNull(reader["ORDERDATE"]) ? null : (DateTime?)reader["ORDERDATE"]; ;
                    //k.ORDERID = Convert.IsDBNull(reader["ORDERID"]) ? null : (int?)reader["ORDERID"];
                    ////k.PROJECTCODE = Convert.IsDBNull(reader["PROJECTCODE"]) ? null : (string?)reader["PROJECTCODE"];
                    //k.AREAPOP = Convert.IsDBNull(reader["AREAPOP"]) ? null : (string?)reader["AREAPOP"];
                    //k.DP = Convert.IsDBNull(reader["DP"]) ? null : (int?)reader["DP"];
                    //k.CITY = Convert.IsDBNull(reader["CITY"]) ? null : (string?)reader["CITY"];
                    //k.TZIP = Convert.IsDBNull(reader["TZIP"]) ? null : (string?)reader["TZIP"];
                    //k.STREET = Convert.IsDBNull(reader["STREET"]) ? null : (string?)reader["STREET"];
                    //k.HAUSNUMMER = Convert.IsDBNull(reader["HAUSNUMMER"]) ? null : (int?)reader["HAUSNUMMER"];
                    //k.EINHEIT = Convert.IsDBNull(reader["EINHEIT"]) ? null : (int?)reader["EINHEIT"];
                    //k.TIEFBAUDatum = Convert.IsDBNull(reader["TIEFBAUDatum"]) ? null : (DateTime?)reader["TIEFBAUDatum"];
                    //k.TIEFBAUFINISH = Convert.IsDBNull(reader["TIEFBAUFINISH"]) ? null : (string?)reader["TIEFBAUFINISH"];
                    //k.METER = Convert.IsDBNull(reader["METER"]) ? null : (int?)reader["METER"]; ;
                    //k.TFVOM = Convert.IsDBNull(reader["TFVOM"]) ? null : (string?)reader["TFVOM"];
                    //k.FASERDatum = Convert.IsDBNull(reader["FASERDatum"]) ? null : (DateTime?)reader["FASERDatum"];
                    //k.FFINISH = Convert.IsDBNull(reader["FFINISH"]) ? null : (string?)reader["FFINISH"];
                    //k.FVOM = Convert.IsDBNull(reader["FVOM"]) ? null : (string?)reader["FVOM"];
                    //k.DPFinish = Convert.IsDBNull(reader["DPFinish"]) ? null : (string?)reader["DPFinish"];
                    //k.POPFinish = Convert.IsDBNull(reader["POPFinish"]) ? null : (string?)reader["POPFinish"];
                    //k.HBDatum = Convert.IsDBNull(reader["HBDatum"]) ? null : (string?)reader["HBDatum"];
                    //k.HBTermin = Convert.IsDBNull(reader["HBTermin"]) ? null : (string?)reader["HBTermin"];
                    //k.HBCALLDATE = Convert.IsDBNull(reader["HBCALLDATE"]) ? null : (DateTime?)reader["HBCALLDATE"];
                    //k.HAUSBDate = Convert.IsDBNull(reader["HAUSBDate"]) ? null : (DateTime?)reader["HAUSBDate"];
                    //k.HBFinish = Convert.IsDBNull(reader["HBFinIsh"]) ? null : (string?)reader["HBFinish"];
                    //k.HBVOM = Convert.IsDBNull(reader["HBVOM"]) ? null : (string?)reader["HBVOM"];
                    //k.MDATUM = Convert.IsDBNull(reader["MDATUM"]) ? null : (DateTime?)reader["MDATUM"];
                    //k.MTERMIN = Convert.IsDBNull(reader["MTERMIN"]) ? null : (string?)reader["MTERMIN"];
                    //k.CALLMDate = Convert.IsDBNull(reader["CALLMDate"]) ? null : (DateTime?)reader["CALLMDate"];
                    //k.MFINISH = Convert.IsDBNull(reader["MFINISH"]) ? null : (string?)reader["MFINISH"];
                    //k.MONTAZEDATUM = Convert.IsDBNull(reader["MONTAZEDATUM"]) ? null : (DateTime?)reader["MONTAZEDATUM"];
                    //k.MVOM = Convert.IsDBNull(reader["MVOM"]) ? null : (string?)reader["MVOM"];
                    //k.ADATUM = Convert.IsDBNull(reader["ADATUM"]) ? null : (DateTime?)reader["ADATUM"];
                    //k.AKTIVIRUNGTERMIN = Convert.IsDBNull(reader["AKTIVIRUNGTERMIN"]) ? null : (string?)reader["AKTIVIRUNGTERMIN"];
                    //k.AKTIVIRUNGFINISH = Convert.IsDBNull(reader["AKTIVIRUNGFINISH"]) ? null : (string?)reader["AKTIVIRUNGFINISH"];
                    //k.AKTIVIRUNGDATUM = Convert.IsDBNull(reader["AKTIVIRUNGDATUM"]) ? null : (DateTime?)reader["AKTIVIRUNGDATUM"];
                    //k.AVOM = Convert.IsDBNull(reader["AVOM"]) ? null : (string?)reader["AVOM"];
                    //k.TDatum = Convert.IsDBNull(reader["TDatum"]) ? null : (DateTime?)reader["TDatum"];
                    //k.TICKETTERMIN = Convert.IsDBNull(reader["TICKETTERMIN"]) ? null : (string?)reader["TICKETTERMIN"];
                    //k.TICKETFINISH = Convert.IsDBNull(reader["TICKETFINISH"]) ? null : (string?)reader["TICKETFINISH"];
                    //k.TICKETDATUM = Convert.IsDBNull(reader["TICKETDATUM"]) ? null : (DateTime?)reader["TICKETDATUM"];
                    //k.TCALLDATE = Convert.IsDBNull(reader["TCALLDATE"]) ? null : (DateTime?)reader["TCALLDATE"];
                    //k.TICKETVOM = Convert.IsDBNull(reader["TICKETVOM"]) ? null : (string?)reader["TICKETVOM"];
                    //k.COMMENT = Convert.IsDBNull(reader["COMMENT"]) ? null : (string?)reader["COMMENT"];
                    //k.CONNECTIONDATE = Convert.IsDBNull(reader["CONNECTIONDATE"]) ? null : (DateTime?)reader["CONNECTIONDATE"];
                    //k.COMPLETIONDATE = Convert.IsDBNull(reader["COMPLETIONDATE"]) ? null : (DateTime?)reader["COMPLETIONDATE"];
                    //k.ARSTATUS = Convert.IsDBNull(reader["ARSTATUS"]) ? null : (int?)reader["ARSTATUS"]; ;
                    //k.PROVIDER = Convert.IsDBNull(reader["PROVIDER"]) ? null : (string?)reader["PROVIDER"];
                    //k.CO_ID = Convert.IsDBNull(reader["CO_ID"]) ? null : (int?)reader["CO_ID"]; ;
                    //k.FIRSTNAME = Convert.IsDBNull(reader["FIRSTNAME"]) ? null : (string?)reader["FIRSTNAME"];
                    //k.NAME = Convert.IsDBNull(reader["NAME"]) ? null : (string?)reader["NAME"];
                    //k.PHONE = Convert.IsDBNull(reader["PHONE"]) ? null : (string?)reader["PHONE"];
                    //k.EMAIL = Convert.IsDBNull(reader["EMAIL"]) ? null : (string?)reader["EMAIL"];
                    //k.STATUS = Convert.IsDBNull(reader["STATUS"]) ? null : (string?)reader["STATUS"];
                    //k.ServisPaket = Convert.IsDBNull(reader["ServisPaket"]) ? null : (string?)reader["ServisPaket"];
                    //k.ZUSAT = Convert.IsDBNull(reader["ZUSAT"]) ? null : (string?)reader["ZUSAT"];
                    //k.VermessungFinish = Convert.IsDBNull(reader["VermessungFinish"]) ? null : (string?)reader["VermessungFinish"];
                    //k.VermessungDatum = Convert.IsDBNull(reader["VermessungDatum"]) ? null : (DateTime?)reader["VermessungDatum"]; ;
                    //k.VermessungVom = Convert.IsDBNull(reader["VermessungVom"]) ? null : (string?)reader["VermessungVom"];

                    //result.Add(k);
                }
            }

            return addressDB;
        }


        [HttpGet("{city}/{tzip}/{street}/{housenumber}/{unit}")]
        public async Task<ActionResult<int>> GetAddress(string city, string tzip, string street, int housenumber, int unit)
        {
            List<AddressDB> result = new List<AddressDB>();
            using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
            {
                con.Open();
                var cmd = new SqlCommand("select * from dbo.address where city = @city and tzip = @tzip and street = @street and housenumber = @housenumber and unit = @unit", con);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@tzip", tzip);
                cmd.Parameters.AddWithValue("@street", street);
                cmd.Parameters.AddWithValue("@housenumber", housenumber);
                cmd.Parameters.AddWithValue("@unit", unit);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return 1;
                    //AddressDB addressDB = new AddressDB();


                    //addressDB.id = Convert.IsDBNull(reader["id"]) ? null : (int?)reader["id"];

                    //addressDB.orderdate = Convert.IsDBNull(reader["orderdate"]) ? null : (DateTime?)reader["orderdate"];
                    //addressDB.orderid = Convert.IsDBNull(reader["orderid"]) ? null : (int?)reader["orderid"];
                    //addressDB.projectcode = Convert.IsDBNull(reader["projectcode"]) ? null : (float?)reader["projectcode"];

                    //addressDB.projectname = Convert.IsDBNull(reader["projectname"]) ? null : (string?)reader["projectname"];
                    //addressDB.areapop = Convert.IsDBNull(reader["areapop"]) ? null : (string?)reader["areapop"];
                    //addressDB.dp = Convert.IsDBNull(reader["dp"]) ? null : (int?)reader["dp"];
                    //addressDB.city = Convert.IsDBNull(reader["city"]) ? null : (string?)reader["city"];
                    //addressDB.tzip = Convert.IsDBNull(reader["tzip"]) ? null : (string?)reader["tzip"];
                    //addressDB.street = Convert.IsDBNull(reader["street"]) ? null : (string?)reader["street"];

                    //addressDB.housenumber = Convert.IsDBNull(reader["housenumber"]) ? null : (int?)reader["housenumber"];

                    //addressDB.unit = Convert.IsDBNull(reader["unit"]) ? null : (int?)reader["unit"];

                    //addressDB.dpfinish = Convert.IsDBNull(reader["dpfinish"]) ? null : (int?)reader["dpfinish"];

                    //addressDB.popfinish = Convert.IsDBNull(reader["popfinish"]) ? null : (int?)reader["popfinish"];

                    //addressDB.comment = Convert.IsDBNull(reader["comment"]) ? null : (string?)reader["comment"];
                    //addressDB.connectiondate = Convert.IsDBNull(reader["connectiondate"]) ? null : (DateTime?)reader["connectiondate"];

                    //addressDB.completiondate = Convert.IsDBNull(reader["completiondate"]) ? null : (DateTime?)reader["completiondate"];

                    //addressDB.arsstatus = Convert.IsDBNull(reader["arsstatus"]) ? null : (int?)reader["arsstatus"];
                    //addressDB.provider = Convert.IsDBNull(reader["provider"]) ? null : (string?)reader["provider"];
                    //addressDB.co_id = Convert.IsDBNull(reader["co_id"]) ? null : (int?)reader["co_id"];
                    //addressDB.firstname = Convert.IsDBNull(reader["firstname"]) ? null : (string?)reader["firstname"];

                    //addressDB.name = Convert.IsDBNull(reader["name"]) ? null : (string?)reader["name"];
                    //addressDB.phone = Convert.IsDBNull(reader["phone"]) ? null : (string?)reader["phone"];

                    //addressDB.phone2 = Convert.IsDBNull(reader["phone2"]) ? null : (string?)reader["phone2"];
                    //addressDB.email = Convert.IsDBNull(reader["email"]) ? null : (string?)reader["email"];
                    //addressDB.status = Convert.IsDBNull(reader["status"]) ? null : (string?)reader["status"];

                    //addressDB.servicepackage = Convert.IsDBNull(reader["servicepackage"]) ? null : (int?)reader["servicepackage"];
                    //addressDB.zusat = Convert.IsDBNull(reader["zusat"]) ? null : (string?)reader["zusat"];
                    //addressDB.bestellnummer = Convert.IsDBNull(reader["bestellnummer"]) ? null : (string?)reader["bestellnummer"];

                    //addressDB.IP_ODF = Convert.IsDBNull(reader["IP_ODF"]) ? null : (string?)reader["IP_ODF"];

                    //addressDB.IP_Port = Convert.IsDBNull(reader["IP_Port"]) ? null : (string?)reader["IP_Port"];

                    //addressDB.TV_ODF = Convert.IsDBNull(reader["TV_ODF"]) ? null : (string?)reader["TV_ODF"];
                    //addressDB.kennwort = Convert.IsDBNull(reader["kennwort"]) ? null : (string?)reader["kennwort"];
                    //addressDB.subtype = Convert.IsDBNull(reader["subtype"]) ? null : (string?)reader["subtype"];


                    //Korisnik k = new Korisnik();
                    //k.ORDERDATE = Convert.IsDBNull(reader["ORDERDATE"]) ? null : (DateTime?)reader["ORDERDATE"]; ;
                    //k.ORDERID = Convert.IsDBNull(reader["ORDERID"]) ? null : (int?)reader["ORDERID"];
                    ////k.PROJECTCODE = Convert.IsDBNull(reader["PROJECTCODE"]) ? null : (string?)reader["PROJECTCODE"];
                    //k.AREAPOP = Convert.IsDBNull(reader["AREAPOP"]) ? null : (string?)reader["AREAPOP"];
                    //k.DP = Convert.IsDBNull(reader["DP"]) ? null : (int?)reader["DP"];
                    //k.CITY = Convert.IsDBNull(reader["CITY"]) ? null : (string?)reader["CITY"];
                    //k.TZIP = Convert.IsDBNull(reader["TZIP"]) ? null : (string?)reader["TZIP"];
                    //k.STREET = Convert.IsDBNull(reader["STREET"]) ? null : (string?)reader["STREET"];
                    //k.HAUSNUMMER = Convert.IsDBNull(reader["HAUSNUMMER"]) ? null : (int?)reader["HAUSNUMMER"];
                    //k.EINHEIT = Convert.IsDBNull(reader["EINHEIT"]) ? null : (int?)reader["EINHEIT"];
                    //k.TIEFBAUDatum = Convert.IsDBNull(reader["TIEFBAUDatum"]) ? null : (DateTime?)reader["TIEFBAUDatum"];
                    //k.TIEFBAUFINISH = Convert.IsDBNull(reader["TIEFBAUFINISH"]) ? null : (string?)reader["TIEFBAUFINISH"];
                    //k.METER = Convert.IsDBNull(reader["METER"]) ? null : (int?)reader["METER"]; ;
                    //k.TFVOM = Convert.IsDBNull(reader["TFVOM"]) ? null : (string?)reader["TFVOM"];
                    //k.FASERDatum = Convert.IsDBNull(reader["FASERDatum"]) ? null : (DateTime?)reader["FASERDatum"];
                    //k.FFINISH = Convert.IsDBNull(reader["FFINISH"]) ? null : (string?)reader["FFINISH"];
                    //k.FVOM = Convert.IsDBNull(reader["FVOM"]) ? null : (string?)reader["FVOM"];
                    //k.DPFinish = Convert.IsDBNull(reader["DPFinish"]) ? null : (string?)reader["DPFinish"];
                    //k.POPFinish = Convert.IsDBNull(reader["POPFinish"]) ? null : (string?)reader["POPFinish"];
                    //k.HBDatum = Convert.IsDBNull(reader["HBDatum"]) ? null : (string?)reader["HBDatum"];
                    //k.HBTermin = Convert.IsDBNull(reader["HBTermin"]) ? null : (string?)reader["HBTermin"];
                    //k.HBCALLDATE = Convert.IsDBNull(reader["HBCALLDATE"]) ? null : (DateTime?)reader["HBCALLDATE"];
                    //k.HAUSBDate = Convert.IsDBNull(reader["HAUSBDate"]) ? null : (DateTime?)reader["HAUSBDate"];
                    //k.HBFinish = Convert.IsDBNull(reader["HBFinIsh"]) ? null : (string?)reader["HBFinish"];
                    //k.HBVOM = Convert.IsDBNull(reader["HBVOM"]) ? null : (string?)reader["HBVOM"];
                    //k.MDATUM = Convert.IsDBNull(reader["MDATUM"]) ? null : (DateTime?)reader["MDATUM"];
                    //k.MTERMIN = Convert.IsDBNull(reader["MTERMIN"]) ? null : (string?)reader["MTERMIN"];
                    //k.CALLMDate = Convert.IsDBNull(reader["CALLMDate"]) ? null : (DateTime?)reader["CALLMDate"];
                    //k.MFINISH = Convert.IsDBNull(reader["MFINISH"]) ? null : (string?)reader["MFINISH"];
                    //k.MONTAZEDATUM = Convert.IsDBNull(reader["MONTAZEDATUM"]) ? null : (DateTime?)reader["MONTAZEDATUM"];
                    //k.MVOM = Convert.IsDBNull(reader["MVOM"]) ? null : (string?)reader["MVOM"];
                    //k.ADATUM = Convert.IsDBNull(reader["ADATUM"]) ? null : (DateTime?)reader["ADATUM"];
                    //k.AKTIVIRUNGTERMIN = Convert.IsDBNull(reader["AKTIVIRUNGTERMIN"]) ? null : (string?)reader["AKTIVIRUNGTERMIN"];
                    //k.AKTIVIRUNGFINISH = Convert.IsDBNull(reader["AKTIVIRUNGFINISH"]) ? null : (string?)reader["AKTIVIRUNGFINISH"];
                    //k.AKTIVIRUNGDATUM = Convert.IsDBNull(reader["AKTIVIRUNGDATUM"]) ? null : (DateTime?)reader["AKTIVIRUNGDATUM"];
                    //k.AVOM = Convert.IsDBNull(reader["AVOM"]) ? null : (string?)reader["AVOM"];
                    //k.TDatum = Convert.IsDBNull(reader["TDatum"]) ? null : (DateTime?)reader["TDatum"];
                    //k.TICKETTERMIN = Convert.IsDBNull(reader["TICKETTERMIN"]) ? null : (string?)reader["TICKETTERMIN"];
                    //k.TICKETFINISH = Convert.IsDBNull(reader["TICKETFINISH"]) ? null : (string?)reader["TICKETFINISH"];
                    //k.TICKETDATUM = Convert.IsDBNull(reader["TICKETDATUM"]) ? null : (DateTime?)reader["TICKETDATUM"];
                    //k.TCALLDATE = Convert.IsDBNull(reader["TCALLDATE"]) ? null : (DateTime?)reader["TCALLDATE"];
                    //k.TICKETVOM = Convert.IsDBNull(reader["TICKETVOM"]) ? null : (string?)reader["TICKETVOM"];
                    //k.COMMENT = Convert.IsDBNull(reader["COMMENT"]) ? null : (string?)reader["COMMENT"];
                    //k.CONNECTIONDATE = Convert.IsDBNull(reader["CONNECTIONDATE"]) ? null : (DateTime?)reader["CONNECTIONDATE"];
                    //k.COMPLETIONDATE = Convert.IsDBNull(reader["COMPLETIONDATE"]) ? null : (DateTime?)reader["COMPLETIONDATE"];
                    //k.ARSTATUS = Convert.IsDBNull(reader["ARSTATUS"]) ? null : (int?)reader["ARSTATUS"]; ;
                    //k.PROVIDER = Convert.IsDBNull(reader["PROVIDER"]) ? null : (string?)reader["PROVIDER"];
                    //k.CO_ID = Convert.IsDBNull(reader["CO_ID"]) ? null : (int?)reader["CO_ID"]; ;
                    //k.FIRSTNAME = Convert.IsDBNull(reader["FIRSTNAME"]) ? null : (string?)reader["FIRSTNAME"];
                    //k.NAME = Convert.IsDBNull(reader["NAME"]) ? null : (string?)reader["NAME"];
                    //k.PHONE = Convert.IsDBNull(reader["PHONE"]) ? null : (string?)reader["PHONE"];
                    //k.EMAIL = Convert.IsDBNull(reader["EMAIL"]) ? null : (string?)reader["EMAIL"];
                    //k.STATUS = Convert.IsDBNull(reader["STATUS"]) ? null : (string?)reader["STATUS"];
                    //k.ServisPaket = Convert.IsDBNull(reader["ServisPaket"]) ? null : (string?)reader["ServisPaket"];
                    //k.ZUSAT = Convert.IsDBNull(reader["ZUSAT"]) ? null : (string?)reader["ZUSAT"];
                    //k.VermessungFinish = Convert.IsDBNull(reader["VermessungFinish"]) ? null : (string?)reader["VermessungFinish"];
                    //k.VermessungDatum = Convert.IsDBNull(reader["VermessungDatum"]) ? null : (DateTime?)reader["VermessungDatum"]; ;
                    //k.VermessungVom = Convert.IsDBNull(reader["VermessungVom"]) ? null : (string?)reader["VermessungVom"];

                    //result.Add(k);
                }
            }

            return 0;
        }

        [HttpPost]
        public async Task<AddressDB> Insert([FromBody] AddressDB address)
        {
            try
            {


                using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    con.Open();
                    var cmd = new SqlCommand(@"insert into dbo.address (
                   [orderdate]      ,[orderid]      ,[projectcode]      ,[projectname]      ,[areapop]      ,[dp]      ,[city]      ,[tzip]
                  ,[street]      ,[housenumber]      ,[unit]      ,[dpfinish]      ,[popfinish]      ,[comment]      
                  ,[arsstatus]      ,[provider]      ,[co_id]      ,[firstname]      ,[name]      ,[phone]      ,[phone2]
                  ,[email]      ,[status]      ,[servicepackage]      ,[zusat]      ,[bestellnummer]      ,[IP_ODF]      ,[IP_Port]
                  ,[TV_ODF]      ,[kennwort]      ,[subtype])
                    OUTPUT INSERTED.[ID]
                    values
                    (@orderdate      ,@orderid      ,@projectcode      ,@projectname      ,@areapop      ,@dp      ,@city      ,@tzip
                  ,@street      ,@housenumber      ,@unit      ,@dpfinish      ,@popfinish      ,@comment      
                  ,@arsstatus      ,@provider      ,@co_id      ,@firstname      ,@name      ,@phone
                  ,@phone2      ,@email      ,@status      ,@servicepackage      ,@zusat      ,@bestellnummer      ,@IP_ODF      ,@IP_Port
                  ,@TV_ODF      ,@kennwort      ,@subtype)", con);
                    cmd.Parameters.AddWithValue("@orderdate", address.orderdate);
                    cmd.Parameters.AddWithValue("@orderid", address.orderid);
                    cmd.Parameters.AddWithValue("@projectcode", address.projectcode);
                    cmd.Parameters.AddWithValue("@projectname", address.projectname);
                    cmd.Parameters.AddWithValue("@areapop", address.areapop);
                    cmd.Parameters.AddWithValue("@dp", address.dp);
                    cmd.Parameters.AddWithValue("@city", address.city);
                    cmd.Parameters.AddWithValue("@tzip", address.tzip);
                    cmd.Parameters.AddWithValue("@street", address.street);
                    cmd.Parameters.AddWithValue("@housenumber", address.housenumber);
                    cmd.Parameters.AddWithValue("@unit", address.unit);
                    cmd.Parameters.AddWithValue("@dpfinish", address.dpfinish);
                    cmd.Parameters.AddWithValue("@popfinish", address.popfinish);
                    cmd.Parameters.AddWithValue("@comment", address.comment);
                    //cmd.Parameters.AddWithValue("@connectiondate", null);
                    //cmd.Parameters.AddWithValue("@completiondate", null);
                    cmd.Parameters.AddWithValue("@arsstatus", address.arsstatus);
                    cmd.Parameters.AddWithValue("@provider", address.provider);
                    cmd.Parameters.AddWithValue("@co_id", address.co_id);
                    cmd.Parameters.AddWithValue("@firstname", address.firstname);
                    cmd.Parameters.AddWithValue("@name", address.name);
                    cmd.Parameters.AddWithValue("@phone", address.phone);
                    cmd.Parameters.AddWithValue("@phone2", address.phone2);
                    cmd.Parameters.AddWithValue("@email", address.email);
                    cmd.Parameters.AddWithValue("@status", address.status);
                    cmd.Parameters.AddWithValue("@servicepackage", address.servicepackage);
                    cmd.Parameters.AddWithValue("@zusat", address.zusat);
                    cmd.Parameters.AddWithValue("@bestellnummer", address.bestellnummer);
                    cmd.Parameters.AddWithValue("@IP_ODF", address.IP_ODF);
                    cmd.Parameters.AddWithValue("@IP_Port", address.IP_Port);
                    cmd.Parameters.AddWithValue("@TV_ODF", address.TV_ODF);
                    cmd.Parameters.AddWithValue("@kennwort", address.kennwort);
                    cmd.Parameters.AddWithValue("@subtype", address.subtype);

                    var addressId = (Int32)cmd.ExecuteScalar(); //Convert.ToInt32(cmd.ExecuteScalar());

                    var hbCmd = new SqlCommand(@"insert into dbo.hausbegehung (address_id) values (@address_id)", con);
                    hbCmd.Parameters.AddWithValue("@address_id", addressId);
                    var hbCmdRes = hbCmd.ExecuteNonQuery();

                    var tCmd = new SqlCommand(@"insert into dbo.tiefbau (address_id) values (@address_id)", con);
                    tCmd.Parameters.AddWithValue("@address_id", addressId);
                    var tCmdRes = tCmd.ExecuteNonQuery();

                    var fCmd = new SqlCommand(@"insert into dbo.faser (address_id) values (@address_id)", con);
                    fCmd.Parameters.AddWithValue("@address_id", addressId);
                    var fCmdRes = fCmd.ExecuteNonQuery();

                    var mCmd = new SqlCommand(@"insert into dbo.montaze (address_id) values (@address_id)", con);
                    mCmd.Parameters.AddWithValue("@address_id", addressId);
                    var mCmdRes = mCmd.ExecuteNonQuery();

                    var aCmd = new SqlCommand(@"insert into dbo.aktivirung (address_id) values (@address_id)", con);
                    aCmd.Parameters.AddWithValue("@address_id", addressId);
                    var aCmdRes = aCmd.ExecuteNonQuery();
                }

                return address;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        [HttpPut]
        public void Update([FromBody] AddressDB address)
        {
            try
            {
                var exists = 0;
                using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau_db;User Id=realbau;Password=p4x/yRNf;TrustServerCertificate=True"))
                {
                    con.Open();
                    var cmd = new SqlCommand("select * from dbo.address where city = @city and tzip = @tzip and street = @street and housenumber = @housenumber and unit = @unit", con);
                    cmd.Parameters.AddWithValue("@city", address.city);
                    cmd.Parameters.AddWithValue("@tzip", address.tzip);
                    cmd.Parameters.AddWithValue("@street", address.street);
                    cmd.Parameters.AddWithValue("@housenumber", address.housenumber);
                    cmd.Parameters.AddWithValue("@unit", address.unit);
                    SqlDataReader reader = cmd.ExecuteReader();

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
                        var cmd = new SqlCommand("update address set arsstatus = @arsstatus where  city = @city and tzip = @tzip and street = @street and housenumber = @housenumber and unit = @unit");

                        cmd.Parameters.AddWithValue("@city", address.city);
                        cmd.Parameters.AddWithValue("@tzip", address.tzip);
                        cmd.Parameters.AddWithValue("@street", address.street);
                        cmd.Parameters.AddWithValue("@housenumber", address.housenumber);
                        cmd.Parameters.AddWithValue("@unit", address.unit);

                        int result = cmd.ExecuteNonQuery();
                    }
            }
            catch (Exception e)
            {

            }
        }

        //[HttpPost]
        //public async Task<int> SendMail([FromBody] EmailData emailData)
        //{
        //    try
        //    {
        //        MailMessage message = new MailMessage();
        //        SmtpClient smtp = new SmtpClient();
        //        message.From = new MailAddress("");
        //        message.To.Add(new MailAddress("ToMailAddress"));
        //        message.Subject = "Test";
        //        message.IsBodyHtml = true; //to make message body as html  
        //        message.Body = "Hello";
        //        smtp.Port = 587;
        //        smtp.Host = "smtp.gmail.com"; //for gmail host  
        //        smtp.EnableSsl = true;
        //        smtp.UseDefaultCredentials = false;
        //        smtp.Credentials = new NetworkCredential("FromMailAddress", "password");
        //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        smtp.Send(message);

        //        return 1;
        //    }
        //    catch (Exception) {
        //        return 0;

        //    }
        //}

    }
}
