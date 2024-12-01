using FitnessProject.Entities;
using FitnessProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastControllerTests
{
    public class DataContextGymnastFake : IDataContextGymnast
    {
        public List<GymnastEntity> LoadData()
        {
            List<GymnastEntity> list = new List<GymnastEntity>();
            list.Add(new GymnastEntity(1, "Rachel", "Pfeuffer", new DateTime(2004, 12, 24), "0527102247", "r0527102247@gmail.com", new Address("wolfson", 9, "Bne Braq", "Israel", 5144320), CourseType.BALLET));
            list.Add(new GymnastEntity(2, "Yeali", "Cohen", new DateTime(2004, 08, 30), "0548566763", "y0548566763@gmail.com", new Address("pardo", 12, "Bne Braq", "Israel", 5154415), CourseType.AEROBICS));
            return list;
        }
        public bool SaveData(List<GymnastEntity> gymnastList)
        {
            return true;
        }
    }
}
