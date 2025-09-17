using System.Globalization;

namespace Amoozeshyar.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; private set; } = GetPersianNow();
        public Guid CreatedBy { get; private set; }

        protected BaseEntity() { }

        protected BaseEntity(Guid createdBy)
        {
            CreatedBy = createdBy;
            CreatedAt = GetPersianNow();
        }


        public static DateTime GetPersianNow()
        {
            var pc = new PersianCalendar();
            var now = DateTime.Now;
            return pc.ToDateTime(pc.GetYear(now), pc.GetMonth(now), pc.GetDayOfMonth(now),
                                 now.Hour, now.Minute, now.Second, now.Millisecond);
        }
    }
}
