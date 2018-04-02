using IDH7A1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDH7A1.Util
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidateRoomAvailable : ValidationAttribute
    {
        private const string DefaultErrorMessage = "{0} is already scheduled in the selected period.";

        public string MomentAttribute { get; set; }

        public ValidateRoomAvailable(string momentAttribute) : base(DefaultErrorMessage)
        {
            if (string.IsNullOrEmpty(momentAttribute))
            {
                throw new ArgumentNullException("Attribute");
            }

            MomentAttribute = momentAttribute;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var momentAttribute = validationContext.ObjectInstance.GetType().GetProperty(MomentAttribute);
            var momentValue = momentAttribute.GetValue(validationContext.ObjectInstance, null);

            if (momentValue == null)
            {
                return ValidationResult.Success;
            }

            using (var db = new SchoolDbContext())
            {
                var moment = db.Moments.Find(momentValue);
                if (moment == null)
                {
                    return ValidationResult.Success;
                }

                var moments = (from m in db.Moments
                 join mr in db.MomentRooms on m.Id equals mr.MomentId
                 where moment.StartTime < m.EndTime
                 where moment.EndTime > m.StartTime
                 where mr.RoomKey == (string)value
                 select m).Count();

                return moments > 0 ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName)) : ValidationResult.Success;
            }
        }
    }
}