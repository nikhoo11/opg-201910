using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace opg_201910_interview.Helpers
{
    public class Methods
    {
        private static string[] dateFormat = { "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd", "MMddyyyy", "yyyyddmm", "MM dd yyyy", "yyyy MM dd" };
        private static string[] inputFormat = { @"\d{2}-\d{2}-\d{4}", @"\d{2}/\d{2}/\d{4}", @"\d{2} \d{2} \d{4}", @"\d{4}-\d{2}-\d{2}", @"\d{4}/\d{2}/\d{2}", @"\d{4} \d{2} \d{2}", @"\d{4}\d{2}\d{2}", @"\d{2}\d{2}\d{4}" };

        public static List<string> CustomStringOrdering(List<string> input, string order, bool isDateAscending = true)
        {
            try
            {
                var result = new List<string>();
                var orderBy = order.Replace(" ", "").Split(",");
                var formatted = FormatInput(input);
                foreach (var item in orderBy)
                {
                    var sorted = formatted.Where(w => w.Name.Contains(item)).ToList();
                    sorted = (isDateAscending ? sorted.OrderBy(o => o.Date).ToList() : sorted.OrderByDescending(o => o.Date).ToList());
                    result.AddRange(sorted.Select(i => i.Name));
                }
                result.AddRange(formatted.Where(w => !result.Contains(w.Name.ToString())).Select(i => i.Name).ToList());
                return result;
            }
            catch (Exception ex)
            {
                //Should log exception
                return null;
            }
        }

        public static List<TempData> FormatInput(List<string> data)
        {
            try
            {
                var holder = new List<TempData>();
                data.ForEach(f =>
                {
                    foreach (var item in inputFormat)
                    {
                        Regex rgx = new Regex(item);
                        Match match = rgx.Match(f.ToString());
                        if (match.ToString().Length > 0)
                        {
                            var temp = new TempData { 
                                Name = f.ToString(),
                                Format = item,
                                Date = ConvertStringToDateTime(match.ToString())
                            };
                            holder.Add(temp);
                        }
                    }
                });

                var format = holder.GroupBy(i => i.Format).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).Where(x => x != null).First();
                var result = holder.Where(w => w.Format == format).ToList();
                return result;
            } catch(Exception ex)
            {
                return null;
            }
        }

        public static dynamic ConvertStringToDateTime(string input)
        {
            try
            {
                DateTime dateValue;
                if (DateTime.TryParseExact(input.ToString(), dateFormat, new CultureInfo("en-US"), DateTimeStyles.None, out dateValue))
                    return dateValue;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public struct TempData
        {
            public string Name { get; set; }
            public string Format  { get; set; }
            public DateTime Date { get; set; }
        }
    }
}
