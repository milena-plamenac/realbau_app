using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using realbau_app.api.Models;

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDB>>> GetAddresses()
        {
            List<AddressDB> result = new List<AddressDB>();
            using (var con = new SqlConnection("Server=173.249.2.130,1433\\SQLEXPRESS;Database=realbau;User Id=realbau;Password=p4x/yRNf;"))
            {
                con.Open();
                var cmd = new SqlCommand("select * from dbo.address", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AddressDB addressDB = new AddressDB();

                    
                    addressDB.id = Convert.IsDBNull(reader["id"]) ? null : (int?)reader["id"];
        
        addressDB.orderdate = Convert.IsDBNull(reader["orderdate"])? null : (DateTime?) reader["orderdate"];
                    addressDB.orderid = Convert.IsDBNull(reader["orderid"]) ? null : (int?)reader["orderid"];
                    addressDB.projectcode = Convert.IsDBNull(reader["projectcode"]) ? null : (float?)reader["projectcode"];

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
    }
}
