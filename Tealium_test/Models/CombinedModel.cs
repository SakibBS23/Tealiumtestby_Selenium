﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tealium_test.Models
{
    public class CombinedModel
    {
        public LoginModel loginModel { set; get; }
        public CartModel cartModel {  set; get; }
    }
}
