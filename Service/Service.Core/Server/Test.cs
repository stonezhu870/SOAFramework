﻿using SOAFramework.Service.Core;
using SOAFramework.Service.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAFramework.Service.Server
{
    public class Test
    {
        [ServiceInvoker]
        //[NoAuthAttr]
        public string TestMethod(string str, string str1)
        {
            return "hell world! " + str;
        }
    }

    public class FilterTest : BaseFilter
    {
        public override bool OnActionExecuting(ActionContext context)
        {
            object[] attr = context.MethodInfo.GetCustomAttributes(typeof(NoAuthAttr), true);
            if (attr != null && attr.Length > 0)
            {
                this.Message = "验证失败！";
                return false;
            }
            return true;
        }

        public override bool OnActionExecuted(ActionContext context)
        {
            return true;
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class NoAuthAttr : Attribute
    {
    }
}
