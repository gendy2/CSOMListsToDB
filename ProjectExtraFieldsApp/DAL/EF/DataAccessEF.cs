using System.Collections.Generic;
using System.Linq;

namespace ProjectExtraFieldsApp.EF
{
    public class DataAccessEF
    {
        private DataEF _dataEf { get; set; } = new DataEF();
        private CSOM _csom { get; set; } = new CSOM();

        public List<ProjectExtraFieldsModel> Insert()
        {
            var result = _csom.FetchData();

            
            _dataEf.Projects.RemoveRange(_dataEf.Projects);
            _dataEf.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('projectextrafields', RESEED, 0)");
            foreach (var item in result)
            {
                
                _dataEf.Projects.Add(item);
                
            }
            _dataEf.SaveChanges();
            return _dataEf.Projects.ToList();

        }

    }
}