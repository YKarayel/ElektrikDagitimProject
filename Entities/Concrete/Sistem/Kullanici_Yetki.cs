﻿using ElektrikDagitim.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektrikDagitim.Entities.Concrete.Sistem
{
    public class KULLANICI_YETKI : BaseEntity
    {
        public string YetkiAdı { get; set; }
    }
}