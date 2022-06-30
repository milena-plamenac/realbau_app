using realbau_app.api.Models;
using realbau_app.Models;

namespace realbau_app.Services
{
    public class Mapper
    {
        public HausbegehungDefaultTermDB hausbegehungDefaultTermToDB(HausbegehungDefaultTerm term)
        {
            return new HausbegehungDefaultTermDB()
            {
                hbfrom = term.hbfrom,
                hbto = term.hbto,
                created_on = term.created_on,
                created_by = term.created_by
            };
        }

        public HausbegehungDefaultTerm hausbegehungDefaultTermFromDB(HausbegehungDefaultTermDB termDB)
        {
            return new HausbegehungDefaultTerm()
            {
                hbfrom = termDB.hbfrom,
                hbto = termDB.hbto,
                created_on = termDB.created_on,
                created_by = termDB.created_by
            };
        }
    }
}
