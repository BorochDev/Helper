﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.Domain.Common
{
    public class BaseEntity
    {
        /// <summary>
        /// Dodaje właściwości które będą dostępne we wszystkich innych klasach
        /// </summary>
        public int ID { get; set; }
        public string Name { get; set; }

    }
}
