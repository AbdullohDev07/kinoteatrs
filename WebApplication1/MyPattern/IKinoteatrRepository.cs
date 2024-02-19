using WebApplication1.Roots;
using WebApplication1.RootsTDO;

namespace WebApplication1.MyPattern
{
    public interface IKinoteatrRepository
    {
        public List<Kinoteatr> GetKinoteatrs();
        public List<Kinoteatr> GetIdKinoteatr(int id);
        public KinoteatrTDO InsertKinoteatr(KinoteatrTDO kinoteatr);
        public KinoteatrTDO UpdateKinoteatr(int id, KinoteatrTDO kinoteatr);
        public int UpdatePatchKinoteatr(int id, string name);
        public int DeleteKinoteatr(int id);
    }
}
