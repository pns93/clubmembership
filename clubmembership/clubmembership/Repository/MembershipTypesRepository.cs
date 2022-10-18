using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Models.DBObjects;

namespace clubmembership.Repository
{
    public class MembershipTypesRepository
    {
        private readonly ApplicationDbContext _DBContext;

        public MembershipTypesRepository()
        {
            _DBContext = new ApplicationDbContext();
        }
        public MembershipTypesRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private MembershipTypesModel MapDBObjectToModel(MembershipType dbobject)
        {
            var model = new MembershipTypesModel();
            if (dbobject != null)
            {
                model.IdmembershipType = dbobject.IdmembershipType;
                model.Name = dbobject.Name;
                model.Description = dbobject.Description;
                model.SubscriptionLengthInMonths = dbobject.SubscriptionLengthInMonths;
                           }
            return model;
        }

        private MembershipType MapModelToDBObject(MembershipTypesModel model)
        {
            var dbobject = new MembershipType();
            if (model != null)
            {
                dbobject.IdmembershipType = model.IdmembershipType;
                dbobject.Name = model.Name;
                dbobject.Description = model.Description;
                dbobject.SubscriptionLengthInMonths = model.SubscriptionLengthInMonths;
            }
            return dbobject;
        }

        public List<MembershipTypesModel> GetAllMembershipTypes()
        {
            var list = new List<MembershipTypesModel>();
            foreach (var dbobject in _DBContext.MembershipTypes)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }
        public MembershipTypesModel GetMembershipTypeById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.MembershipTypes.FirstOrDefault(x => x.IdmembershipType == id));
        }
        public void InsertMembershipType(MembershipTypesModel model)
        {
            model.IdmembershipType = Guid.NewGuid();
            _DBContext.MembershipTypes.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }
        public void UpdateMembershipType(MembershipTypesModel model)
        {
            var dbobject = _DBContext.MembershipTypes.FirstOrDefault(x => x.IdmembershipType == model.IdmembershipType);
            if (dbobject != null)
            {
                dbobject.IdmembershipType = model.IdmembershipType;
                dbobject.Name = model.Name;
                dbobject.Description = model.Description;
                dbobject.SubscriptionLengthInMonths = model.SubscriptionLengthInMonths;
                _DBContext.SaveChanges();
            }
        }
        public void DeleteMembershipType(MembershipTypesModel model)
        {
            var dbobject = _DBContext.MembershipTypes.FirstOrDefault(x => x.IdmembershipType == model.IdmembershipType);
            if (dbobject != null)
            {
                _DBContext.MembershipTypes.Remove(dbobject);
                _DBContext.SaveChanges();
            }

        }
    }
}
