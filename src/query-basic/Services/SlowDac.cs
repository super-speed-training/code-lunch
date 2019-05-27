using System.Threading.Tasks;

namespace query_basic.Services
{
    public class SlowDac : QuickDac
    {
        public SlowDac(int totalStudent = 99, int totalTeacher = 3, int totalSubject = 5)
         : base(totalStudent, totalTeacher, totalSubject) { }

        protected override async Task PreProcessing()
            => await Task.Delay(66);
    }
}