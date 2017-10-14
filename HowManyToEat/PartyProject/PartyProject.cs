using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HowManyToEat
{
    /// <summary>
    /// 开席了！
    /// </summary>
    public class PartyProject
    {
        ///// <summary>
        ///// 修改过但是尚未保存。
        ///// </summary>
        //public bool IsDirty { get; set; }

        private const string strCount = "Count";

        /// <summary>
        /// 多少席（桌）？
        /// </summary>
        public int Count { get; set; }

        private const string strLeftDishes = "LeftDishes";
        /// <summary>
        /// 每一席（桌）都有哪些菜（左栏）？
        /// </summary>
        public WeightedDishList LeftDishList { get; private set; }

        private const string strRightDishes = "RightDishes";
        /// <summary>
        /// 每一席（桌）都有哪些菜（右栏）？
        /// </summary>
        public WeightedDishList RightDishList { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public PartyProject()
        {
            this.LeftDishList = new WeightedDishList();
            this.RightDishList = new WeightedDishList();
            this.Count = 10;
        }

        public XElement ToXElement()
        {
            return new XElement(typeof(PartyProject).Name,
                new XAttribute(strCount, this.Count),
                new XElement(strLeftDishes,
                    from item in this.LeftDishList select item.ToXElement()),
                new XElement(strRightDishes,
                    from item in this.RightDishList select item.ToXElement()));
        }

        public static PartyProject Parse(XElement xml)
        {
            if (xml == null || xml.Name != typeof(PartyProject).Name) { throw new ArgumentException(); }

            var result = new PartyProject();
            int count = int.Parse(xml.Attribute(strCount).Value);
            result.Count = count;
            XElement leftDishList = xml.Element(strLeftDishes);
            foreach (var item in leftDishList.Elements(typeof(WeightedDish).Name))
            {
                WeightedDish dish = WeightedDish.Parse(item);
                result.LeftDishList.Add(dish);
            }
            XElement rightDishList = xml.Element(strRightDishes);
            foreach (var item in rightDishList.Elements(typeof(WeightedDish).Name))
            {
                WeightedDish dish = WeightedDish.Parse(item);
                result.RightDishList.Add(dish);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullname"></param>
        /// <returns></returns>
        public static PartyProject Load(string fullname)
        {
            XElement xml = XElement.Load(fullname);
            PartyProject project = PartyProject.Parse(xml);
            project.Fullname = fullname;

            return project;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            if (string.IsNullOrEmpty(this.Fullname)) { throw new ArgumentException(); }

            string filename = this.Fullname;
            if (!filename.ToLower().EndsWith(".xml"))
            {
                filename = filename + ".xml";
            }

            this.ToXElement().Save(this.Fullname);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullname"></param>
        public void SaveAs(string fullname)
        {
            if (!fullname.ToLower().EndsWith(".xml"))
            {
                fullname = fullname + ".xml";
            }

            this.ToXElement().Save(fullname);
        }
    }
}
