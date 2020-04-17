using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSDemo.Model
{
    /// <summary>
    /// 密令
    /// </summary>
    public class Command
    {
        public Command()
        {
            No = double.MaxValue;
        }
        /// <summary>
        /// Name
        /// </summary>        
        public string Name { get; set; }
        /// <summary>
        ///内容
        /// </summary>
        public string Content { get; set; }

        public string type { get; set; }

        public double No { get; set; }
    }
}
