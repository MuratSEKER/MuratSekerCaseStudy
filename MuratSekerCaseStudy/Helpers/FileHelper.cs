using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using MuratSekerCaseStudy.Data.Entities;

namespace MuratSekerCaseStudy.Helpers
{
    public class FileHelper
    {
        public static Hotel HotelFromLine(string line)
        {
            try
            {
                var name = line.Substring(0, line.IndexOf(","));

                var addressLength = line.LastIndexOf("\"") - line.IndexOf("\"");

                var address = line.Substring(line.IndexOf("\"") + 1, addressLength).Replace("\"", "");

                var commabeforeRating = line.LastIndexOf("\"") + 1;
                var commaAfterRating = line.IndexOf(",", commabeforeRating + 1);

                var rating = int.Parse(line.Substring(commabeforeRating + 1, commaAfterRating - 1 - commabeforeRating));

                var commaAfterContact = line.IndexOf(",", commaAfterRating + 1);
                var contact = line.Substring(commaAfterRating + 1, commaAfterContact - 1 - commaAfterRating);

                var url = line.Substring(line.LastIndexOf(",") + 1);

                var commaBeforeUri = line.IndexOf(url) - 1;

                var phone = line.Substring(commaAfterRating + contact.Length + 2,
                    commaBeforeUri - (commaAfterRating + contact.Length + 2));

                if (ValidationHelper.IsUrlValid(url) && ValidationHelper.IsRatingValid(rating) &&
                    ValidationHelper.IsNameInUtfSet(name))
                {
                    return new Hotel()
                    {
                        Name = name,
                        Address = address,
                        Stars = rating,
                        Contact = contact,
                        Phone = phone,
                        Url = url
                    };
                }

            }
            catch (ArgumentException e)
            {
                
            }

            return null;
        }

        public static IList ToOrderedList(IList<Hotel> hotels, string option)
        {
            IList<Hotel> ordered = null;
            IEnumerable<List<Hotel>> grouped = null;
            switch (option)
            {
                case "sorting":
                    ordered = hotels.OrderByDescending(h => h.Stars).ToList();
                    return ordered as IList;

                    default:
                       grouped = hotels.GroupBy(u => u.Stars)
                            .Select(grp => grp.ToList());
                        return grouped as IList;
                    break;
            }
            return null;
        }

    }
}
