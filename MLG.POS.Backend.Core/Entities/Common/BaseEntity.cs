
namespace MLG.POS.Backend.Core.Entities.Common
{
    public class BaseEntity
    {
        public DateTime Date_Creation { get; set; } = DateTime.Now;

        public DateTime Date_Last_Modified { get; set; } = DateTime.Now;

        public int Id_User_Creation { get; set; }

        public int Id_User_Last_Modif { get; }

        public bool Id_Status { get; set; } = true;
    }
}
